namespace LoadApiUiRunner.DataStorage.Models
{
    public class ScenarioModel
    {
        public ScenarioModel()
        {
            Rps = 5;
            During = 1;
            WithWarmUp = false;
            WarmUpDuring = 1;
            ShouldBeStarted = false;
        }

        public short Rps { get; set; }
        public short During { get; set; }
        public bool WithWarmUp { get; set; }
        public short WarmUpDuring { get; set; }
        public bool ShouldBeStarted { get; set; }
    }
}
