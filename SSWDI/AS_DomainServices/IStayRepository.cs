using AS_Core.DomainModel;

namespace AS_DomainServices
{
    public interface IStayRepository : IGenericRepository<Stay>
    {
        //TODO: Add specific functions here
        void SaveStay(Stay stay);
    }
}
