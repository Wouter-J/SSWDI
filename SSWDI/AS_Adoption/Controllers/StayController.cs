using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using AS_Core.DomainModel;
using AS_WebService.Filters;
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

        public async Task<IActionResult> IndexAsync([FromQuery] AnimalFilters animalFilters)
        {
            List<Stay> stayList = new List<Stay>();
            animalFilters.CanBeAdopted = true;
            Console.WriteLine(animalFilters);

            using (var httpClient = new HttpClient())
            {
                // TODO: Fix this
                using (var response = await httpClient.GetAsync(apiBaseUrl + "/api/stay?" + animalFilters))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    stayList = JsonConvert.DeserializeObject<List<Stay>>(apiResponse);
                }
            }

            return View(stayList);
        }

        //List available adoptions (get link with animal)

        // Show interest (Add to UserList & Keep it as a reference. Max 3)

    }
}
