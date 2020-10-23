using System;
using System.Collections.Generic;
using System.Linq;
using AS_Core.DomainModel;
using AS_DomainServices;
using Microsoft.AspNetCore.Mvc;
using AS_DomainServices.Repositories;
using AS_DomainServices.Services;
using AS_Management.ViewModels;

namespace AS_Management.Controllers
{
    /// <summary>
    /// Logic for Comments; Only accessible via an Animal.
    /// </summary>
    public class CommentController : Controller
    {
        private readonly ICommentService _commentService;
        private readonly IStayService _stayService;
        private readonly IAnimalService _animalService;


        /// <summary>
        /// Initializes a new instance of the <see cref="CommentController"/> class.
        /// </summary>
        /// <param name="commentService"></param>
        /// <param name="stayService"></param>
        /// <param name="animalService"></param>
        public CommentController(ICommentService commentService, IStayService stayService,
            IAnimalService animalService)
        {
            _commentService = commentService;
            _animalService = animalService;
            _stayService = stayService;
        }

        [Route("Index/{AnimalID:int}")]
        public IActionResult Index(int AnimalID)
        {
            var vm = new CommentViewModel
            {
                Comments = _commentService.GetRelatedComments(AnimalID),
            };

            return View(vm);
        }

        [HttpGet]
        public IActionResult Details(int ID)
        {
            Comment comment = _commentService.FindByID(ID);
            return View(comment);
        }

        [HttpGet]
        [Route("Create/{AnimalID:int}")]
        public IActionResult Create(int AnimalID)
        {
            Console.WriteLine(AnimalID);
            var vm = new CommentViewModel
            {
                Animal = _animalService.FindByID(AnimalID),
                Stay = _stayService.FindRelatedStay(AnimalID)
            };

            return View(vm);
        }

        [HttpPost]
        [Route("Create/{AnimalID:int}")]
        [ValidateAntiForgeryToken]
        public IActionResult Create(CommentViewModel CommentViewModel)
        {
            try
            {
                // TODO: Cleanup
                CommentViewModel.Comment.StayID = CommentViewModel.Stay.ID;
                _commentService.Add(CommentViewModel.Comment);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception e)
            {
                Console.WriteLine("Error occured" + e); // TODO: use logger service for this
            }

            return View();
        }

        // According to business rules Comments can only be created & obtained.
    }
}
