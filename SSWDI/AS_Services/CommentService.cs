using AS_Core.DomainModel;
using AS_DomainServices;
using AS_DomainServices.Repositories;
using AS_DomainServices.Services;
using AS_EFShelterData;
using System.Collections.Generic;

namespace AS_Services
{
    public class CommentService : ICommentService
    {
        private readonly ICommentRepository _commentRepository;

        // TODO: Implement businesslogic

        /// <summary>
        /// Initializes a new instance of the <see cref="CommentService"/> class.
        /// </summary>
        /// <param name="commentRepository">Commentrepository.</param>
        public CommentService(ICommentRepository commentRepository)
        {
            _commentRepository = commentRepository;
        }

        public void Add(Comment comment)
        {
            _commentRepository.Add(comment);
        }

        public Comment FindByID(int ID)
        {
            return _commentRepository.FindByID(ID);
        }

        public IEnumerable<Comment> GetAll()
        {
            return _commentRepository.GetAll();
        }

        public void Remove(Comment comment)
        {
            _commentRepository.Remove(comment);
        }

        public void SaveComment(Comment comment)
        {
            _commentRepository.SaveComment(comment);
        }
    }
}
