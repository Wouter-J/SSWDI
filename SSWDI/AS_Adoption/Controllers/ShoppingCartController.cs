using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AS_Adoption.ViewModels;
using AS_Core.DomainModel;
using AS_HttpData;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace AS_Adoption.Controllers
{

    [Authorize(Policy = "VolunteerOrCustomer")]
    public class ShoppingCartController : Controller
    {
        private readonly IConfiguration _configuration;
        private string apiBaseUrl = "";
        private readonly InterestHttpService interestHttpService = new InterestHttpService();
        private readonly AnimalHttpService animalHttpService = new AnimalHttpService();

        public ShoppingCartController(IConfiguration configuration)
        {
            _configuration = configuration;
            apiBaseUrl = _configuration.GetValue<string>("WebAPIBaseUrl");
        }

        public async Task<IActionResult> Index()
        {
            System.Security.Claims.ClaimsPrincipal currentUser = this.User;

            IEnumerable<InterestedAnimal> interestList = await interestHttpService.GetInterestedAnimal(currentUser);

            return View(interestList);
        }

        [HttpGet]
        [Route("Create/{AnimalID:int}")]
        public async Task<IActionResult> Create(int AnimalID)
        {
            System.Security.Claims.ClaimsPrincipal currentUser = this.User;

            Animal animal = await animalHttpService.HttpGetByID(AnimalID);
            var vm = new InterestViewModel
            {
                Animal = animal
            };

            return View(vm);
        }

        [HttpPost]
        [Route("Create/{AnimalID:int}")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(InterestViewModel interest)
        {
            System.Security.Claims.ClaimsPrincipal currentUser = this.User;
            Animal animal = await animalHttpService.HttpGetByID(interest.Animal.ID);
            try
            {
                await interestHttpService.ShowInterest(animal, currentUser);
            } catch (InvalidOperationException e)
            {
                ViewBag.Message = "Already displayed interest in this animal";
                return View(interest);
            }

            ViewBag.Message = "Interest added";
            return View(interest);
        }

        public async Task<IActionResult> Delete(int ID)
        {
            Animal animal = await animalHttpService.HttpGetByID(ID);

            return View(animal);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int ID)
        {
            System.Security.Claims.ClaimsPrincipal currentUser = this.User;
            Animal animal = await animalHttpService.HttpGetByID(ID);
            await interestHttpService.RemoveInterest(animal, currentUser);

            return View();
        }
    }
}
