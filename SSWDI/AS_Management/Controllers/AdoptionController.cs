using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using AS_Core.DomainModel;
using AS_DomainServices.Services;
using AS_Identity;
using AS_Management.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace AS_Management.Controllers
{
    public class AdoptionController : Controller
    {
        private readonly IAnimalService _animalService;
        private readonly IUserService _userService;
        private readonly IStayService _stayService;

        private readonly UserManager<ApplicationUser> _userManager;

        public AdoptionController(IAnimalService animalService, IUserService userService, 
            IStayService stayService, UserManager<ApplicationUser> userManager)
        {
            _animalService = animalService;
            _userService = userService;
            _stayService = stayService;
            _userManager = userManager;
        }

        [HttpGet]
        [Route("Adopt/{AnimalID:int}")]
        public IActionResult Adopt(int AnimalID)
        {
            //Get user name
            var userName = User.FindFirstValue(ClaimTypes.Name);
            User user = _userService.FindByUsername(userName);

            var vm = new AdoptionViewModel
             {
                Animal = _animalService.FindByID(AnimalID),
                Stay = _stayService.FindRelatedStay(AnimalID),
                User = user
            };

            return View(vm);
        }

        [HttpPost]
        [Route("Adopt/{AnimalID:int}")]
        [ValidateAntiForgeryToken]
        public IActionResult Adopt(AdoptionViewModel AdoptionViewModel)
        {
            try
            {
                Console.WriteLine(AdoptionViewModel);
                Stay stay = _stayService.FindByID(AdoptionViewModel.Stay.ID);
                Animal animal = _animalService.FindByID(AdoptionViewModel.Animal.ID);

                stay.AdoptedBy = AdoptionViewModel.User.Email;
                stay.Animal = animal;
                stay.AdoptionDate = DateTime.Now;

                _stayService.AdoptAnimal(stay);

                return Redirect("/Stay/Index");
            }
            catch (Exception e)
            {
                Console.WriteLine("Error occured" + e); // TODO: use logger service for this
            }

            return Redirect("/Stay/Index");
        }
    }
}
