using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AS_DomainServices.Services;
using Microsoft.AspNetCore.Mvc;

namespace AS_WebService.Controllers
{
    [ApiController]
    [Route("/api/interest")]
    public class InterestedAnimalController : Controller
    {
        private readonly IInterestedAnimalService _interestedAnimalService;

        public InterestedAnimalController(IInterestedAnimalService interestedAnimalService)
        {
            _interestedAnimalService = interestedAnimalService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return Ok(_interestedAnimalService.GetAll());
        }
    }
}
