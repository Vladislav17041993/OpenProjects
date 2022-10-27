using PetStore3.SupportLibrary.Core.RestSharpClient.Models.StoreModels;

namespace Common.TestData.Petstore
{
    public class StoreTestData
    {

        public static Order GenerateMinOrderTestData() => GenerateMinOrderTestData(1).First();

        public static List<Order> GenerateMinOrderTestData(int count)
        {
            var order = new Faker<Order>("ru");

            return order.Generate(count);
        }

        public static Order GenerateMaxOrderTestData() => GenerateMaxOrderTestData(1).First();
        public static List<Order> GenerateMaxOrderTestData(int count) => GenerateOrderTestData(count, true);
        public static Order GenerateRandomOrderTestData() => GenerateRandomOrderTestData(1).First();
        public static List<Order> GenerateRandomOrderTestData(int count) => GenerateOrderTestData(count, false);

        private static List<Order> GenerateOrderTestData(int count, bool strictMode)
        {
            var order = new Faker<Order>("ru")
                .CustomInstantiator(_ =>
                {
                    return GenerateMinOrderTestData();
                })
                .RuleFor(_ => _.Id, f => f.Random.Long(0, int.MaxValue))
                .RuleFor(_ => _.PetId, f => f.Random.Long(0, int.MaxValue))
                .RuleFor(_ => _.Quantity, f => f.Random.Int(0, int.MaxValue))
                .RuleFor(_ => _.ShipDate, f => f.Date.Recent().ToString("yyyy-MM-ddThh:mm:ss.fff"))
                .RuleFor(_ => _.Status, f => f.PickRandomWithout(
                    OrderStatus.NotExistStatus,
                    OrderStatus.EmptyStatus,
                    OrderStatus.NullStatus))
                .RuleFor(_ => _.Complete, f => f.Random.Bool())
                .FinishWith((f, _) =>
                {
                    if (!strictMode)
                    {
                        _.OrderSerializeRules.SerializeId = f.Random.Bool();
                        _.OrderSerializeRules.SerializePetId = f.Random.Bool();
                        _.OrderSerializeRules.SerializeQuantity = f.Random.Bool();
                        _.OrderSerializeRules.SerializeShipDate = f.Random.Bool();
                        _.OrderSerializeRules.SerializeStatus = f.Random.Bool();
                        _.OrderSerializeRules.SerializeComplete = f.Random.Bool();
                    }
                });

            return order.Generate(count);
        }
    }
}
