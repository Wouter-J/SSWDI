using AS_Core.DomainModel;
using AS_DomainServices.Services;
using AS_EFShelterData;
using AS_WebService.Filters;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AS_WebService.Controllers
{
    [ApiController]
    [Route("/api/stay")]
    public class StayController : Controller
    {
        private readonly IStayService _stayService;
        private readonly ApplicationDbContext _context;

        public StayController(IStayService stayService, ApplicationDbContext context)
        {
            _stayService = stayService;
            _context = context;
        }

        /// <summary>
        /// All available Stays.
        /// These are animals placed and usually available for adoption.
        /// </summary>
        /// <returns>List of stays.</returns>
        public IActionResult Index([FromQuery] AnimalFilters animalFilters )
        {
            var context = _context.Stays
                            .Include(Animal => Animal.Animal)
                            .ToList();

            var serviceList = _stayService.GetAll();
            animalFilters.CanBeAdopted = true;

            if (animalFilters.ChildFriendly != 0)
            {
                serviceList = serviceList.Where(stay => stay.Animal.ChildFriendly == animalFilters.ChildFriendly);
            }

            if (animalFilters.AnimalType != 0)
            {
                serviceList = serviceList.Where(stay => stay.Animal.AnimalType == animalFilters.AnimalType);
            }

            if (animalFilters.Gender == 'M' || animalFilters.Gender == 'F')
            {
                serviceList = serviceList.Where(stay => stay.Animal.Gender == animalFilters.Gender);
            }

            if (animalFilters.CanBeAdopted == true)
            {
                serviceList = serviceList.Where(stay => stay.CanBeAdopted == animalFilters.CanBeAdopted);
            }

            return Ok(serviceList.ToList());
        }

        [HttpGet("{id:int}")]
        public IActionResult GetStay(int id)
        {
            Stay stay = _stayService.FindByID(id);
            return Ok(stay);
        }

        // Adopt Animal. Implement properly
        [HttpPut("{id:int}")]
        public ActionResult<Stay> UpdateStay(int id, [FromBody] Stay stay)
        {
            Console.WriteLine("Update w/ id " + id);
            stay.ID = id;
            _stayService.SaveStay(stay);
            return Ok(stay);
        }
    }
}
