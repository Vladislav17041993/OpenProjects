using Common.Components;
using Xunit.Sdk;

namespace PetStore3.SupportLibrary.Core.NSwagClient
{
    public class PetStore3NSwagMethods
    {
        private readonly PetStore3NSwagClient _petStore3NSwagClient;

        public PetStore3NSwagMethods()
        {
            _petStore3NSwagClient = new PetStore3NSwagClient(new HttpClient()
            {
                BaseAddress = new Uri(ConfigReader.PetStore3BaseUrl)
            });
        }

        //Everything about your Pets
        #region pet
        /// <summary>
        /// Add a new pet to the store
        /// </summary>
        /// <param name="body">Create a new pet in the store</param>
        /// <returns>Successful operation</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        public ApiException? PostPet(Pet body, out Pet? pet)
        {
            try
            {
                pet = _petStore3NSwagClient.AddPetAsync(body).Result;
                return null;
            }
            catch (AggregateException exeption)
            {
                pet = null;
                return exeption.InnerExceptions.FirstOrDefault() as ApiException;
            }
            catch (Exception exeption)
            {
                throw new XunitException(exeption.Message);
            }
        }

        /// <summary>
        /// Find pet by ID
        /// </summary>
        /// <param name="id">ID of pet to return</param>
        /// <returns>successful operation</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        public ApiException? TryGetPetById(long id, out Pet? pet)
        {
            try
            {
                pet = _petStore3NSwagClient.GetPetByIdAsync(id).Result;
                return null;
            }
            catch (AggregateException exeption)
            {
                pet = null;
                return exeption.InnerExceptions.FirstOrDefault() as ApiException;
            }
            catch (Exception exeption)
            {
                throw new XunitException(exeption.Message);
            }
        }
        #endregion

        //Access to Petstore orders
        #region store

        #endregion

        //Operations about user
        #region user

        #endregion
    }
}
