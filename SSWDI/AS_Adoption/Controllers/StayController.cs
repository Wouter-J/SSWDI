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
using AS_HttpData;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;

namespace AS_Adoption.Controllers
{
    public class StayController : Controller
    {
        private readonly IConfiguration _configuration;
        private string apiBaseUrl = "";
        private readonly StayHttpRepository _stayHttpService = new StayHttpRepository();

        public StayController(IConfiguration configuration)
        {
            _configuration = configuration;
            apiBaseUrl = _configuration.GetValue<string>("WebAPIBaseUrl");
        }

        public async Task<IActionResult> IndexAsync([FromQuery] AnimalFilter animalFilters)
        {
            var vm = new StayViewModel();

            vm.Stays = await _stayHttpService.HandleFilter(animalFilters);

            return View(vm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Filter(StayViewModel stay)
        {
            var vm = new StayViewModel();

            AnimalFilter filter = new AnimalFilter
            {
                Gender = stay.Animal.Gender,
                AnimalType = stay.Animal.AnimalType,
                ChildFriendly = stay.Animal.ChildFriendly,
                CanBeAdopted = true
            };

            vm.Stays = await _stayHttpService.HandleFilter(filter);

            return View("Views/Stay/Index.cshtml", vm);
        }
    }
}
