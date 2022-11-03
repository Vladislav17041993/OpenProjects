using LoadApiTest.Interfaces;
using LoadApiTest.PetStoreScenarios.Steps;
using NBomber.Contracts;
using NBomber.CSharp;
using static NBomber.Time;

namespace LoadApiTest.PetStoreScenarios
{
    public class PostOrderLoadTest : BaseLoadTest, IScenario
    {
        public bool ShouldSerializeId = false;
        private const string ScenarioName = "PostOrder_LoadTest";

        public void Run(int rps, double during, bool WithWarmUp, int WarmUpDuring)
        {
            var Steps = new StoreSteps();
            var postOrderStep = Steps.PostOrderStep(serializeId: ShouldSerializeId);
            GenerateScenario(rps, during, WithWarmUp, WarmUpDuring, ScenarioName, postOrderStep);           
        }

    }
}
