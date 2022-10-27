using PetStore3.SupportLibrary.Core.NSwagClient;

namespace Common.TestData.Petstore
{
    public class PetsTestData
    {
        public static Pet GenerateMinPetTestData() => GenerateMinPetTestData(1).First();

        public static List<Pet> GenerateMinPetTestData(int count)
        {
            var pet = new Faker<Pet>("ru")
                .StrictMode(false)
                .RuleFor(_ => _.Id, f => f.Random.Long(0, int.MaxValue))
                .RuleFor(_ => _.Status, f => f.PickRandom<PetStatus>());

            return pet.Generate(count);
        }

        public static Pet GenerateMaxPetTestData() => GenerateMaxPetTestData(1).First();

        public static List<Pet> GenerateMaxPetTestData(int count) => GeneratePetTestData(count, true);

        public static Pet GenerateRandomPetTestData() => GenerateRandomPetTestData(1).First();

        public static List<Pet> GenerateRandomPetTestData(int count) => GeneratePetTestData(count, false);

        private static List<Pet> GeneratePetTestData(int count, bool strictMode)
        {
            var categoryName = new string[] { "Dogs", "Cats", "Pet Rodents", "Guinea pigs", "Mices", "Rabbits" };

            var pet = new Faker<Pet>("ru")
                .StrictMode(false)
                .CustomInstantiator(_ =>
                {
                    return GenerateMinPetTestData();                    
                })
                .RuleFor(_ => _.Name, (f, _) =>
                {
                    if (!strictMode && f.Random.Bool())
                        return null;

                    return f.Name.FirstName(f.PickRandom<Gender>());
                })
                .RuleFor(_ => _.Category, (f, _) =>
                {
                    if (!strictMode && f.Random.Bool())
                        return null;

                    return new Category
                    {
                        Id = f.Random.Long(0, int.MaxValue),
                        Name = categoryName[f.Random.Number(0, categoryName.Length - 1)]
                    };
                })
                .RuleFor(_ => _.PhotoUrls, (f, _) =>
                {
                    if (!strictMode && f.Random.Bool())
                        return null;

                    return Enumerable
                    .Range(1, f.Random.Number(1, 20))
                    .Select(_ => f.Internet.Url())
                    .ToList();
                })
                .RuleFor(_ => _.Tags, (f, _) =>
                {
                    if (!strictMode && f.Random.Bool())
                        return null;

                    return Enumerable
                    .Range(1, f.Random.Number(1, 20))
                    .Select(_ => new Tag
                    {
                        Id = f.Random.Long(0, int.MaxValue),
                        Name = f.Name.LastName(f.PickRandom<Gender>())
                    })
                    .ToList();
                });

            return pet.Generate(count);
        }
    }
}
