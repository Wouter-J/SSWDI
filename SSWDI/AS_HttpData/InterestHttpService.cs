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
    public class InterestHttpService
    {
        private string apiBaseUrl = "https://localhost:44301";

        public async Task<IEnumerable<InterestedAnimal>> HttpIndex()
        {
            List<InterestedAnimal> interestList = new List<InterestedAnimal>();

            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync(apiBaseUrl + "/api/interest"))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    interestList = JsonConvert.DeserializeObject<List<InterestedAnimal>>(apiResponse);
                }
            }

            return interestList;
        }

        public async Task<IEnumerable<InterestedAnimal>> GetInterestedAnimal(System.Security.Claims.ClaimsPrincipal currentUser)
        {
            List<InterestedAnimal> interestList = new List<InterestedAnimal>();

            using (var httpClient = new HttpClient())
            {
                // TODO: Find cleaner way to do this
                var builder = new UriBuilder(apiBaseUrl + "/api/interest");
                var query = HttpUtility.ParseQueryString(builder.Query);
                query["User"] = currentUser.Identity.Name;
                builder.Query = query.ToString();
                string url = builder.ToString();

                using (var response = await httpClient.GetAsync(url))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    interestList = JsonConvert.DeserializeObject<List<InterestedAnimal>>(apiResponse);
                }
            }

            return interestList;
        }
    }
}
