using System;
using System.Collections.Generic;
using System.Linq;
using AS_Core.DomainModel;
using AS_DomainServices;
using AS_DomainServices.Repositories;
using AS_DomainServices.Services;
using AS_Management.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace AS_Management.Controllers
{
    public class StayController : Controller
    {
        //TODO: Use services instead of repo's
        private IStayRepository _stayRepository;
        private IAnimalRepository _animalRepository;

        private readonly ILodgingService _lodgingService;

        /// <summary>
        /// Initializes a new instance of the <see cref="StayController"/> class.
        /// </summary>
        /// <param name="stayRepository"></param>
        public StayController(IStayRepository stayRepository, IAnimalRepository animalRepository)
        {
            _stayRepository = stayRepository;
            _animalRepository = animalRepository;
        }

        public IActionResult Index()
        {
            // TODO create custom viewModel
            var vm = new StayViewModel()
            {
                Stays = _stayRepository.GetAll().ToList(),
                Animals = _animalRepository.GetAll().ToList()
            };

            return View(vm);
        }

        [HttpGet]
        public IActionResult Details(int ID)
        {
            Stay stay = _stayRepository.FindByID(ID);
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
                _stayRepository.Add(stay);
                return RedirectToAction(nameof(Index));
            }

            return View(stay);
        }

        [HttpGet]
        public IActionResult Edit(int ID)
        {
            // TODO: Add better ViewModel
            Stay stay = _stayRepository.FindByID(ID);
            return View(stay);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Stay stay)
        {
            if (ModelState.IsValid)
            {
                _stayRepository.SaveStay(stay);
                return RedirectToAction(nameof(Index));
            }

            return View(stay);
        }

        // GET: Stays/Delete/5
        public IActionResult Delete(int ID)
        {
            Stay stay = _stayRepository.FindByID(ID);
            return View(stay);
        }

        // POST: Stays/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int ID)
        {
            // TODO: Add validation
            Stay stay = _stayRepository.FindByID(ID);
            _stayRepository.Remove(stay);
            return RedirectToAction(nameof(Index));
        }

        // POST: Stays/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        // public async Task<IActionResult> Create([Bind("ID,Name,Birthdate,Age,EstimatedAge,Description,StayType,Race,Gender,Picture,DateOfDeath,Castrated,ChildFriendly,ReasonGivenAway")] Stay stay)
    }
}
