using AS_Core.DomainModel;
using AS_Core.Filters;
using AS_DomainHttpService;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;

namespace AS_HttpData
{
    // TODO: Re-Do & Cleanup if possible
    public class StayHttpRepository : IStayHttpService
    {
        private string apiBaseUrl = "https://localhost:44301";
        
        public async Task<IEnumerable<Stay>> HandleFilter(AnimalFilter filter)
        {
            IEnumerable<Stay> stayList = new List<Stay>();

            using (var httpClient = new HttpClient())
            {
                var builder = new UriBuilder(apiBaseUrl + "/api/stay");
                var query = HttpUtility.ParseQueryString(builder.Query);
                query["AnimalType"] = filter.AnimalType.ToString();
                query["ChildFriendly"] = filter.ChildFriendly.ToString();
                query["Gender"] = filter.Gender.ToString();
                query["CanBeAdopted"] = true.ToString();
                builder.Query = query.ToString();
                string url = builder.ToString();

                using (var response = await httpClient.GetAsync(url))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    stayList = JsonConvert.DeserializeObject<List<Stay>>(apiResponse);
                }

                return stayList;
            }
        }
        
    }
}
