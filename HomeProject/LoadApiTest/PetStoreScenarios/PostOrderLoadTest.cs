using LoadApiTest.Interfaces;
using LoadApiTest.PetStoreScenarios.Steps;
using NBomber.CSharp;
using static NBomber.Time;

namespace LoadApiTest.PetStoreScenarios
{
    public class PostOrderLoadTest : IScenario
    {
        public bool ShouldSerializeId = false;

        public void Run(int rps, double during, bool WithWarmUp, int WarmUpDuring)
        {
            var Steps = new StoreSteps();
            var postOrderStep = Steps.PostOrderStep(serializeId: ShouldSerializeId);

            var scenario = ScenarioBuilder
                .CreateScenario("PostOrder_LoadTest", postOrderStep)
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
