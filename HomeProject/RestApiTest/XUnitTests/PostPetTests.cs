using Common.TestData.Petstore;
using Common.Components.XUnitWrapper;
using Xunit.Sdk;
using Xunit;
using PetStore3.SupportLibrary.Core.NSwagClient;

namespace RestApiTest.XUnitTests
{
    public class PostPetTests
    {
        private readonly PetStore3NSwagMethods petStore3Methods = new();

        [Theory]
        [InlineData(long.MinValue)]
        [InlineData(long.MaxValue)]
        [Trait("Category", "PostPet")]
        [Trait("Category", "Positive")]
        public async Task PostPet_Id_Positive_Test(long id)
        {
            #region Arrange
            var expected = PetsTestData.GenerateMinPetTestData();
            expected.Id = id;
            #endregion

            #region Act
            var result = await petStore3Methods.PostPet(expected);
            #endregion

            #region Assert
            result.Switch(response =>
            {
                Assert.Equal(expected.Id, response?.Id);
            },
            exception =>
            {
                throw new XunitException($"Request PostPet complited with error:{exception?.Response}, statusCode: {exception?.StatusCode}");
            });
            #endregion
        }

        [Fact]
        [Trait("Category", "Smoke")]
        [Trait("Category", "PostPet")]
        [Trait("Category", "Positive")]
        public async Task PostPet_MinData_Positive_Test()
        {
            #region Arrange
            var expected = PetsTestData.GenerateMinPetTestData();
            #endregion

            #region Act
            var result = await petStore3Methods.PostPet(expected);
            #endregion

            #region Assert
            result.Switch(response =>
            {
                AssertAll.Check
                (
                    () => Assert.True(expected.Id == response.Id, "Id exeption:"),
                    () => Assert.True(response.PhotoUrls.Count == 0, "Array PhotoUrl should be empty:"),
                    () => Assert.True(response.Tags.Count == 0, "Array Tags should be empty:"),
                    () => Assert.True(expected.Status == response?.Status, "Status exeption:")
                );
            },
            exception =>
            {
                throw new XunitException($"Request PostPet complited with error:{exception?.Response}, statusCode: {exception?.StatusCode}");
            });
            #endregion
        }

        [Fact]
        [Trait("Category", "Smoke")]
        [Trait("Category", "PostPet")]
        [Trait("Category", "Positive")]
        public async Task PostPet_MaxData_Positive_Test()
        {
            #region Arrange
            var expected = PetsTestData.GenerateMaxPetTestData();
            #endregion

            #region Act
            var result = await petStore3Methods.PostPet(expected);         
            #endregion

            #region Assert
            result.Switch(response =>
            {
                AssertAll.Check
                (
                    () => Assert.True(expected.Id == response.Id, "Id error:"),
                    () => Assert.True(expected.Name.Equals(response.Name), "Name error:"),
                    () => Assert.True(expected.Category.Id == response.Category.Id, "Category.Id error:"),
                    () => Assert.True(expected.Category.Name.Equals(response.Category.Name), "Category.Name error:"),
                    () =>
                    {
                        if (expected.PhotoUrls.Count == response.PhotoUrls.Count)
                        {
                            expected.PhotoUrls.AsParallel().ForAll(url =>
                            {
                                Assert.True(response.PhotoUrls.Contains(url), "PhotoUrl didn't found:");
                            });
                    
                            return;
                        }
                    
                        throw new XunitException("Number of received PhotoUrl is different:");
                    },
                    () =>
                    {
                        if (expected.Tags.Count == response.Tags.Count)
                        {
                            expected.Tags.AsParallel().ForAll(tag =>
                            {
                                AssertAll.Check
                                (
                                    () => Assert.True(response.Tags.FirstOrDefault(_ => _.Id == tag.Id) != default, "Tag.Id didn't found:"),
                                    () => Assert.True(response.Tags.FirstOrDefault(_ => _.Name.Equals(tag.Name)) != default, "Tag.Name didn't found:")
                                );
                            });
                    
                            return;
                        }
                    
                        throw new XunitException("Number of received Tags is different:");
                    },
                    () => Assert.True(expected.Status == response.Status, "Status error:")
                );
            },
            exception =>
            {
                throw new XunitException($"Request PostPet complited with error:{exception?.Response}, statusCode: {exception?.StatusCode}");
            });           
            #endregion
        }

    }
}
