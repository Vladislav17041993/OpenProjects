using LoadApiTest.Interfaces;
using LoadApiTest.PetStoreScenarios;

namespace LoadApiTest
{
    public class Program
    {
        public static void Main(string[] args)
        {
            //args = new string[] { "GetOrderScenario", "1", "1", "false", "0" };

            var scenarioName = args[0];
            var rps = int.Parse(args[1]);
            var during = double.Parse(args[2]);
            var withWarmUp = bool.Parse(args[3]);
            var warmUpDuration = int.Parse(args[4]);

            var scenario = ScenarioDictionary[scenarioName];
            scenario.Run(rps, during, withWarmUp, warmUpDuration);
        }

        private static Dictionary<string, IScenario> ScenarioDictionary = new()
        {
            {"PostOrderScenario", new PostOrderLoadTest() },
            {"GetOrderScenario", new GetOrderLoadTest() }
        };
    }
}