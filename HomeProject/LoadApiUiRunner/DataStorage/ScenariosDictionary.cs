using LoadApiUiRunner.DataStorage.Models;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LoadApiUiRunner.DataStorage
{
    public static class ScenariosDictionary
    {
        public static bool ContainsKey(string name) => _scenarios.ContainsKey(name);

        public static ScenarioModel? GetScenarioSettingsByName(string name) => _scenarios.FirstOrDefault(_ => _.Key.Equals(name)).Value;

        public static void SetScenarioSettingsByName(string name, ScenarioModel inputData)
        {
            _scenarios[name] = inputData;           
        }

        public static IEnumerable<KeyValuePair<string, ScenarioModel>> GetScenariosToRun() => _scenarios.Where(_ => _.Value.ShouldBeStarted == true);

        public static string PrintScenariosToRun()
        {
            var scenarios = GetScenariosToRun();

            var sb = new StringBuilder();
            foreach(var scenario in scenarios)
            {
                sb.AppendLine($"{scenario.Key}")
                    .AppendLine($"RPS: {scenario.Value.Rps}")
                    .AppendLine($"During: {scenario.Value.During}min")
                    .AppendLine($"WithWarmUp: {BoolToString(scenario.Value.WithWarmUp)}");

                if (scenario.Value.WithWarmUp)
                {
                    sb.AppendLine($"WarmUp During: {scenario.Value.WarmUpDuring}min");
                }

                sb.AppendLine();
            };

            return sb.ToString();

            static string BoolToString(bool value) => value ? "true" : "false";
        }

        private static readonly Dictionary<string, ScenarioModel> _scenarios = new(2)
        {
            { "PostOrderScenario", new ScenarioModel() },
            { "GetOrderScenario", new ScenarioModel() },
        };
    }
}
