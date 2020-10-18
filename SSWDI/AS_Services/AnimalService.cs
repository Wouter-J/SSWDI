using AS_Core.DomainModel;
using AS_DomainServices;
using AS_DomainServices.Repositories;
using AS_DomainServices.Services;

namespace AS_Services
{
    public class AnimalService : IAnimalService
    {
        private readonly IAnimalRepository _animalRepository;

        public AnimalService(IAnimalRepository animalRepository)
        {
            _animalRepository = animalRepository;
        }

        public void Add(Animal animal)
        {
            // Add specific business logic here
            _animalRepository.Add(animal);
        }

        public Animal FindByID(int ID)
        {
            // Add specific business logic here
            return _animalRepository.FindByID(ID);
        }

        public Animal GetAll()
        {
            // Add specific business logic here
            throw new System.NotImplementedException();
        }

        public void Remove(Animal animal)
        {
            // Add specific business logic here
            throw new System.NotImplementedException();
        }

        public void SaveAnimal(Animal animal)
        {
            // Add specific business logic here
            throw new System.NotImplementedException();
        }
    }
}
