using System;
using System.Collections.Generic;
using System.Linq;
using AS_Core.DomainModel;
using AS_DomainServices.Services;
using AS_Management.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace AS_Management.Controllers
{
    public class TreatmentController : Controller
    {
        private readonly ITreatmentService _treatmentService;
        private readonly IStayService _stayService;
        private readonly IAnimalService _animalService;

        /// <summary>
        /// Initializes a new instance of the <see cref="TreatmentController"/> class.
        /// </summary>
        /// <param name="treatmentRepository"></param>
        public TreatmentController(ITreatmentService treatmentService, IStayService stayService, IAnimalService animalService)
        {
            _treatmentService = treatmentService;
            _animalService = animalService;
            _stayService = stayService;
        }

        // GET: Treatment
        public IActionResult Index()
        {
            // TODO: Create custom viewModel
            return View(_treatmentService.GetAll().ToList());
        }

        // GET: Treatment/Details/5
        [HttpGet]
        public IActionResult Details(int ID)
        {
            Treatment treatment = _treatmentService.FindByID(ID);

            return View(treatment);
        }

        [HttpGet]
        public IActionResult Create()
        {
            var vm = new TreatmentViewModel()
            {
                Animals = _animalService.GetAll().ToList()
            };

            return View(vm);
        }

        // POST: Treatment/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(TreatmentViewModel TreatmentViewModel)
        {
            try
            {
                // Find proper stay on Animal ID bias
                TreatmentViewModel.Treatment.Stay = _stayService.FindRelatedStay(TreatmentViewModel.Animal.ID);

                _treatmentService.Add(TreatmentViewModel.Treatment);
                return RedirectToAction(nameof(Index));
            } catch (Exception e)
            {
                Console.WriteLine("Error occured" + e); // TODO: use logger service for this
            }

            return View(TreatmentViewModel);
        }

        // GET: Treatment/Edit/5
        [HttpGet]
        public IActionResult Edit(int ID)
        {
            // TODO: Add better ViewModel
            Treatment treatment = _treatmentService.FindByID(ID);
            return View(treatment);
        }

        // POST: Treatment/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Treatment treatment)
        {
            if (ModelState.IsValid)
            {
                _treatmentService.SaveTreatment(treatment);
                return RedirectToAction(nameof(Index));
            }

            return View(treatment);
        }

        // GET: Treatment/Delete/5
        public IActionResult Delete(int ID)
        {
            Treatment treatment = _treatmentService.FindByID(ID);
            return View(treatment);
        }

        // POST: Treatment/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int ID)
        {
            // TODO: Add validation
            Treatment treatment = _treatmentService.FindByID(ID);
            _treatmentService.Remove(treatment);
            return RedirectToAction(nameof(Index));
        }
    }
}
