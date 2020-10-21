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
        private readonly IStayService _stayService;
        private readonly IAnimalService _animalService;

        private readonly ILodgingService _lodgingService;

        /// <summary>
        /// Initializes a new instance of the <see cref="StayController"/> class.
        /// </summary>
        /// <param name="stayRepository"></param>
        public StayController(IStayService stayRepository, IAnimalService animalService)
        {
            _stayService = stayRepository;
            _animalService = animalService;
        }

        public IActionResult Index()
        {
            // TODO create custom viewModel
            var vm = new StayViewModel()
            {
                Stays = _stayService.GetAll().ToList(),
                Animals = _animalService.GetAll().ToList()
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
            // TODO: Add better ViewModel
            Stay stay = _stayService.FindByID(ID);
            return View(stay);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Stay stay)
        {
            if (ModelState.IsValid)
            {
                _stayService.SaveStay(stay);
                return RedirectToAction(nameof(Index));
            }

            return View(stay);
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
