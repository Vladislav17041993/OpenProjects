using Common.TestData.Petstore;
using NUnit.Framework;
using PetStore3.SupportLibrary.Core.RestSharpClient;
using System.Net;

namespace RestApiTest.NunitTests
{
    [TestFixture]
    [Parallelizable(ParallelScope.All)]
    public class GetOrderTests
    {
        private readonly PetStore3RestSharpMethods petStore3RestSharp = new();

        [Test]
        [Category("Smoke")]
        [Category("GetOrder")]
        [Category("Positive")]
        public async Task GetOrder_MinData_Positive_Test()
        {
            #region Arrange
            var expected = StoreTestData.GenerateMinOrderTestData();
            expected.Id = 100;

            await petStore3RestSharp.PostOrder(expected);
            #endregion

            #region Act
            var result = await petStore3RestSharp.GetOrderById($"{expected.Id}");
            #endregion

            #region Assert
            result.Switch(response =>
            {
                Assert.That(response.HttpStatusCode, Is.EqualTo(HttpStatusCode.OK), "HttpStatusCode exeption:");
                Assert.That(response?.Content?.Id, Is.EqualTo(expected.Id), "Id exeption:");
                Assert.That(response?.Content?.PetId, Is.Zero, "PetId exeption:");
                Assert.That(response?.Content?.Quantity, Is.Zero, "Quantity exeption:");
                Assert.That(response?.Content?.Complete, Is.False, "Complete exeption:");
            },
            error =>
            {
                Assert.Fail($"Can't get Order with id{expected.Id}, error: {error.Message} statusCode: {error.HttpStatusCode}");
            });
            #endregion
        }

        [Test]
        [Category("Smoke")]
        [Category("GetOrder")]
        [Category("Positive")]
        public async Task GetOrder_MaxData_Positive_Test()
        {
            #region Arrange
            var expected = StoreTestData.GenerateMaxOrderTestData();
            await petStore3RestSharp.PostOrder(expected);
            #endregion

            #region Act
            var result = await petStore3RestSharp.GetOrderById($"{expected.Id}");
            #endregion

            #region Assert
            result.Switch(response =>
            {
                Assert.That(response.HttpStatusCode, Is.EqualTo(HttpStatusCode.OK), "HttpStatusCode exeption:");
                Assert.That(response?.Content?.Id, Is.EqualTo(expected.Id), "Id exeption:");
                Assert.That(response?.Content?.PetId, Is.EqualTo(expected.PetId), "PetId exeption:");
                Assert.That(response?.Content?.Quantity, Is.EqualTo(expected.Quantity), "Quantity exeption:");
                Assert.That(response?.Content?.ShipDate?.Replace("+00:00", ""), Is.EqualTo(expected.ShipDate), "ShipDate exeption");
                Assert.That(response?.Content?.Status, Is.EqualTo(expected.Status), "Status exeption");
                Assert.That(response?.Content?.Complete, Is.EqualTo(expected.Complete), "Complete exeption:");
            },
            error =>
            {
                Assert.Fail($"Can't get Order with id{expected.Id}, error: {error.Message} statusCode: {error.HttpStatusCode}");
            });
            #endregion
        }

        [Test]
        [Category("GetOrder")]
        [Category("Negative")]
        public async Task GetOrder_NotFound_Negative_Test()
        {
            #region Arrange
            // For valid response try integer IDs with value <= 5 or > 10. Other values will generate exceptions.
            var orderId = 5;
            #endregion

            #region Act
            var result = await petStore3RestSharp.GetOrderById(orderId.ToString());
            #endregion

            #region Assert
            result.Switch(response =>
            {
                Assert.Fail($"Can get not exist Order with id{orderId}, statusCode: {response.HttpStatusCode}");
            },
            error =>
            {
                Assert.Multiple(() =>
                {
                    Assert.That(error.HttpStatusCode, Is.EqualTo(HttpStatusCode.NotFound), "HttpStatusCode exeption:");
                    Assert.That(error.Message, Is.EqualTo("Order not found"), "Message exeption:");
                });
            });
            #endregion
        }
    }
}
