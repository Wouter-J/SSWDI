using AS_Core.DomainModel;
using AS_Core.Enums;
using AS_DomainServices;
using AS_DomainServices.Services;
using System.Collections.Generic;
using AS_DomainServices.Repositories;
using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using AS_Core.Filters;

namespace AS_Services
{

    public class StayService : IStayService
    {
        private readonly IStayRepository _stayRepository;
        private readonly ILodgingRepository _lodgingRepository;
        private readonly IAnimalRepository _animalRepository;

        /// <summary>
        /// Initializes a new instance of the <see cref="StayService"/> class.
        /// </summary>
        /// <param name="stayRepository"></param>
        public StayService(IStayRepository stayRepository, ILodgingRepository lodgingRepository, IAnimalRepository animalRepository)
        {
            _stayRepository = stayRepository;
            _lodgingRepository = lodgingRepository;
            _animalRepository = animalRepository;
        }

        public void Add(Stay stay)
        {
            try
            {
                ValidateStay(stay);
                _stayRepository.Add(stay);
            }
            catch (InvalidOperationException e)
            {
                throw e;
            }
        }

        public Stay PlaceAnimal(Stay stay, Lodging lodge)
        {
            Lodging newLodge = _lodgingRepository.FindByID(lodge.ID);
            Stay newStay = new Stay();

            try
            {
                if (stay.ID == null || stay.ID == 0)
                {
                    newStay.LodgingLocationID = newLodge.ID;
                    newStay.AnimalID = stay.AnimalID;
                    newStay.ArrivalDate = stay.ArrivalDate;
                    newStay.CanBeAdopted = stay.CanBeAdopted;
                    ValidateStay(newStay);
                }
                else
                {
                    newStay = _stayRepository.FindByID(stay.ID);
                }

                // If animal moved
                if (newStay.LodgingLocationID != newLodge.ID && newStay.LodgingLocationID != null)
                {
                    newStay.LodgingLocationID = newLodge.ID;
                    ValidateStay(newStay);

                    Lodging currentLodge = _lodgingRepository.FindByID(newStay.LodgingLocationID);

                    // Decrease capacity at old lodge
                    currentLodge.CurrentCapacity = currentLodge.CurrentCapacity - 1;
                    currentLodge.Stays.Remove(newStay);
                    _lodgingRepository.SaveLodging(currentLodge);
                }

                SaveStay(newStay);

                // Increase capacity at new lodge
                newLodge.CurrentCapacity = newLodge.CurrentCapacity + 1;

                newLodge.Stays.Add(newStay);
                _lodgingRepository.SaveLodging(newLodge);

                return newStay;

            } catch (InvalidOperationException e)
            {
                throw e;
            }
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

        public IEnumerable<Stay> GetStayWithAnimal()
        {
            return _stayRepository.GetStayWithAnimal();
        }

        public IEnumerable<Stay> GetAllWithFilter(AnimalFilter filter = null)
        {
            var stayList = _stayRepository.GetStayWithAnimal();

            if (filter == null)
            {
                return stayList.ToList();
            }
            else
            {
                return AddFilters(filter, stayList);
            }
        }

        public void Remove(Stay stay)
        {
            // Add specific business logic here
            _stayRepository.Remove(stay);
        }

        public void SaveStay(Stay stay)
        {
            try
            {
                ValidateStay(stay);
                _stayRepository.SaveStay(stay);
            } catch(InvalidOperationException e)
            {
                throw e;
            }
        }

        /// <summary>
        /// Finds related Stay object on bias of animal ID.
        /// </summary>
        /// <param name="ID">ID of Animal.</param>
        public Stay FindRelatedStay(int ID)
        {
            IEnumerable<Stay> AllStays = _stayRepository.GetAll();

            // Usinq LINQ to find relatedStay
            var relatedStay = from Stay in AllStays
                               where Stay.AnimalID == ID select Stay;

            // TODO: Clean this up with a cast?
            Stay stay = relatedStay.FirstOrDefault();

            return stay;

        }

        /// <summary>
        /// Adopts animal with the given stayID.
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        public Stay AdoptAnimal(Stay stay)
        {
            _stayRepository.SaveStay(stay);

            return stay;
        }

        // TODO: Clean this function up if possible
        private IEnumerable<Stay> AddFilters(AnimalFilter filter, IEnumerable<Stay> stays)
        {
            // Filter will only work on animals that can actually be adopted; others should not show up
            stays = stays.Where(x => x.CanBeAdopted == true);

            if (filter.AnimalType != null)
            {
                stays = stays.Where(x => x.Animal.AnimalType == filter.AnimalType);
            }

            if (filter.ChildFriendly != null)
            {
                stays = stays.Where(x => x.Animal.ChildFriendly == filter.ChildFriendly);
            }

            if (filter.Gender != null)
            {
                stays = stays.Where(x => x.Animal.Gender == filter.Gender);
            }

            return stays.ToList();
        }

        private void ValidateStay(Stay stay)
        {
            Lodging lodge = _lodgingRepository.FindByID(stay.LodgingLocationID);
            Animal animal = _animalRepository.FindByID(stay.AnimalID);

            // Check if lodging has free space if new animal is added && animal is of correct type
            if (lodge.MaxCapacity < lodge.CurrentCapacity + 1)
            {
                // throw new BusinessRuleExpection("Verblijf heeft maximum capaciteit behaald");
                // TODO: err on lodge
                throw new InvalidOperationException("Lodge is at max capacity");
            }

            if (lodge.AnimalType != animal.AnimalType)
            {
                throw new InvalidOperationException("Animal types do not match");
            }

            // Check if group lodging & castrated or not
            if (!animal.Castrated && lodge.LodgingType == LodgingType.Group)
            {
                // TODO: err on animal
                throw new InvalidOperationException("Can't place non-castrated animal in a group location");
            }
        }
    }
}
