using AS_Core.DomainModel;
using AS_Core.Filters;
using AS_DomainHttpService;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace AS_HttpData
{
    public class AnimalHttpRepository : IAnimalHttpService
    {
        private string apiBaseUrl = "https://localhost:44301";

        public async Task<IEnumerable<Animal>> HttpIndex()
        {
            List<Animal> animalList = new List<Animal>();

            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync(apiBaseUrl + "/api/animal"))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    animalList = JsonConvert.DeserializeObject<List<Animal>>(apiResponse);
                }
            }

            return animalList;
        }

        public async Task<Animal> HttpGetByID(int ID)
        {
            Animal animal = new Animal();

            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync(apiBaseUrl + "/api/animal/" + ID))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    animal = JsonConvert.DeserializeObject<Animal>(apiResponse);
                }
            }

            return animal;
        }

        public async Task<Animal> Add(Animal animal)
        {
            try
            {
                Animal recievedAnimal = new Animal();

                using (var httpClient = new HttpClient())
                {
                    // Transform our object to JSON
                    StringContent content = new StringContent(JsonConvert.SerializeObject(animal), Encoding.UTF8, "application/json");

                    using (var response = await httpClient.PostAsync(apiBaseUrl + "/api/animal", content))
                    {
                        string apiResponse = await response.Content.ReadAsStringAsync();
                        recievedAnimal = JsonConvert.DeserializeObject<Animal>(apiResponse);
                    }
                }

                return recievedAnimal;
            } catch (Exception e)
            {
                throw e;
            }
        }

        public async Task<IEnumerable<Animal>> GetInterestedAnimal(System.Security.Claims.ClaimsPrincipal currentUser)
        {
            List<Animal> animalList = new List<Animal>();

            using (var httpClient = new HttpClient())
            {
                // TODO: Find cleaner way to do this
                var builder = new UriBuilder(apiBaseUrl + "/api/animal");
                var query = HttpUtility.ParseQueryString(builder.Query);
                query["User"] = currentUser.Identity.Name;
                builder.Query = query.ToString();
                string url = builder.ToString();

                using (var response = await httpClient.GetAsync(url))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    animalList = JsonConvert.DeserializeObject<List<Animal>>(apiResponse);
                }
            }

            return animalList;
        }

    }
}
