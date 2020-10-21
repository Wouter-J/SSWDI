using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AS_Core.DomainModel;
using AS_DomainServices.Repositories;
using AS_DomainServices.Services;
using AS_EFShelterData;
using AS_Management.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace AS_Management.Controllers
{
    public class AnimalController : Controller
    {
        private readonly IAnimalService _animalService;
        private readonly ILodgingService _lodgingService;

        /// <summary>
        /// Initializes a new instance of the <see cref="AnimalController"/> class.
        /// </summary>
        /// <param name="animalRepository"></param>
        public AnimalController(IAnimalService animalService, ILodgingService lodgingService)
        {
            _animalService = animalService;
            _lodgingService = lodgingService;
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

        // POST: Animals/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        // public async Task<IActionResult> Create([Bind("ID,Name,Birthdate,Age,EstimatedAge,Description,AnimalType,Race,Gender,Picture,DateOfDeath,Castrated,ChildFriendly,ReasonGivenAway")] Animal animal)
    }
}
