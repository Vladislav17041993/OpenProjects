using Common.Components;
using OneOf;
using PetStore3.SupportLibrary.Core.RestSharpClient.Models.RestSharpModels;
using PetStore3.SupportLibrary.Core.RestSharpClient.Models.StoreModels;
using RestSharp;

namespace PetStore3.SupportLibrary.Core.RestSharpClient
{
    public class PetStore3RestSharpMethods
    {
        private const string _baseUrl = "/api/v3";
        private readonly RestSharpClient _petStore3RestSharpClient;

        public PetStore3RestSharpMethods()
        {
            _petStore3RestSharpClient = new(new RestClient(ConfigReader.PetStore3BaseUrl)) { };
        }

        //Everything about your Pets
        #region pet

        #endregion

        //Access to Petstore orders
        #region store
        /// <summary>
        /// Place a new order in the store
        /// </summary>
        public Task<OneOf<RestSharpResponse<Order>, PetStore3ApiException>> PostOrder(object order) => _petStore3RestSharpClient.PostAsync<Order>(_baseUrl + "/store/order", order);
        
        /// <summary>
        /// Find purchase order by ID
        /// </summary>
        public Task<OneOf<RestSharpResponse<Order>, PetStore3ApiException>> GetOrderById(string orderId) => _petStore3RestSharpClient.GetAsync<Order>(_baseUrl + $"/store/order/{orderId}");
        #endregion
        //Operations about user
        #region users

        #endregion
    }
}
