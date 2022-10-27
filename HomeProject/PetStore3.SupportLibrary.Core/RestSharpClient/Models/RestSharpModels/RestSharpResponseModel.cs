using System.Net;

namespace PetStore3.SupportLibrary.Core.RestSharpClient.Models.RestSharpModels
{
    public class RestSharpResponse<T> where T : class
    {
        public T? Content { get; set; }
        public HttpStatusCode HttpStatusCode { get; set; }
    }
}
