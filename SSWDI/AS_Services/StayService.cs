﻿using AS_Core.DomainModel;
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
    }
}
