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

        /// <summary>
        /// Adds an animal. Age is automatically calculated if a birthday is added.
        /// If not, the estimated age becomes the actual age.
        /// </summary>
        /// <param name="animal">The animal object.</param>
        public void Add(Animal animal)
        {
            // Check if both age(s) have a value.
            if (animal.EstimatedAge != 0 && animal.Birthdate != null)
            {
                // TODO: Return err
            }

            // Check if EstimagedAge has value, if so that becomes the Age.
            if (animal.EstimatedAge != 0 && animal.Birthdate == null)
            {
                animal.Age = animal.EstimatedAge;
            }

            // Check if BirthDate has value, if so that becomes the Age.
            if (animal.Birthdate != null && animal.EstimatedAge == 0)
            {
                animal.Age = animal.Birthdate.Year;
            }

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
    }
}
