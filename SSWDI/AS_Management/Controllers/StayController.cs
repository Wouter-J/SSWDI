using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using AS_Core.DomainModel;
using AS_DomainServices;

namespace AS_Management.Controllers
{
    public class StayController : Controller
    {
        private IStayRepository _stayRepository;

        public StayController(IStayRepository stayRepository)
        {
            _stayRepository = stayRepository;
        }

        public IActionResult Index()
        {
            // TODO create custom viewModel
            return View(_stayRepository.GetAll().ToList());
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
