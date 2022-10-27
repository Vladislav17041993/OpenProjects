using Common.TestData.Petstore;
using Newtonsoft.Json;
using NUnit.Framework;
using PetStore3.SupportLibrary.Core.NSwagClient;
using PetStore3.SupportLibrary.Core.RestSharpClient;
using System.Net;

namespace RestApiTest.NunitTests
{
    [TestFixture]
    [Parallelizable(ParallelScope.All)]
    public class PostOrderTests
    {
        private readonly PetStore3RestSharpMethods petStore3RestSharp = new();

        [Test]
        [Category("Smoke")]
        [Category("PostOrder")]
        [Category("Positive")]
        public async Task PostOrder_MinData_Positive_Test()
        {
            #region Arrange
            var expected = StoreTestData.GenerateMinOrderTestData();
            #endregion

            #region Act
            var result = await petStore3RestSharp.PostOrder(expected);
            #endregion

            #region Assert
            result.Switch(response =>
            {
                Assert.Multiple(() =>
                {
                    Assert.That(response.HttpStatusCode, Is.EqualTo(HttpStatusCode.OK), string.Format("Expected \"{0}\" is OK, actual \"{0}\" is {1}", "HttpStatusCode", response.HttpStatusCode));
                    Assert.That(response?.Content?.Id, Is.Zero, string.Format("Expected \"{0}\" is 0, actual \"{0}\" is {1}", "Id", response?.Content?.Id));
                    Assert.That(response?.Content?.PetId, Is.Zero, string.Format("Expected \"{0}\" is 0, actual \"{0}\" is {1}", "PetId", response?.Content?.PetId));
                    Assert.That(response?.Content?.Quantity, Is.Zero, string.Format("Expected \"{0}\" is 0, actual \"{0}\" is {1}", "Quantity", response?.Content?.Quantity));
                    Assert.That(response?.Content?.Complete, Is.False, string.Format("Expected \"{0}\" is 0, actual \"{0}\" is {1}", "Complete", response?.Content?.Complete));
                });
            },
            error =>
            {
                Assert.Fail($"Can't add Order, error: {error.Message} statusCode: {error.HttpStatusCode}");
            });
            #endregion
        }

        [Test]
        [Category("Smoke")]
        [Category("PostOrder")]
        [Category("Positive")]
        public async Task PostOrder_MaxData_Positive_Test()
        {
            #region Arrange
            var expected = StoreTestData.GenerateMaxOrderTestData();
            #endregion

            #region Act
            var result = await petStore3RestSharp.PostOrder(expected);
            #endregion

            #region Assert
            result.Switch(response =>
            {
                Assert.Multiple(() =>
                {
                    Assert.That(response.HttpStatusCode, Is.EqualTo(HttpStatusCode.OK));
                    Assert.That(response?.Content?.Id, Is.EqualTo(expected.Id));
                    Assert.That(response?.Content?.PetId, Is.EqualTo(expected.PetId));
                    Assert.That(response?.Content?.Quantity, Is.EqualTo(expected.Quantity));
                    Assert.That(response?.Content?.ShipDate?.Replace("+00:00", ""), Is.EqualTo(expected.ShipDate));
                    Assert.That(response?.Content?.Status, Is.EqualTo(expected.Status));
                    Assert.That(response?.Content?.Complete, Is.EqualTo(expected.Complete));
                });
            },
            error =>
            {
                Assert.Fail($"Can't add Order, error: {error.Message} statusCode: {error.HttpStatusCode}");
            });
            #endregion
        }

        [TestCase(-2147483648)]
        [TestCase(2147483647)]
        [TestCase(null)]
        [Category("PostOrder")]
        [Category("Positive")]
        public async Task PostOrder_Quantity_Positive_Test(int? quantity)
        {
            #region Arrange
            var expected = StoreTestData.GenerateMinOrderTestData();
            expected.Quantity = quantity;
            #endregion

            #region Act
            var result = await petStore3RestSharp.PostOrder(expected);
            #endregion

            #region Assert
            quantity = quantity is null ? 0 : quantity;

            result.Switch(response =>
            {
                Assert.That(response?.Content?.Quantity, Is.EqualTo(quantity));
            },
            error =>
            {
                Assert.Fail($"Can't add Order, error: {error.Message} statusCode: {error.HttpStatusCode}");
            });
            #endregion
        }

        [TestCase(-2147483649)]
        [TestCase(2147483648)]
        [Category("PostOrder")]
        [Category("Negative")]
        public async Task PostOrder_Quantity_Negative_Test(long quantityOutOfRange)
        {
            #region Arrange
            var expected = StoreTestData.GenerateMinOrderTestData();
            expected.Quantity = 17;

            var json = JsonConvert.SerializeObject(expected, new JsonSerializerSettings
            {
                Formatting = Formatting.Indented,
            });

            json = json.Replace($"{expected.Quantity}", quantityOutOfRange.ToString());
            #endregion

            #region Act
            var result = await petStore3RestSharp.PostOrder(json);
            #endregion

            #region Assert            
            result.Switch(response =>
            {
                Assert.Fail($"Can add Order, with quantity - {quantityOutOfRange}, orderId - {response?.Content?.Id}, statusCode: {response?.HttpStatusCode}");
            },
            error =>
            {
                Assert.Multiple(() =>
                {
                    Assert.That(error.HttpStatusCode, Is.EqualTo(HttpStatusCode.BadRequest));
                    Assert.That(error.Message, Is.EqualTo("Input error: unable to convert input to io.swagger.petstore.model.Order"));
                });
            });
            #endregion
        }

    }
}
