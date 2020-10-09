using AS_Core.DomainModel;
using AS_Core.DomainServices;

namespace AS_EFShelterData
{
    public class EFCommentRepository : EFGenericRepository<Comment> ,ICommentRepository
    {
        public EFCommentRepository(ApplicationDbContext context) : base (context) { }

        //TODO: Add specific functions here
    }
}
