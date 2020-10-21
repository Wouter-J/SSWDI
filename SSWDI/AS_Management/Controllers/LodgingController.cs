using System;
using System.Collections.Generic;
using System.Linq;
using AS_Core.DomainModel;
using AS_DomainServices.Services;
using Microsoft.AspNetCore.Mvc;

namespace AS_Management.Controllers
{
    public class LodgingController : Controller
    {
        private readonly ILodgingService _lodgingService;

        /// <summary>
        /// Initializes a new instance of the <see cref="LodgingController"/> class.
        /// </summary>
        /// <param name="lodgingRepository"></param>
        public LodgingController(ILodgingService lodgingService)
        {
            _lodgingService = lodgingService;
        }

        public IActionResult Index()
        {
            // TODO create custom viewModel
            return View(_lodgingService.GetAll().ToList());
        }

        [HttpGet]
        public IActionResult Details(int ID)
        {
            Lodging lodging = _lodgingService.FindByID(ID);
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
                _lodgingService.Add(lodging);
                return RedirectToAction(nameof(Index));
            }

            return View(lodging);
        }

        [HttpGet]
        public IActionResult Edit(int ID)
        {
            // TODO: Add better ViewModel
            Lodging lodging = _lodgingService.FindByID(ID);
            return View(lodging);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Lodging lodging)
        {
            if (ModelState.IsValid)
            {
                _lodgingService.SaveLodging(lodging);
                return RedirectToAction(nameof(Index));
            }

            return View(lodging);
        }

        // GET: Lodgings/Delete/5
        public IActionResult Delete(int ID)
        {
            Lodging lodging = _lodgingService.FindByID(ID);
            return View(lodging);
        }

        // POST: Lodgings/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int ID)
        {
            // TODO: Add validation
            Lodging lodging = _lodgingService.FindByID(ID);
            _lodgingService.Remove(lodging);
            return RedirectToAction(nameof(Index));
        }

        // POST: Lodgings/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        // public async Task<IActionResult> Create([Bind("ID,Name,Birthdate,Age,EstimatedAge,Description,LodgingType,Race,Gender,Picture,DateOfDeath,Castrated,ChildFriendly,ReasonGivenAway")] Lodging lodging)
    }
}
