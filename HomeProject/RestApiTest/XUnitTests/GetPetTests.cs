using Common.TestData.Petstore;
using Common.Components.XUnitWrapper;
using Xunit;
using PetStore3.SupportLibrary.Core.NSwagClient;
using Xunit.Sdk;

namespace RestApiTest.XUnitTests
{
    public class GetPetTests
    {
        private readonly PetStore3NSwagMethods petStore3Methods = new();
        private static readonly Random rand = new();

        public static IEnumerable<object[]> GetPetById_Negative_TestDataSet =>
            new List<object[]>
            {
                new object[] { rand.NextInt64(0,long.MaxValue), 404, "Pet not found"},
            };

        [Theory]
        [MemberData(nameof(GetPetById_Negative_TestDataSet))]
        [Trait("Category", "GetPet")]
        [Trait("Category", "Negative")]
        public void GetPetById_Negative_Test(long id, int expectedStatusCode, string expectedResponse)
        {
            #region Arrange
            #endregion

            #region Act
            var actual = petStore3Methods.TryGetPetById(id, out Pet? pet);

            if (actual is null)
                throw new XunitException($"Запрос не вернул ожидаемую ошибку, найден объект с id: {pet?.Id}");
            #endregion

            #region Assert
            AssertAll.Check
            (
                () => Assert.Equal(expectedStatusCode, actual?.StatusCode),
                () => Assert.Equal(expectedResponse, actual?.Response)
            );
            #endregion
        }

        [Fact]
        [Trait("Category", "Smoke")]
        [Trait("Category", "GetPet")]
        [Trait("Category", "Positive")]
        public void GetPetById_MinData_Positive_Test()
        {
            #region Arrange
            var expected = PetsTestData.GenerateMinPetTestData();
            petStore3Methods.PostPet(expected, out Pet? postPet);
            #endregion

            #region Act
            var exception = petStore3Methods.TryGetPetById(expected.Id, out Pet? actual);

            if (exception is not null)
                throw new XunitException($"Запрос GetPetById выполнился с ошибкой:{exception?.Response}, statusCode: {exception?.StatusCode}");
            #endregion

            #region Assert
            AssertAll.Check
            (
                () => Assert.Equal(expected.Id, actual?.Id),
                () => Assert.Empty(actual?.PhotoUrls),
                () => Assert.Empty(actual?.Tags),
                () => Assert.Equal(expected.Status, actual?.Status)
            );
            #endregion
        }

        [Fact]
        [Trait("Category", "Smoke")]
        [Trait("Category", "GetPet")]
        [Trait("Category", "Positive")]
        public void GetPetById_MaxData_Positive_Test()
        {
            #region Arrange
            var expected = PetsTestData.GenerateMaxPetTestData();
            petStore3Methods.PostPet(expected, out Pet? postPet);
            #endregion

            #region Act
            var exception = petStore3Methods.TryGetPetById(expected.Id, out Pet? actual);

            if (exception is not null)
                throw new XunitException($"Запрос GetPetById выполнился с ошибкой:{exception?.Response}, statusCode: {exception?.StatusCode}");
            #endregion

            #region Assert
            AssertAll.Check
            (
            () => Assert.Equal(expected.Id, actual?.Id),
                () => Assert.Equal(expected.Name, actual?.Name),
                () => Assert.Equal(expected.Category.Id, actual?.Category.Id),
                () => Assert.Equal(expected.Category.Name, actual?.Category.Name),
                () =>
                {
                    if (expected.PhotoUrls.Count == actual?.PhotoUrls.Count)
                    {
                        expected.PhotoUrls.AsParallel().ForAll(url =>
                        {
                            Assert.Contains<string>(url, actual?.PhotoUrls);
                        });

                        return;
                    }

                    throw new XunitException($"Количество полученных PhotoUrl отличается, передано: {expected.PhotoUrls.Count}, получено: {actual?.PhotoUrls.Count}.");
                },
                () =>
                {
                    if (expected.Tags.Count == actual?.Tags.Count)
                    {
                        expected.Tags.ToList().ForEach(exp_tag =>
                        {
                            Assert.NotNull(actual?.Tags.FirstOrDefault(_ => _.Id == exp_tag.Id));
                            Assert.NotNull(actual?.Tags.FirstOrDefault(_ => _.Name.Equals(exp_tag.Name)));
                        });

                        return;
                    }

                    throw new XunitException($"Количество полученных Tags отличается, передано: {expected.Tags.Count}, получено: {actual?.Tags.Count}.");
                },
                () => Assert.Equal(expected.Status, actual?.Status)
            );
            #endregion
        }
    }
}
