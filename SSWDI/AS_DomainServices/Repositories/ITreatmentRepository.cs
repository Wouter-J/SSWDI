using AS_Core.DomainModel;

namespace AS_DomainServices
{
    public interface ITreatmentRepository : IGenericRepository<Treatment>
    {
        // TODO: Add specific functions here
        void SaveTreatment(Treatment treatment);

    }
}
