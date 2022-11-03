using LoadApiTest.Interfaces;
using LoadApiTest.PetStoreScenarios.Steps;
using NBomber.CSharp;

namespace LoadApiTest.PetStoreScenarios
{
    public class GetOrderLoadTest : BaseLoadTest, IScenario
    {
        private const string ScenarioName = "GetOrder_LoadTest";

        public void Run(int rps, double during, bool WithWarmUp, int WarmUpDuring)
        {
            PostOrderLoadTest postOrderLoadTest = new()
            {
                ShouldSerializeId = true
            };
            postOrderLoadTest.Run(1, 1, false, 0);

            var Steps = new StoreSteps();
            var dataFeed = Feed.CreateCircular("order id data", StoreSteps.orderIdArray);

            var getOrderStep = Steps.GetOrderStep(dataFeed);

            GenerateScenario(rps, during, WithWarmUp, WarmUpDuring, ScenarioName, getOrderStep);
        }

    }
}
