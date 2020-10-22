using AS_Core.DomainModel;
using AS_DomainServices.Repositories;

namespace AS_DomainServices.Services
{
    public interface IStayService : IStayRepository
    {
        Stay FindRelatedStay(int ID);
    }
}
