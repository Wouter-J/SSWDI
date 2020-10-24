using System;
using System.Linq;
using AS_Core.DomainModel;
using AS_DomainServices;
using AS_DomainServices.Repositories;

namespace AS_EFShelterData
{
    public class EFCommentRepository : EFGenericRepository<Comment>, ICommentRepository
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="EFCommentRepository"/> class.
        /// </summary>
        /// <param name="context"></param>
        public EFCommentRepository(ApplicationDbContext context) : base(context) { }

        // TODO: Add specific functions here
        public void SaveComment(Comment comment)
        {

            if (comment.ID == 0)
            {
                _context.Comments.Add(comment);
            }
            else
            {
                // Do nothing; Comments can't be updated
            }

            _context.SaveChanges();
        }
    }
}
