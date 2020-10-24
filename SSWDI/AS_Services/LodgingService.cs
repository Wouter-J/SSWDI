using AS_Core.DomainModel;
using AS_DomainServices;
using AS_DomainServices.Repositories;
using AS_DomainServices.Services;
using System.Collections.Generic;
using AS_Core.Enums;

namespace AS_Services
{
    public class LodgingService : ILodgingService
    {
        private readonly ILodgingRepository _lodgingRepository;
        private readonly IAnimalRepository _animalRepository;

        /// <summary>
        /// Initializes a new instance of the <see cref="LodgingService"/> class.
        /// </summary>
        /// <param name="lodgingRepository">Lodging repo.</param>
        /// <param name="animalRepository">Animal repo.</param>
        public LodgingService(ILodgingRepository lodgingRepository, IAnimalRepository animalRepository)
        {
            _animalRepository = animalRepository;
            _lodgingRepository = lodgingRepository;
        }

        public void Add(Lodging lodging)
        {
            // Add specific business logic here
            _lodgingRepository.Add(lodging);
        }

        public Lodging FindByID(int ID)
        {
            // Add specific business logic here
            return _lodgingRepository.FindByID(ID);
        }

        public IEnumerable<Lodging> GetAll()
        {
            // Add specific business logic here
            return _lodgingRepository.GetAll();
        }

        public void Remove(Lodging lodging)
        {
            // Add specific business logic here
            _lodgingRepository.Remove(lodging);
        }

        /// <summary>
        /// Returns all available lodging locations on basis of AnimalID.
        /// Automatically check if one more animal would fit; and other business rules.
        /// </summary>
        /// <param name="ID">ID of the animal.</param>
        /// <returns>Available Lodges.</returns>
        public IEnumerable<Lodging> ReturnAvailableLocations(int ID)
        {
            var animal = _animalRepository.FindByID(ID);
            var lodges = _lodgingRepository.GetAll();
            var freeLodges = new List<Lodging>();

            foreach (var lodge in lodges)
            {
                // Check if group lodging & castrated or Individual group
                if ((animal.Castrated && lodge.LodgingType == LodgingType.Group) || lodge.LodgingType == LodgingType.Individual)
                {
                    // Check if lodging has free space if new animal is added && animal is of correct type
                    if (lodge.CurrentCapacity + 1 != lodge.MaxCapacity && lodge.AnimalType == animal.AnimalType)
                    {
                        freeLodges.Add(lodge);
                    }
                }
            }

            return freeLodges;
        }

        public void SaveLodging(Lodging lodging)
        {
            // Add specific business logic here
            _lodgingRepository.SaveLodging(lodging);
        }

    }
}
