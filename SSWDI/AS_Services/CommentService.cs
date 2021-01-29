using AS_Core.DomainModel;
using AS_DomainServices.Repositories;
using AS_DomainServices.Services;
using System.Collections.Generic;

namespace AS_Services
{
    public class CommentService : ICommentService
    {
        private readonly ICommentRepository _commentRepository;
        private readonly IAnimalRepository _animalRepository;
        private readonly IStayService _stayService;

        /// <summary>
        /// Initializes a new instance of the <see cref="CommentService"/> class.
        /// </summary>
        /// <param name="commentRepository">Commentrepository.</param>
        public CommentService(ICommentRepository commentRepository, IAnimalRepository animalRepository, IStayService stayService)
        {
            _commentRepository = commentRepository;
            _animalRepository = animalRepository;
            _stayService = stayService;
        }

        public void Add(Comment comment)
        {
            comment.Stay = null;
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

        /// <summary>
        /// Get all related Comments on Animal ID bias
        /// </summary>
        /// <param name="AnimalID"></param>
        /// <returns></returns>
        public IEnumerable<Comment> GetRelatedComments(int AnimalID)
        {
            Stay stay = _stayService.FindRelatedStay(AnimalID);
            IEnumerable<Comment> Comments = _commentRepository.GetAll();
            List<Comment> RelatedComments = new List<Comment>();

            foreach (var comment in Comments)
            {
                if(comment.StayID == stay.ID)
                {
                    RelatedComments.Add(comment);
                }
            }

            return RelatedComments;
        }
    }
}
