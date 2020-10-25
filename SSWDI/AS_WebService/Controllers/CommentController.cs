using AS_Core.DomainModel;
using AS_DomainServices.Services;
using Microsoft.AspNetCore.Mvc;
using System;

namespace AS_WebService.Controllers
{
    [ApiController]
    [Route("/api/comment")]
    public class CommentController : Controller
    {
        private readonly ICommentService _commentService;

        public CommentController(ICommentService commentService)
        {
            _commentService = commentService;
        }

        /// <summary>
        /// All available Comments.
        /// All Comments that are available.
        /// </summary>
        /// <returns>List of comments.</returns>
        public IActionResult Index()
        {
            return Ok(_commentService.GetAll());
        }

        [HttpGet("{id:int}")]
        public IActionResult GetComment(int id)
        {
            Comment comment = _commentService.FindByID(id);
            return Ok(comment);
        }

        [HttpPost]
        public ActionResult<Comment> AddComment(Comment comment)
        {
            Console.WriteLine("Posted!");
            _commentService.Add(comment);
            return Ok(comment);
        }

    }
}
