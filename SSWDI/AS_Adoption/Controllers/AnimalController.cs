using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using AS_Core.DomainModel;
using AS_HttpData;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;

namespace AS_Adoption.Controllers
{
    public class AnimalController : Controller
    {
        private readonly IConfiguration _configuration;
        private string apiBaseUrl = "";
        private readonly AnimalHttpService animalHttpService = new AnimalHttpService();

        public AnimalController(IConfiguration configuration)
        {
            _configuration = configuration;
            apiBaseUrl = _configuration.GetValue<string>("WebAPIBaseUrl");
        }

        public async Task<IActionResult> Index()
        {
            // List<Animal> animalList = new List<Animal>();
            // Move to seperate repository; use seperate repository project
            // HttpRepositry getAll();
            IEnumerable<Animal> animalList = await animalHttpService.HttpIndex();

            return View(animalList);
        }

        [HttpGet]
        //[Authorize(Policy = "RequireCustomer")]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        //[Authorize(Policy = "RequireCustomer")]
        public async Task<IActionResult> Create(Animal animal)
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

            return View(recievedAnimal);
        }
    }
}
