using System;
using AS_Core.DomainModel;
using AS_DomainServices.Services;
using AS_Management.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AS_Management.Controllers
{
    [Authorize(Policy = "RequireCustomer")]
    public class AnimalController : Controller
    {
        private readonly IAnimalService _animalService;
        private readonly ILodgingService _lodgingService;
        private readonly IStayService _stayService;

        /// <summary>
        /// Initializes a new instance of the <see cref="AnimalController"/> class.
        /// </summary>
        /// <param name="animalService"></param>
        public AnimalController(IAnimalService animalService, ILodgingService lodgingService, IStayService stayService)
        {
            _animalService = animalService;
            _lodgingService = lodgingService;
            _stayService = stayService;
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
        public IActionResult Create(Animal animal)
        {
            if (ModelState.IsValid)
            {
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
        public IActionResult Edit(Animal animal)
        {
            if (ModelState.IsValid)
            {
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
                Animal = _animalService.FindByID(ID)
            };

            return View(vm);
        }

        [HttpPost]
        public IActionResult PlaceAnimal(AnimalViewModel animalViewModel)
        {
            try
            {
                // TODO: Move this to Service layer
                animalViewModel.Animal = _animalService.FindByID(animalViewModel.Animal.ID);
                animalViewModel.Lodge = _lodgingService.FindByID(animalViewModel.Lodge.ID);

                Stay stay = animalViewModel.Stay;
                Lodging lodge = animalViewModel.Lodge;

                // Update capacity with the new animal.
                lodge.CurrentCapacity = lodge.CurrentCapacity++;

                // Add Animal to Animal list in Stay
                stay.Animal = animalViewModel.Animal;

                // Add stay to lodge
                lodge.Stays.Add(stay);

                _lodgingService.SaveLodging(lodge);
                _stayService.SaveStay(stay);

                return RedirectToAction(nameof(Index));
            }
            catch (Exception e)
            {
                Console.Write("Error: " + e); // TODO: Change this to logger service
            }

            return View(animalViewModel);
        }

        // POST: Animals/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        // public async Task<IActionResult> Create([Bind("ID,Name,Birthdate,Age,EstimatedAge,Description,AnimalType,Race,Gender,Picture,DateOfDeath,Castrated,ChildFriendly,ReasonGivenAway")] Animal animal)
    }
}
