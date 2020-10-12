using AS_Core.DomainModel;
using AS_DomainServices;

namespace AS_EFShelterData
{
    public class EFLodgingRepository : EFGenericRepository<Lodging>, ILodgingRepository
    {
        public EFLodgingRepository(ApplicationDbContext context) : base(context) { }

        //TODO: Add specific functions here
    }
}
