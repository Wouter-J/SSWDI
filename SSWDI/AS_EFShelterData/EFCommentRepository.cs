using AS_Core.DomainModel;
using AS_DomainServices;

namespace AS_EFShelterData
{
    public class EFCommentRepository : EFGenericRepository<Comment>, ICommentRepository
    {
        public EFCommentRepository(ApplicationDbContext context) : base (context) { }

        //TODO: Add specific functions here
    }
}
