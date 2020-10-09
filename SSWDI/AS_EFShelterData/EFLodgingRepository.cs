using AS_Core.DomainModel;
using AS_Core.DomainServices;

namespace AS_EFShelterData
{
    public class EFLodgingRepository : EFGenericRepository<Lodging> ,ILodgingRepository
    {
        public EFLodgingRepository(ApplicationDbContext context) : base(context) { }

        //TODO: Add specific functions here
    }
}
