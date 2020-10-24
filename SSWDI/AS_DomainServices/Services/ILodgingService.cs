using System.Collections.Generic;
using AS_Core.DomainModel;
using AS_DomainServices.Repositories;

namespace AS_DomainServices.Services
{
    public interface ILodgingService : ILodgingRepository
    {
        public IEnumerable<Lodging> ReturnAvailableLocations(int ID);
    }
}
