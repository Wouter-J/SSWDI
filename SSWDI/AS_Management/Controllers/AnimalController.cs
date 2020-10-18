using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AS_Core.DomainModel;
using AS_EFShelterData;
using AS_DomainServices.Repositories;
using AS_DomainServices.Services;

namespace AS_Management.Controllers
{
    public class AnimalController : Controller
    {
        private readonly IAnimalService _animalRepository;

        public AnimalController(IAnimalService animalRepository)
        {
            _animalRepository = animalRepository;
        }

        public IActionResult Index()
        {
            //TODO create custom viewModel
            return View(_animalRepository.GetAll());
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
                _animalRepository.Add(animal);
                return RedirectToAction(nameof(Index));
            }
            return View(animal);
        }

        [HttpGet]
        public IActionResult Details(int ID)
        {
            Animal animal = _animalRepository.FindByID(ID);
            return View(animal);
        }

        [HttpGet]
        public IActionResult Edit(int ID)
        {
            //TODO: Add better ViewModel
            Animal animal = _animalRepository.FindByID(ID);
            return View(animal);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Animal animal)
        {
            if (ModelState.IsValid) {
                _animalRepository.SaveAnimal(animal);
                return RedirectToAction(nameof(Index));
            }
            return View(animal);
        }

        // GET: Animals/Delete/5
        public IActionResult Delete(int ID)
        {
            Animal animal = _animalRepository.FindByID(ID);
            return View(animal);
        }

        // POST: Animals/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int ID)
        {
            //TODO: Add validation
            Animal animal = _animalRepository.FindByID(ID);
            _animalRepository.Remove(animal);
            return RedirectToAction(nameof(Index));
        }

        // POST: Animals/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        // public async Task<IActionResult> Create([Bind("ID,Name,Birthdate,Age,EstimatedAge,Description,AnimalType,Race,Gender,Picture,DateOfDeath,Castrated,ChildFriendly,ReasonGivenAway")] Animal animal)

    }
}
