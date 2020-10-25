using AS_Core.DomainModel;
using AS_DomainServices.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace AS_DomainServices.Services
{
    public interface IStayService : IStayRepository
    {
        Stay FindRelatedStay(int ID);

        Stay AdoptAnimal(Stay stay);
    }
}
