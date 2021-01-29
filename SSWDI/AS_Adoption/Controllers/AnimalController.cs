﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using AS_Core.DomainModel;
using AS_HttpData;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;

namespace AS_Adoption.Controllers
{
    public class AnimalController : Controller
    {
        private readonly IConfiguration _configuration;
        private string apiBaseUrl = "";
        private readonly AnimalHttpRepository animalHttpService = new AnimalHttpRepository();

        public AnimalController(IConfiguration configuration)
        {
            _configuration = configuration;
            apiBaseUrl = _configuration.GetValue<string>("WebAPIBaseUrl");
        }

        public async Task<IActionResult> Index()
        {
            // List<Animal> animalList = new List<Animal>();
            // Move to seperate repository; use seperate repository project
            // HttpRepositry getAll();
            IEnumerable<Animal> animalList = await animalHttpService.HttpIndex();

            return View(animalList);
        }

        [HttpGet]
        [Authorize(Policy = "VolunteerOrCustomer")]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [Authorize(Policy = "VolunteerOrCustomer")]
        public async Task<IActionResult> Create(Animal animal)
        {
            if (animal.ReasonGivenAway == null)
            {
                ViewBag.Message = "Please submit a reason why you are giving the animal away";
                return View(animal);
            }

            try
            {
                await animalHttpService.Add(animal);
            } catch (InvalidOperationException e)
            {
                ViewBag.Message = e;
                return View(animal);
            }

            return View("/Views/Home/Index.cshtml");
        }
    }
}
