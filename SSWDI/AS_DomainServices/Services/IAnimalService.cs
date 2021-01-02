using System.Collections.Generic;
using AS_Core.DomainModel;
using AS_DomainServices.Repositories;

namespace AS_DomainServices.Services
{
    public interface IAnimalService : IAnimalRepository
    {
        public IEnumerable<Animal> GetAllAvailableAnimals();
    }
}
