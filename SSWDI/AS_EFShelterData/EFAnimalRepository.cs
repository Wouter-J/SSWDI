using AS_Core.DomainModel;
using AS_Core.DomainServices;

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
