using LoadApiTest.PetStoreScenarios;

namespace LoadApiTest
{
    public class Program
    {
        public delegate void P();

        public static void Main(string[] args)
        {
            StoreScenarios storeScenarios = new();
            var argsList = args.ToList();

            if (argsList.Contains("PostOrderScenario"))
            {
                storeScenarios.PostOrderLoadTest();
            }

            if (argsList.Contains("GetOrderScenario"))
            {
                storeScenarios.GetOrderLoadTest();
            }
        }
    }
}