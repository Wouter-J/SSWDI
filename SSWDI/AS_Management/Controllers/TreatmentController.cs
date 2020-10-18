using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using AS_Core.DomainModel;
using AS_DomainServices;

namespace AS_Management.Controllers
{
    public class TreatmentController : Controller
    {
        private ITreatmentRepository _treatmentRepository;

        public TreatmentController(ITreatmentRepository treatmentRepository)
        {
            _treatmentRepository = treatmentRepository;
        }

        // GET: Treatment
        public IActionResult Index()
        {
            // TODO: Create custom viewModel
            return View(_treatmentRepository.GetAll().ToList());
        }

        // GET: Treatment/Details/5
        [HttpGet]
        public IActionResult Details(int ID)
        {
            Treatment treatment = _treatmentRepository.FindByID(ID);

            return View(treatment);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        // POST: Treatment/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Treatment treatment)
        {
            if (ModelState.IsValid)
            {
                _treatmentRepository.Add(treatment);
                return RedirectToAction(nameof(Index));
            }
            return View(treatment);
        }

        // GET: Treatment/Edit/5
        [HttpGet]
        public IActionResult Edit(int ID)
        {
            // TODO: Add better ViewModel
            Treatment treatment = _treatmentRepository.FindByID(ID);
            return View(treatment);
        }

        // POST: Treatment/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Treatment treatment)
        {
            if(ModelState.IsValid)
            {
                _treatmentRepository.SaveTreatment(treatment);
                return RedirectToAction(nameof(Index));
            }
            return View(treatment);
        }

        // GET: Treatment/Delete/5
        public IActionResult Delete(int ID)
        {
            Treatment treatment = _treatmentRepository.FindByID(ID);
            return View(treatment);
        }

        // POST: Treatment/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int ID)
        {
            // TODO: Add validation
            Treatment treatment = _treatmentRepository.FindByID(ID);
            _treatmentRepository.Remove(treatment);
            return RedirectToAction(nameof(Index));
        }
    }
}
