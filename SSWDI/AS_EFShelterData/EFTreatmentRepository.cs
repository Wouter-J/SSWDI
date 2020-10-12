using AS_Core.DomainModel;
using AS_DomainServices;


namespace AS_EFShelterData
{
    public class EFTreatmentRepository : EFGenericRepository<Treatment>, ITreatmentRepository
    {
        public EFTreatmentRepository(ApplicationDbContext context) : base (context) { }

        //TODO: Add specific functions here
    }
}
