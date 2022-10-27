using Newtonsoft.Json;
using System.Net;

namespace PetStore3.SupportLibrary.Core.RestSharpClient.Models.RestSharpModels
{
    public record PetStore3ApiException
    {
        [JsonProperty("code")]
        public HttpStatusCode HttpStatusCode { get; set; }

        [JsonProperty("message")]
        public string? Message { get; set; }
    }
}
