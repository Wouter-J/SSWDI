using AS_Core.DomainModel;
using AS_Core.Filters;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
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

        public async Task<InterestedAnimal> FindInterest(Animal animal, System.Security.Claims.ClaimsPrincipal currentUser)
        {
            InterestedAnimal foundInterest = new InterestedAnimal();

            using (var httpClient = new HttpClient())
            {
                var builder = new UriBuilder(apiBaseUrl + "/api/interest/" + animal.ID);
                var query = HttpUtility.ParseQueryString(builder.Query);
                query["userName"] = currentUser.Identity.Name;
                builder.Query = query.ToString();
                string url = builder.ToString();

                using (var response = await httpClient.GetAsync(url))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    foundInterest = JsonConvert.DeserializeObject<InterestedAnimal>(apiResponse);
                }
            }

            return foundInterest;
        }

        public async Task<IEnumerable<InterestedAnimal>> GetInterestedAnimal(System.Security.Claims.ClaimsPrincipal currentUser)
        {
            List<InterestedAnimal> interestList = new List<InterestedAnimal>();

            using (var httpClient = new HttpClient())
            {
                // TODO: Find cleaner way to do this
                var builder = new UriBuilder(apiBaseUrl + "/api/interest");
                var query = HttpUtility.ParseQueryString(builder.Query);
                query["userName"] = currentUser.Identity.Name;
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

        public async Task<User> GetUserByHttp(System.Security.Claims.ClaimsPrincipal currentUser)
        {
            User user = new User();
            using (var httpClient = new HttpClient())
            {
                // TODO: Find cleaner way to do this
                var builder = new UriBuilder(apiBaseUrl + "/api/user/name");
                var query = HttpUtility.ParseQueryString(builder.Query);
                query["userName"] = currentUser.Identity.Name;
                builder.Query = query.ToString();
                string url = builder.ToString();

                using (var response = await httpClient.GetAsync(url))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    user = JsonConvert.DeserializeObject<User>(apiResponse);
                }
            }

            return user;
        }

        public async Task<InterestedAnimal> ShowInterest(Animal animal, System.Security.Claims.ClaimsPrincipal currentUser)
        {
            InterestedAnimal interstedAnimal = new InterestedAnimal();
            User user = await GetUserByHttp(currentUser);

            using (var httpClient = new HttpClient())
            {
                // TODO: Find cleaner way to do this
                var builder = new UriBuilder(apiBaseUrl + "/api/interest");
                var query = HttpUtility.ParseQueryString(builder.Query);
                builder.Query = query.ToString();
                string url = builder.ToString();

                InterestedAnimal interest = new InterestedAnimal
                {
                    Animal = animal,
                    AnimalID = animal.ID,
                    UserID = user.ID,
                    User = user
                };

                var stringContent = new StringContent(JsonConvert.SerializeObject(interest), Encoding.UTF8, "application/json");
                stringContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");
                try
                {
                    using (var response = await httpClient.PostAsync(url, stringContent))
                    {
                        string apiResponse = await response.Content.ReadAsStringAsync();
                        if (response.ReasonPhrase == "Bad Request")
                        {
                            throw new InvalidOperationException("Interest already shown");
                        }
                        var res = response.Content.ReadAsStringAsync().Result;
                        interstedAnimal = JsonConvert.DeserializeObject<InterestedAnimal>(apiResponse);
                    }
                }
                catch (Exception e)
                {
                    throw e;
                }

            }

            return interstedAnimal;
        }

        public async Task<InterestedAnimal> RemoveInterest(Animal animal, System.Security.Claims.ClaimsPrincipal currentUser)
        {
            InterestedAnimal interest = await FindInterest(animal, currentUser); 
            using (var httpClient = new HttpClient())
            {
                var builder = new UriBuilder(apiBaseUrl + "/api/interest/" + interest.ID);
                var query = HttpUtility.ParseQueryString(builder.Query);
                builder.Query = query.ToString();
                string url = builder.ToString();

                var stringContent = new StringContent(JsonConvert.SerializeObject(interest), Encoding.UTF8, "application/json");
                stringContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");
                try
                {
                    using (var response = await httpClient.PostAsync(url, stringContent))
                    {
                        string apiResponse = await response.Content.ReadAsStringAsync();
                        if (response.ReasonPhrase == "Bad Request")
                        {
                            throw new InvalidOperationException("Interest already shown");
                        }
                        var res = response.Content.ReadAsStringAsync().Result;
                    }
                }
                catch (Exception e)
                {
                    throw e;
                }
            }

            return interest;
        }
    }
}
