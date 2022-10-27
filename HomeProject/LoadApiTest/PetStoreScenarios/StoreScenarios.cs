using Common.TestData.Petstore;
using NBomber.Contracts;
using NBomber.CSharp;
using PetStore3.SupportLibrary.Core.RestSharpClient;
using System.Collections.Concurrent;
using static NBomber.Time;

namespace LoadApiTest.PetStoreScenarios
{
    public class StoreScenarios
    {

        private readonly PetStore3RestSharpMethods petStore3RestSharp = new();

        public void PostOrderLoadTest()
        {         
            var step = Step.Create("PostOrder_LoadTest", async context =>
            {
                var expected = StoreTestData.GenerateRandomOrderTestData();
                var result = await petStore3RestSharp.PostOrder(expected);

                var outputResponse = Response.Fail();

                result.Switch(response =>
                {
                    outputResponse = Response.Ok(statusCode: (int)response.HttpStatusCode);
                },
                error =>
                {
                    outputResponse = Response.Fail(error: error.Message, statusCode: (int)error.HttpStatusCode);
                });

                return outputResponse;
            });

            var scenario = ScenarioBuilder
                .CreateScenario("PostOrder_LoadTest", step)                
                .WithWarmUpDuration(Seconds(5))
                .WithLoadSimulations(
                    Simulation.InjectPerSec(rate: 5, during: TimeSpan.FromSeconds(30))
                );

            NBomberRunner
                .RegisterScenarios(scenario)
                .Run();
        }       

    }
}
