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
        public void PostPet_Id_Positive_Test(long id)
        {
            #region Arrange
            var expected = PetsTestData.GenerateMinPetTestData();
            #endregion

            #region Act
            expected.Id = id;
            var exception = petStore3Methods.PostPet(expected, out Pet? actual);

            if (exception is not null)
                throw new XunitException($"Запрос PostPet выполнился с ошибкой:{exception?.Response}, statusCode: {exception?.StatusCode}");
            #endregion

            #region Assert
            Assert.Equal(expected.Id, actual?.Id);
            #endregion
        }

        [Fact]
        [Trait("Category", "Smoke")]
        [Trait("Category", "PostPet")]
        [Trait("Category", "Positive")]
        public void PostPet_MinData_Positive_Test()
        {
            #region Arrange
            var expected = PetsTestData.GenerateMinPetTestData();
            #endregion

            #region Act
            var exception = petStore3Methods.PostPet(expected, out Pet? actual);

            if (exception is not null)
                throw new XunitException($"Запрос PostPet выполнился с ошибкой:{exception?.Response}, statusCode: {exception?.StatusCode}");
            #endregion

            #region Assert
            AssertAll.Check
            (
                () => Assert.True(expected.Id == actual?.Id, $"Идентификатор не совпадает, ожидается: {expected.Id}, получено: {actual?.Id}."),
                () => Assert.True(actual?.PhotoUrls.Count == 0, $"Массив PhotoUrl должен быть пустой, однако получено {actual?.PhotoUrls.Count} элементов."),
                () => Assert.True(actual?.Tags.Count == 0, $"Массив Tags должен быть пустой, однако получено {actual?.Tags.Count} элементов."),
                () => Assert.True(expected.Status == actual?.Status, $"Статус не совпадает, ожидается: {expected.Status}, получено: {actual?.Status}.")
            );
            #endregion
        }

        [Fact]
        [Trait("Category", "Smoke")]
        [Trait("Category", "PostPet")]
        [Trait("Category", "Positive")]
        public void PostPet_MaxData_Positive_Test()
        {
            #region Arrange
            var expected = PetsTestData.GenerateMaxPetTestData();
            #endregion

            #region Act
            var exception = petStore3Methods.PostPet(expected, out Pet? actual);

            if (exception is not null)
                throw new XunitException($"Запрос PostPet выполнился с ошибкой:{exception?.Response}, statusCode: {exception?.StatusCode}");
            #endregion

            #region Assert
            AssertAll.Check
            (
                () => Assert.True(expected.Id == actual?.Id, $"Идентификатор не совпадает, ожидается: {expected.Id}, получено: {actual?.Id}."),
                () => Assert.True(expected.Name.Equals(actual?.Name), $"Имя не совпадает ожидается: {expected.Name}, получено: {actual?.Name}."),
                () => Assert.True(expected.Category.Id == actual?.Category.Id, $"Идентификатор категории не совпадает, ожидается: {expected.Category.Id}, получено: {actual?.Category.Id}."),
                () => Assert.True(expected.Category.Name.Equals(actual?.Category.Name), $"Имя категории не совпадает, ожидается: {expected.Category.Name}, получено: {actual?.Category.Name}."),
                () =>
                {
                    if (expected.PhotoUrls.Count == actual?.PhotoUrls.Count)
                    {
                        expected.PhotoUrls.AsParallel().ForAll(url =>
                        {
                            Assert.True(actual?.PhotoUrls.Contains(url), $"Переданный PhotoUrl: {url} не получен.");
                        });

                        return;
                    }

                    throw new XunitException($"Количество полученных PhotoUrl отличается, передано: {expected.PhotoUrls.Count}, получено: {actual?.PhotoUrls.Count}.");
                },
                () =>
                {
                    if (expected.Tags.Count == actual?.Tags.Count)
                    {
                        expected.Tags.AsParallel().ForAll(tag =>
                        {
                            AssertAll.Check
                            (
                                () => Assert.True(actual?.Tags.FirstOrDefault(_ => _.Id == tag.Id) != default, $"Переданный таг: id - {tag.Id}, Name - {tag.Name} не получен по id."),
                                () => Assert.True(actual?.Tags.FirstOrDefault(_ => _.Name.Equals(tag.Name)) != default, $"Переданный таг: id - {tag.Id}, Name - {tag.Name} не получен по name.")
                            );
                        });

                        return;
                    }

                    throw new XunitException($"Количество полученных Tags отличается, передано: {expected.Tags.Count}, получено: {actual?.Tags.Count}.");
                },
                () => Assert.True(expected.Status == actual?.Status, $"Статус не совпадает, ожидается: {expected.Status}, получено: {actual?.Status}.")
            );
            #endregion
        }

    }
}
