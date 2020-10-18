using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using AS_Core.DomainModel;
using AS_DomainServices;

namespace AS_Management.Controllers
{
    public class CommentController : Controller
    {
        private ICommentRepository _commentRepository;

        public CommentController(ICommentRepository commentRepository)
        {
            _commentRepository = commentRepository;
        }

        public IActionResult Index()
        {
            // TODO create custom viewModel
            return View(_commentRepository.GetAll().ToList());
        }

        [HttpGet]
        public IActionResult Details(int ID)
        {
            Comment comment = _commentRepository.FindByID(ID);
            return View(comment);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Comment comment)
        {
            if (ModelState.IsValid)
            {
                _commentRepository.Add(comment);
                return RedirectToAction(nameof(Index));
            }
            return View(comment);
        }

        [HttpGet]
        public IActionResult Edit(int ID)
        {
            // TODO: Add better ViewModel
            Comment comment = _commentRepository.FindByID(ID);
            return View(comment);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Comment comment)
        {
            if (ModelState.IsValid)
            {
                _commentRepository.SaveComment(comment);
                return RedirectToAction(nameof(Index));
            }
            return View(comment);
        }

        // GET: Comments/Delete/5
        public IActionResult Delete(int ID)
        {
            Comment comment = _commentRepository.FindByID(ID);
            return View(comment);
        }

        // POST: Comments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int ID)
        {
            // TODO: Add validation
            Comment comment = _commentRepository.FindByID(ID);
            _commentRepository.Remove(comment);
            return RedirectToAction(nameof(Index));
        }

        // POST: Comments/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        // public async Task<IActionResult> Create([Bind("ID,Name,Birthdate,Age,EstimatedAge,Description,CommentType,Race,Gender,Picture,DateOfDeath,Castrated,ChildFriendly,ReasonGivenAway")] Comment comment)

    }
}
