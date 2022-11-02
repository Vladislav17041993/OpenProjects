using LoadApiTest.Interfaces;
using LoadApiTest.PetStoreScenarios.Steps;
using NBomber.CSharp;
using static NBomber.Time;

namespace LoadApiTest.PetStoreScenarios
{
    public class GetOrderLoadTest : IScenario
    {
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

            var scenario = ScenarioBuilder
                .CreateScenario("GetOrder_LoadTest", getOrderStep)
                .WithWarmUpDuration(Seconds(WarmUpDuring))
                .WithLoadSimulations(
                    Simulation.InjectPerSec(rate: rps, during: TimeSpan.FromMinutes(during))
                );

            NBomberRunner
                .RegisterScenarios(scenario)
                .Run();
        }

    }
}
