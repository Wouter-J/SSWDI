using AS_Core.DomainModel;

namespace AS_DomainServices.Repositories
{
    public interface ILodgingRepository : IGenericRepository<Lodging>
    {
        // TODO: Add specific functions here
        void SaveLodging(Lodging lodging);
    }
}
