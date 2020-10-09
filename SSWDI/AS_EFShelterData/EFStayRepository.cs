using AS_Core.DomainModel;
using AS_Core.DomainServices;

namespace AS_EFShelterData
{
    public class EFStayRepository : EFGenericRepository<Stay> ,IStayRepository
    {
        public EFStayRepository(ApplicationDbContext context) : base (context) { }

        //TODO: Add specific functions here
    }
}
