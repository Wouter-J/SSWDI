using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AS_Core.DomainModel;
using AS_DomainServices.Services;
using Microsoft.AspNetCore.Mvc;

namespace AS_WebService.Controllers
{
    [ApiController]
    [Route("/api/interest")]
    public class InterestedAnimalController : Controller
    {
        private readonly IInterestedAnimalService _interestedAnimalService;
        private readonly IUserService _userService;
        private readonly IAnimalService _animalService;

        public InterestedAnimalController(IInterestedAnimalService interestedAnimalService, IUserService userService, IAnimalService animalService)
        {
            _interestedAnimalService = interestedAnimalService;
            _userService = userService;
            _animalService = animalService;
        }

        [HttpGet]
        public IActionResult Index([FromQuery] string userName)
        {
            return Ok(_interestedAnimalService.GetRelated(userName));
        }

        [HttpGet("{id:int}")]
        public IActionResult GetInterest(int id, [FromQuery] string userName)
        {
            User user = _userService.FindByUsername(userName);
            InterestedAnimal animal = _interestedAnimalService.FindByIDAndUser(id, user.ID);
            return Ok(animal);
        }

        [HttpPost]
        public ActionResult<Animal> ShowInterest(InterestedAnimal animal)
        {
            try
            {
                _interestedAnimalService.Add(animal);
                // Update user view count
                return Ok(animal);
            } catch (Exception e)
            {
                return BadRequest();
            }
        }
        // Using HttpPost instead of HttpDelete here
        // This is because of HttpClient limitations
        [HttpPost("{id:int}")]
        public IActionResult Delete(int id, [FromBody] InterestedAnimal animal)
        {
            _interestedAnimalService.Remove(animal);
            return Ok(animal);
        }
    }
}