using AS_Core.DomainModel;
using AS_Core.DomainServices;


namespace AS_EFShelterData
{
    public class EFTreatmentRepository : EFGenericRepository<Treatment>, ITreatmentRepository
    {
        public EFTreatmentRepository(ApplicationDbContext context) : base (context) { }

        //TODO: Add specific functions here
    }
}
