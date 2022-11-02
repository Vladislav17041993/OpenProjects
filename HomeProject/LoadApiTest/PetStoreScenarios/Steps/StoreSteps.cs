using Common.TestData.Petstore;
using NBomber.Contracts;
using NBomber.CSharp;
using PetStore3.SupportLibrary.Core.RestSharpClient;
using System.Collections.Concurrent;

namespace LoadApiTest.PetStoreScenarios.Steps
{
    public class StoreSteps
    {
        private readonly PetStore3RestSharpMethods petStore3RestSharp = new();
        public static ConcurrentBag<long> orderIdArray = new();

        public IStep PostOrderStep(bool serializeId)
        {
            var step = Step.Create("PostOrderStep", async context =>
            {
                var expected = StoreTestData.GenerateRandomOrderTestData();
                expected.OrderSerializeRules.SerializeId = serializeId;

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

            return step;
        }

        public IStep GetOrderStep<TFeedItem>(IFeed<TFeedItem> orderIdFeed)
        {
            var step2 = Step.Create("GetOrderByIdStep", feed: orderIdFeed, async context =>
            {
                var result = await petStore3RestSharp.GetOrderById(context.FeedItem.ToString());

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

            return step2;
        }

    }
}
