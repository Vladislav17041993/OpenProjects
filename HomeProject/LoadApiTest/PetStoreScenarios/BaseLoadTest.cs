using NBomber.Contracts;
using NBomber.CSharp;
using static NBomber.Time;

namespace LoadApiTest.PetStoreScenarios
{
    public abstract class BaseLoadTest
    {

        public void GenerateScenario(int rps, double during, bool WithWarmUp, int WarmUpDuring, string scenarioName, params IStep[] steps)
        {
            Scenario scenario;
            if (WithWarmUp)
            {
                scenario = ScenarioBuilder
                    .CreateScenario(scenarioName, steps)
                    .WithWarmUpDuration(Seconds(WarmUpDuring))
                    .WithLoadSimulations(
                        Simulation.InjectPerSec(rate: rps, during: TimeSpan.FromMinutes(during))
                    );
            }
            else
            {
                scenario = ScenarioBuilder
                    .CreateScenario(scenarioName, steps)
                    .WithoutWarmUp()
                    .WithLoadSimulations(
                        Simulation.InjectPerSec(rate: rps, during: TimeSpan.FromMinutes(during))
                    );
            }

            NBomberRunner
                .RegisterScenarios(scenario)
                .Run();
        }

    }
}
