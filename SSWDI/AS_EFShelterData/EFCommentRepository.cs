using AS_Core.DomainModel;
using AS_DomainServices;
using System;
using System.Linq;

namespace AS_EFShelterData
{
    public class EFCommentRepository : EFGenericRepository<Comment>, ICommentRepository
    {
        public EFCommentRepository(ApplicationDbContext context) : base (context) { }

        //TODO: Add specific functions here
        public void SaveComment(Comment commentg)
        {
            if (commentg.ID == 0)
            {
                _context.Comments.Add(commentg);
            }
            else
            {
                //Do nothing; Comments can't be updated
            }
            _context.SaveChanges();
        }
    }
}
