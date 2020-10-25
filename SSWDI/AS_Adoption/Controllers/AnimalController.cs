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
    public class AnimalController : Controller
    {
        private readonly IConfiguration _configuration;
        private string apiBaseUrl = "";

        public AnimalController(IConfiguration configuration)
        {
            _configuration = configuration;
            apiBaseUrl = _configuration.GetValue<string>("WebAPIBaseUrl");
        }

        public async Task<IActionResult> Index()
        {
            List<Animal> animalList = new List<Animal>();

            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync(apiBaseUrl + "/animal"))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    animalList = JsonConvert.DeserializeObject<List<Animal>>(apiResponse);
                }
            }

            return View(animalList);
        }

        //Create (Put up for adoption)
               //Name, animaltype (Dog/Cat), Gender, Castration & Reason
               //Check if any lodging has spaces before placement is allowed

    }
}
