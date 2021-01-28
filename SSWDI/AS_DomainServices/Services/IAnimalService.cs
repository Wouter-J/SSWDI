using System.Collections.Generic;
using System.Threading.Tasks;
using AS_Core.DomainModel;
using AS_DomainServices.Repositories;

namespace AS_DomainServices.Services
{
    public interface IAnimalService : IAnimalRepository
    {
        public IEnumerable<Animal> GetAllAvailableAnimals();

        public Task<string> SaveImage(Animal animal, string wwwRootPath);

        public void RemoveImage(Animal animal, string wwwRootPath);

        // public IEnumerable<Animal> GetRelatedAnimal(string user);
    }
}
