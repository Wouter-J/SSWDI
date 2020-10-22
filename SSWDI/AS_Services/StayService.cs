using AS_Core.DomainModel;
using AS_Core.Enums;
using AS_DomainServices;
using AS_DomainServices.Services;
using System.Collections.Generic;
using AS_DomainServices.Repositories;
using System;

namespace AS_Services
{

    public class StayService : IStayService
    {
        private readonly IStayRepository _stayRepository;

        /// <summary>
        /// Initializes a new instance of the <see cref="StayService"/> class.
        /// </summary>
        /// <param name="stayRepository"></param>
        public StayService(IStayRepository stayRepository)
        {
            _stayRepository = stayRepository;
        }

        public void Add(Stay stay)
        {
            Lodging lodge = stay.LodgingLocation;
            Animal animal = stay.Animal;

            // Check if lodging has free space if new animal is added && animal is of correct type
            if (lodge.MaxCapacity != lodge.CurrentCapacity + 1 && lodge.AnimalType == animal.AnimalType)
            {
                // TODO: err on lodge
            }

            // Check if group lodging & castrated or not
            if (!animal.Castrated && lodge.LodgingType == LodgingType.Group)
            {
                // TODO: err on animal
            }

            _stayRepository.Add(stay);

        }

        public Stay FindByID(int ID)
        {
            // Add specific business logic here
            return _stayRepository.FindByID(ID);
        }

        public IEnumerable<Stay> GetAll()
        {
            // Add specific business logic here
            return _stayRepository.GetAll();
        }

        public void Remove(Stay stay)
        {
            // Add specific business logic here
            _stayRepository.Remove(stay);
        }

        public void SaveStay(Stay stay)
        {
            // TODO: breaking DRY principle here; create seperate function
            Lodging lodge = stay.LodgingLocation;
            Animal animal = stay.Animal;

            // Check if lodging has free space if new animal is added && animal is of correct type
            if (lodge.MaxCapacity != lodge.CurrentCapacity + 1 && lodge.AnimalType == animal.AnimalType)
            {
                // throw new BusinessRuleExpection("Verblijf heeft maximum capaciteit behaald");
                // TODO: err on lodge
            }

            // Check if group lodging & castrated or not
            if (!animal.Castrated && lodge.LodgingType == LodgingType.Group)
            {
                // TODO: err on animal
            }

            _stayRepository.SaveStay(stay);
        }
    }
}
