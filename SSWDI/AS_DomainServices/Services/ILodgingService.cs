using System.Collections.Generic;
using AS_Core.DomainModel;

namespace AS_DomainServices.Services
{
    public interface ILodgingService
    {
        public IEnumerable<Lodging> GetAll();

        public Lodging FindByID(int ID);

        public void Add(Lodging lodging);

        public void Remove(Lodging lodging);

        // TODO: implement specific functions
        void SaveAnimal(Lodging lodging);

        public IEnumerable<Lodging> ReturnAvailableLocations(int ID);
    }
}
