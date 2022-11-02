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
                .WithWarmUpDuration(Seconds(0))
                .WithLoadSimulations(
                    Simulation.InjectPerSec(rate: 1, during: TimeSpan.FromSeconds(10))
                );

            NBomberRunner
                .RegisterScenarios(scenario)
                .Run();
        }

        public void GetOrderLoadTest()
        {
            ConcurrentBag<long> orderIdArray = new();

            var step = Step.Create("PostOrder_LoadTest", async context =>
            {
                var expected = StoreTestData.GenerateRandomOrderTestData();
                expected.OrderSerializeRules.SerializeId = true;

                var result = await petStore3RestSharp.PostOrder(expected);

                var outputResponse = Response.Fail();

                result.Switch(response =>
                {
                    if (response?.Content?.Id is not null)
                        orderIdArray.Add((long)response.Content.Id);

                    outputResponse = Response.Ok(statusCode: (int)response.HttpStatusCode);
                },
                error =>
                {
                    outputResponse = Response.Fail(error: error.Message, statusCode: (int)error.HttpStatusCode);
                });

                return outputResponse;
            });

            var dataFeed = Feed.CreateCircular("order id data", orderIdArray);

            var step2 = Step.Create("GetOrder_LoadTest", feed: dataFeed, async context =>
            {
                var result = await petStore3RestSharp.GetOrderById(context.FeedItem.ToString());

                var outputResponse = Response.Fail();

                result.Switch(response =>
                {
                    if (response?.Content?.Id is not null)
                        orderIdArray.Add((long)response.Content.Id);

                    outputResponse = Response.Ok(statusCode: (int)response.HttpStatusCode);
                },
                error =>
                {
                    outputResponse = Response.Fail(error: error.Message, statusCode: (int)error.HttpStatusCode);
                });

                return outputResponse;
            });

            var scenario = ScenarioBuilder
                .CreateScenario("PrepareData_PostOrders", step)
                .WithLoadSimulations(
                    Simulation.InjectPerSec(rate: 1, during: TimeSpan.FromSeconds(10))
                );

            var scenario2 = ScenarioBuilder
                .CreateScenario("GetOrder_LoadTest", step2)
                .WithLoadSimulations(
                    Simulation.InjectPerSec(rate: 1, during: TimeSpan.FromSeconds(20))
                );

            NBomberRunner
                .RegisterScenarios(scenario, scenario2)
                .Run();
        }

    }
}
