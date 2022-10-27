using Newtonsoft.Json;
using OneOf;
using PetStore3.SupportLibrary.Core.RestSharpClient.Models.RestSharpModels;
using RestSharp;

namespace PetStore3.SupportLibrary.Core.RestSharpClient
{
    public class RestSharpClient
    {
        private readonly RestClient _restClient;
        public string Header_ContentType { get; init; } = "application/json";
        public string Header_Accept { get; init; } = "application/json";

        public RestSharpClient(RestClient restClient)
        {
            _restClient = restClient;
        }

        public Task<OneOf<RestSharpResponse<T>, PetStore3ApiException>> GetAsync<T>(string url) where T : class
            => ExecuteAsync<T>(url, null, Method.Get);

        public Task<OneOf<RestSharpResponse<T>, PetStore3ApiException>> PostAsync<T>(string url, object body) where T : class
            => ExecuteAsync<T>(url, body, Method.Post);

        private async Task<OneOf<RestSharpResponse<T>, PetStore3ApiException>> ExecuteAsync<T>(string url, object? body, Method method) where T : class
        {
            var request = new RestRequest(url);           
            request.AddHeader("Accept", Header_Accept);
            request.Method = method;

            if (method == Method.Post & body is not null)
            {
                string json;
                if(body is not string)
                {
                    json = JsonConvert.SerializeObject(body, new JsonSerializerSettings
                    {
                        Formatting = Formatting.Indented,
                    });
                }
                else
                {
                    json = (string)body;
                }

                request.AddHeader("ContentType", Header_ContentType);
                request.AddBody(json, contentType: Header_ContentType);
            }

            var response = await _restClient.ExecuteAsync(request);

            if (string.IsNullOrEmpty(response.Content))
                return new PetStore3ApiException() { Message = "Result.Content is empty" };

            if (response.IsSuccessful)
            {
                try
                {
                    var result = new RestSharpResponse<T>()
                    {
                        Content = JsonConvert.DeserializeObject<T>(response.Content) ?? throw new NullReferenceException(),
                        HttpStatusCode = response.StatusCode,
                    };

                    return result;
                }
                catch (Exception)
                {
                    return new PetStore3ApiException()
                    {
                        Message = $"Can't deserialize response to {typeof(T).Name}, response: {response.Content}",
                        HttpStatusCode = response.StatusCode
                    };
                }
            }

            try
            {
                //Check that response is json
                if(response.Content.StartsWith("{") & response.Content.EndsWith("}"))
                    return JsonConvert.DeserializeObject<PetStore3ApiException>(response.Content) ?? throw new NullReferenceException();

                return new PetStore3ApiException()
                {
                    Message = response.Content,
                    HttpStatusCode = response.StatusCode
                };
            }
            catch (Exception)
            {
                return new PetStore3ApiException()
                {
                    Message = $"Can't deserialize json response to PetStore3ApiException, response: {response.Content}",
                    HttpStatusCode = response.StatusCode
                };
            }
        }

    }
}
