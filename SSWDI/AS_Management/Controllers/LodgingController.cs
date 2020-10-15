using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using AS_Core.DomainModel;
using AS_DomainServices;

namespace AS_Management.Controllers
{
    public class LodgingController : Controller
    {
        private ILodgingRepository _lodgingRepository;

        public LodgingController(ILodgingRepository lodgingRepository)
        {
            _lodgingRepository = lodgingRepository;
        }

        public IActionResult Index()
        {
            //TODO create custom viewModel
            return View(_lodgingRepository.GetAll().ToList());
        }

        [HttpGet]
        public IActionResult Details(int ID)
        {
            Lodging lodging = _lodgingRepository.FindByID(ID);
            return View(lodging);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Lodging lodging)
        {
            if (ModelState.IsValid)
            {
                _lodgingRepository.Add(lodging);
                return RedirectToAction(nameof(Index));
            }
            return View(lodging);
        }

        [HttpGet]
        public IActionResult Edit(int ID)
        {
            //TODO: Add better ViewModel
            Lodging lodging = _lodgingRepository.FindByID(ID);
            return View(lodging);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Lodging lodging)
        {
            if (ModelState.IsValid)
            {
                _lodgingRepository.SaveLodging(lodging);
                return RedirectToAction(nameof(Index));
            }
            else
            {
                return View(lodging);
            }
        }

        // GET: Lodgings/Delete/5
        public IActionResult Delete(int ID)
        {
            Lodging lodging = _lodgingRepository.FindByID(ID);
            return View(lodging);
        }

        // POST: Lodgings/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int ID)
        {
            //TODO: Add validation
            Lodging lodging = _lodgingRepository.FindByID(ID);
            _lodgingRepository.Remove(lodging);
            return RedirectToAction(nameof(Index));
        }

        // POST: Lodgings/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        // public async Task<IActionResult> Create([Bind("ID,Name,Birthdate,Age,EstimatedAge,Description,LodgingType,Race,Gender,Picture,DateOfDeath,Castrated,ChildFriendly,ReasonGivenAway")] Lodging lodging)

    }
}
