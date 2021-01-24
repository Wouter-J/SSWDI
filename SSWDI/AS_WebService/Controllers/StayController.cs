using AS_Core.DomainModel;
using AS_Core.Filters;
using AS_DomainServices.Services;
using AS_EFShelterData;
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
        private readonly IAnimalService _animalService;
        private readonly ApplicationDbContext _context;

        public StayController(IStayService stayService, ApplicationDbContext context, IAnimalService animalService)
        {
            _stayService = stayService;
            _animalService = animalService;
            _context = context;
        }

        /// <summary>
        /// All available Stays.
        /// These are animals placed and usually available for adoption.
        /// </summary>
        /// <returns>List of stays.</returns>
        [HttpGet]
        public IActionResult Index([FromQuery] AnimalFilter animalFilters )
        {
            var animalList = _stayService.GetAllWithFilter(animalFilters);

            return Ok(animalList.ToList());
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
