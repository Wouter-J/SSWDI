using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using AS_Adoption.ViewModels;
using AS_Core.DomainModel;
using AS_Core.Filters;
using AS_DomainServices.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;

namespace AS_Adoption.Controllers
{
    public class StayController : Controller
    {
        private readonly IConfiguration _configuration;
        private string apiBaseUrl = "";

        public StayController(IConfiguration configuration)
        {
            _configuration = configuration;
            apiBaseUrl = _configuration.GetValue<string>("WebAPIBaseUrl");
        }

        public async Task<IActionResult> IndexAsync([FromQuery] AnimalFilter animalFilters)
        {
            var vm = new StayViewModel();

            using (var httpClient = new HttpClient())
            {
                // TODO: Fix this
                using (var response = await httpClient.GetAsync(apiBaseUrl + "/api/stay?" + animalFilters))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    vm.Stays = JsonConvert.DeserializeObject<List<Stay>>(apiResponse);
                }
            }

            return View(vm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Filter(StayViewModel stay)
        {
            AnimalFilter filter = new AnimalFilter
            {
                AnimalType = stay.AnimalType,
                Gender = stay.Gender,
                ChildFriendly = stay.ChildFriendly
            };

            var vm = new StayViewModel();

            using (var httpClient = new HttpClient())
            {
                var builder = new UriBuilder(apiBaseUrl + "/api/stay");
                var query = HttpUtility.ParseQueryString(builder.Query);
                query["AnimalType"] = stay.AnimalType.ToString();
                query["Gender"] = stay.Gender.ToString();
                query["ChildFriendly"] = stay.ChildFriendly.ToString();
                builder.Query = query.ToString();
                string url = builder.ToString();
                
                // TODO: Fix this
                using (var response = await httpClient.GetAsync(url))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    vm.Stays = JsonConvert.DeserializeObject<List<Stay>>(apiResponse);
                }
            }

            return View("Views/Stay/Index.cshtml", vm);
        }

        //List available adoptions (get link with animal)

        // Show interest (Add to UserList & Keep it as a reference. Max 3)

    }
}
