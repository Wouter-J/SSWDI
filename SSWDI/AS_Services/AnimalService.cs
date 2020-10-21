using AS_Core.DomainModel;
using AS_DomainServices;
using AS_DomainServices.Repositories;
using AS_DomainServices.Services;
using System.Collections.Generic;

namespace AS_Services
{
    public class AnimalService : IAnimalService
    {
        private readonly IAnimalRepository _animalRepository;
        private readonly IStayRepository _stayRepository;

        /// <summary>
        /// Initializes a new instance of the <see cref="AnimalService"/> class.
        /// </summary>
        /// <param name="animalRepository"></param>
        public AnimalService(IAnimalRepository animalRepository, IStayRepository stayRepository)
        {
            _animalRepository = animalRepository;
            _stayRepository = stayRepository;
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

        public IEnumerable<Animal> GetAll()
        {
            // Add specific business logic here
            return _animalRepository.GetAll();
        }

        public void Remove(Animal animal)
        {
            // Add specific business logic here
            _animalRepository.Remove(animal);
        }

        public void SaveAnimal(Animal animal)
        {
            // Add specific business logic here
            _animalRepository.SaveAnimal(animal);
        }

        /// <summary>
        /// Finds related Stay location on Animal basis.
        /// </summary>
        /// <param name="ID">The ID of the Animal.</param>
        /// <returns>The related stay to the animal.</returns>
        public Stay FindRelatedStay(int ID)
        {
            Animal animal = _animalRepository.FindByID(ID);

            return _stayRepository.FindByID(animal.StayID);
        }
    }
}
