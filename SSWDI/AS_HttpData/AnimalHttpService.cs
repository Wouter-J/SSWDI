using AS_Core.DomainModel;
using AS_Core.Filters;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;

namespace AS_HttpData
{
    // TODO: Re-Do & Cleanup if possible
    public class AnimalHttpService
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

    }
}
