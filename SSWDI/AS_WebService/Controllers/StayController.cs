using AS_Core.DomainModel;
using AS_DomainServices.Services;
using Microsoft.AspNetCore.Mvc;
using System;

namespace AS_WebService.Controllers
{
    [ApiController]
    [Route("/api/stay")]
    public class StayController : Controller
    {
        private readonly IStayService _stayService;

        public StayController(IStayService stayService)
        {
            _stayService = stayService;
        }

        /// <summary>
        /// All available Stays.
        /// These are animals placed and usually available for adoption.
        /// </summary>
        /// <returns>List of stays.</returns>
        public IActionResult Index()
        {
            return Ok(_stayService.GetAll());
        }

        [HttpGet("{id:int}")]
        public IActionResult GetStay(int id)
        {
            Stay stay = _stayService.FindByID(id);
            return Ok(stay);
        }

        // Adopt Animal
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
