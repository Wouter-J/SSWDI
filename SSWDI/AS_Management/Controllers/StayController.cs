using System;
using System.Linq;
using AS_Core.DomainModel;
using AS_DomainServices.Services;
using AS_Management.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace AS_Management.Controllers
{
    public class StayController : Controller
    {
        private readonly IStayService _stayService;
        private readonly IAnimalService _animalService;

        private readonly ILodgingService _lodgingService;

        /// <summary>
        /// Initializes a new instance of the <see cref="StayController"/> class.
        /// </summary>
        /// <param name="stayRepository"></param>
        public StayController(IStayService stayService, IAnimalService animalService, ILodgingService lodgingService)
        {
            _stayService = stayService;
            _animalService = animalService;
            _lodgingService = lodgingService;
        }

        public IActionResult Index()
        {
            var vm = new StayViewModel()
            {
                Stays = _stayService.GetAll().ToList(),
                Animals = _animalService.GetAll().ToList(),
                Lodges = _lodgingService.GetAll().ToList()
            };

            return View(vm);
        }

        [HttpGet]
        public IActionResult Details(int ID)
        {
            Stay stay = _stayService.FindByID(ID);
            return View(stay);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Stay stay)
        {
            if (ModelState.IsValid)
            {
                _stayService.Add(stay);
                return RedirectToAction(nameof(Index));
            }

            return View(stay);
        }

        [HttpGet]
        public IActionResult Edit(int ID)
        {
            var stay = _stayService.FindByID(ID);
            var vm = new StayViewModel()
            {
                Lodges = _lodgingService.ReturnAvailableLocations(stay.AnimalID), // Only get lodges with proper type & those that have space left.
                Stay = stay,
                CurrentLodge = _lodgingService.FindByID(stay.LodgingLocationID),
                Animal = _animalService.FindByID(stay.AnimalID)
            };

            return View(vm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(StayViewModel stayViewModel)
        {
            try
            {
                // TODO: Move this to Service layer
                stayViewModel.Animal = _animalService.FindByID(stayViewModel.Animal.ID);
                stayViewModel.Lodge = _lodgingService.FindByID(stayViewModel.Lodge.ID);

                Lodging currentLodge = _lodgingService.FindByID(stayViewModel.CurrentLodge.ID);
                Stay Stay = stayViewModel.Stay;
                Lodging Lodge = stayViewModel.Lodge;

                // If animal moved
                if (currentLodge.ID != Lodge.ID)
                {
                    // Decrease capacity at old lodge
                    currentLodge.CurrentCapacity--; // TODO: make this calc work

                    // Increase capacity at new lodge
                    Lodge.CurrentCapacity++;

                    currentLodge.Stays.Remove(Stay);

                    _lodgingService.SaveLodging(currentLodge);
                }

                // Animal & Lodge update
                Stay.Animal = stayViewModel.Animal;
                Lodge.Stays.Add(Stay);

                _lodgingService.SaveLodging(Lodge);
                _stayService.SaveStay(Stay);

                return RedirectToAction(nameof(Index));
            }
            catch (Exception e)
            {
                Console.WriteLine("Error: " + e); // TODO: Change this to logger service
            }

            return View(stayViewModel);
        }

        // GET: Stays/Delete/5
        public IActionResult Delete(int ID)
        {
            Stay stay = _stayService.FindByID(ID);
            return View(stay);
        }

        // POST: Stays/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int ID)
        {
            // TODO: Add validation
            Stay stay = _stayService.FindByID(ID);
            _stayService.Remove(stay);
            return RedirectToAction(nameof(Index));
        }

        // POST: Stays/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        // public async Task<IActionResult> Create([Bind("ID,Name,Birthdate,Age,EstimatedAge,Description,StayType,Race,Gender,Picture,DateOfDeath,Castrated,ChildFriendly,ReasonGivenAway")] Stay stay)
    }
}
