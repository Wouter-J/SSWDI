using AS_Core.DomainModel;
using AS_DomainServices.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;

namespace AS_WebService.Controllers
{
    [ApiController]
    [Route("/api/animal")]
    public class AnimalController : Controller
    {
        private readonly IAnimalService _animalService;

        public AnimalController(IAnimalService animalService)
        {
            _animalService = animalService;
        }

        /// <summary>
        /// All available Animals.
        /// These are all animals available, this does not mean that they are all available for adoption.
        /// </summary>
        /// <returns>List of animals.</returns>
        public IActionResult Index()
        {
            return Ok(_animalService.GetAll());
        }

        [HttpGet("{id:int}")]
        public IActionResult GetAnimal(int id)
        {
            Animal animal = _animalService.FindByID(id);
            return Ok(animal);
        }

        [HttpPost]
        public ActionResult<Animal> AddAnimal(Animal animal)
        {
            _animalService.Add(animal);
            return Ok(animal);
        }

        [HttpPut("{id:int}")]
        public ActionResult<Animal> UpdateAnimal(int id, [FromBody] Animal animal)
        {
            Console.WriteLine("Update w/ id " + id);
            animal.ID = id;
            _animalService.SaveAnimal(animal);
            return Ok(animal);
        }
    }
}
