using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using AS_Core.DomainModel;
using AS_DomainServices.Services;
using AS_Identity;
using AS_Management.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace AS_Management.Controllers
{
    public class TreatmentController : Controller
    {
        private readonly ITreatmentService _treatmentService;
        private readonly IStayService _stayService;
        private readonly IAnimalService _animalService;
        private readonly ILodgingService _lodgingService;
        private readonly UserManager<ApplicationUser> _userManager;

        /// <summary>
        /// Initializes a new instance of the <see cref="TreatmentController"/> class.
        /// </summary>
        /// <param name="treatmentRepository"></param>
        public TreatmentController(ITreatmentService treatmentService, IStayService stayService,
            IAnimalService animalService, ILodgingService lodgingService,
            UserManager<ApplicationUser> userManager)
        {
            _treatmentService = treatmentService;
            _animalService = animalService;
            _stayService = stayService;
            _lodgingService = lodgingService;
            _userManager = userManager;
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
                //Get user name
                var userName = User.FindFirstValue(ClaimTypes.Name);

                TreatmentViewModel.Treatment.DoneBy = userName;

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
            Treatment treatment = _treatmentService.FindByID(ID);
            Stay stay = _stayService.FindByID(treatment.StayID);
            var vm = new TreatmentViewModel()
            {
                Animal = _animalService.FindByID(stay.AnimalID),
                Treatment = treatment,
                Stay = stay
            };

            return View(vm);
        }

        // POST: Treatment/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(TreatmentViewModel TreatmentViewModel)
        {
            try
            {
                // Get content on bias of submitted ID's
                Stay stay = _stayService.FindByID(TreatmentViewModel.Stay.ID);
                TreatmentViewModel.Treatment.Stay = stay;
                TreatmentViewModel.Treatment.StayID = stay.ID;

                //_stayService.SaveStay(stay);
                _treatmentService.SaveTreatment(TreatmentViewModel.Treatment);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception e)
            {
                Console.WriteLine("Error occured" + e); // TODO: use logger service for this
            }

            return View(TreatmentViewModel);
        }

        // GET: Treatment/Delete/5
        public IActionResult Delete(int ID)
        {
            Treatment treatment = _treatmentService.FindByID(ID);
            Stay stay = _stayService.FindByID(treatment.StayID);

            var vm = new TreatmentViewModel()
            {
                Animal = _animalService.FindByID(stay.AnimalID),
                Treatment = treatment,
                Stay = stay
            };

            return View(vm);
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
