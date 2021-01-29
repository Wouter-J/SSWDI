using System;
using System.IO;
using System.Threading.Tasks;
using AS_Core.DomainModel;
using AS_DomainServices.Services;
using AS_Management.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;

namespace AS_Management.Controllers
{
    [Authorize(Policy = "RequireVolunteer")]
    public class AnimalController : Controller
    {
        private readonly IAnimalService _animalService;
        private readonly ILodgingService _lodgingService;
        private readonly IStayService _stayService;
        private readonly IWebHostEnvironment _hostEnvironment;

        /// <summary>
        /// Initializes a new instance of the <see cref="AnimalController"/> class.
        /// </summary>
        /// <param name="animalService"></param>
        public AnimalController(IAnimalService animalService, ILodgingService lodgingService, IStayService stayService, IWebHostEnvironment hostEnvironment)
        {
            _animalService = animalService;
            _lodgingService = lodgingService;
            _stayService = stayService;
            _hostEnvironment = hostEnvironment;
        }

        public IActionResult Index()
        {
            // TODO create custom viewModel
            return View(_animalService.GetAll());
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Animal animal)
        {
            if (ModelState.IsValid)
            {
                if (animal.ImageFile != null)
                {
                    // We need the wwwRootPath which is relative to the project, not the specific service.
                    string wwwRootPath = _hostEnvironment.WebRootPath;
                    animal.ImageName = await _animalService.SaveImage(animal, wwwRootPath);
                }
                _animalService.Add(animal);

                return RedirectToAction(nameof(Index));
            }

            return View(animal);
        }

        [HttpGet]
        public IActionResult Details(int ID)
        {
            Animal animal = _animalService.FindByID(ID);
            return View(animal);
        }

        [HttpGet]
        public IActionResult Edit(int ID)
        {
            // TODO: Add better ViewModel
            Animal animal = _animalService.FindByID(ID);
            return View(animal);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Animal animal)
        {
            if (ModelState.IsValid)
            {
                if (animal.ImageFile != null)
                {
                    // We need the wwwRootPath which is relative to the project, not the specific service.
                    string wwwRootPath = _hostEnvironment.WebRootPath;
                    _animalService.RemoveImage(animal, wwwRootPath);
                    animal.ImageName = await _animalService.SaveImage(animal, wwwRootPath);
                }
                _animalService.SaveAnimal(animal);
                return RedirectToAction(nameof(Index));
            }

            return View(animal);
        }

        // GET: Animals/Delete/5
        public IActionResult Delete(int ID)
        {
            Animal animal = _animalService.FindByID(ID);
            return View(animal);
        }

        // POST: Animals/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int ID)
        {
            // TODO: Add validation
            Animal animal = _animalService.FindByID(ID);
            string wwwRootPath = _hostEnvironment.WebRootPath;
            _animalService.RemoveImage(animal, wwwRootPath);

            _animalService.Remove(animal);
            return RedirectToAction(nameof(Index));
        }

        /// <summary>
        /// Add animal to a Stay; LodgeLocation is added as well.
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        [HttpGet]
        public IActionResult PlaceAnimal(int ID)
        {
            var vm = new AnimalViewModel()
            {
                Lodgings = _lodgingService.ReturnAvailableLocations(ID), // Only get lodges with proper type & those that have space left.
                Animal = _animalService.FindByID(ID),
                Stay = _stayService.FindByID(ID),
                Lodge = _lodgingService.FindByID(ID)
            };

            return View(vm);
        }

        [HttpPost]
        public IActionResult PlaceAnimal(AnimalViewModel animalViewModel)
        {
            try
            {
                animalViewModel.Stay.AnimalID = animalViewModel.Animal.ID;
                _stayService.PlaceAnimal(animalViewModel.Stay, animalViewModel.Lodge);

                return RedirectToAction(nameof(Index));
            }
            catch (Exception e)
            {
                ViewBag.Message = "Error: " + e.Message;
                return PlaceAnimal(animalViewModel.Animal.ID);
            }
        }
    }
}
