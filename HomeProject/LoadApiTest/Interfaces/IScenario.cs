namespace LoadApiTest.Interfaces
{
    public interface IScenario
    {
        public void Run(int Rps, double during, bool WithWarmUp, int WarmUpDuring);
    }
}
