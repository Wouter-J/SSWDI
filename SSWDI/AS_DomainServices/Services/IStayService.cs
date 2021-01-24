using AS_Core.DomainModel;
using AS_Core.Filters;
using AS_DomainServices.Repositories;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace AS_DomainServices.Services
{
    public interface IStayService : IStayRepository
    {
        Stay FindRelatedStay(int ID);

        Stay AdoptAnimal(Stay stay);

        public IEnumerable<Stay> GetAllWithFilter(AnimalFilter filter = null);
    }
}
