using AS_Core.DomainModel;
using AS_DomainServices;

namespace AS_EFShelterData
{
    public class EFAnimalRepository : EFGenericRepository<Animal>, IAnimalRepository
    {
        public EFAnimalRepository(ApplicationDbContext context) : base (context)
        {
        }

        //TODO: Add Specific functions here
    }
}
