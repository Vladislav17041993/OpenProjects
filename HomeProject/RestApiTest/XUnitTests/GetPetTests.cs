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
        public async Task GetPetById_Negative_Test(long id, int expectedStatusCode, string expectedResponse)
        {
            #region Arrange
            #endregion

            #region Act
            var result = await petStore3Methods.TryGetPetById(id);
            #endregion

            #region Assert
            result.Switch(response =>
            {
                throw new XunitException($"Request didn't return expected error, pet with id was found: {response.Id}");
            },
            exception =>
            {
                AssertAll.Check
                (
                    () => Assert.Equal(expectedStatusCode, exception.StatusCode),
                    () => Assert.Equal(expectedResponse, exception.Response)
                );
            });
            #endregion
        }

        [Fact]
        [Trait("Category", "Smoke")]
        [Trait("Category", "GetPet")]
        [Trait("Category", "Positive")]
        public async Task GetPetById_MinData_Positive_Test()
        {
            #region Arrange
            var expected = PetsTestData.GenerateMinPetTestData();
            await petStore3Methods.PostPet(expected);
            #endregion

            #region Act
            var result = await petStore3Methods.TryGetPetById(expected.Id);
            #endregion

            #region Assert
            result.Switch(response =>
            {
                AssertAll.Check
                (
                    () => Assert.Equal(expected.Id, response?.Id),
                    () => Assert.Empty(response?.PhotoUrls),
                    () => Assert.Empty(response?.Tags),
                    () => Assert.Equal(expected.Status, response?.Status)
                );
            },
            exception =>
            {
                throw new XunitException($"Request GetPetById complited with error:{exception?.Response}, statusCode: {exception?.StatusCode}");
            });
            #endregion
        }

        [Fact]
        [Trait("Category", "Smoke")]
        [Trait("Category", "GetPet")]
        [Trait("Category", "Positive")]
        public async Task GetPetById_MaxData_Positive_Test()
        {
            #region Arrange
            var expected = PetsTestData.GenerateMaxPetTestData();
            await petStore3Methods.PostPet(expected);
            #endregion

            #region Act
            var result = await petStore3Methods.TryGetPetById(expected.Id);     
            #endregion

            #region Assert
            result.Switch(response =>
            {
                AssertAll.Check
                (
                    () => Assert.Equal(expected.Id, response?.Id),
                    () => Assert.Equal(expected.Name, response?.Name),
                    () => Assert.Equal(expected.Category.Id, response?.Category.Id),
                    () => Assert.Equal(expected.Category.Name, response?.Category.Name),
                    () =>
                    {
                        if (expected.PhotoUrls.Count == response?.PhotoUrls.Count)
                        {
                            expected.PhotoUrls.AsParallel().ForAll(url =>
                            {
                                Assert.Contains<string>(url, response?.PhotoUrls);
                            });
                
                            return;
                        }
                
                        throw new XunitException("Number of received PhotoUrl is different:");
                    },
                    () =>
                    {
                        if (expected.Tags.Count == response?.Tags.Count)
                        {
                            expected.Tags.ToList().ForEach(exp_tag =>
                            {
                                Assert.NotNull(response?.Tags.FirstOrDefault(_ => _.Id == exp_tag.Id));
                                Assert.NotNull(response?.Tags.FirstOrDefault(_ => _.Name.Equals(exp_tag.Name)));
                            });
                
                            return;
                        }
                
                        throw new XunitException("Number of received Tags is different:");
                    },
                    () => Assert.Equal(expected.Status, response?.Status)
                );
            },
            exception =>
            {
                throw new XunitException($"Request GetPetById complited with error:{exception?.Response}, statusCode: {exception?.StatusCode}");
            });
            #endregion
        }
    }
}
