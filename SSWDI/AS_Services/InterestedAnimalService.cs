using AS_Core.DomainModel;
using AS_DomainServices.Repositories;
using AS_DomainServices.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace AS_Services
{
    public class InterestedAnimalService : IInterestedAnimalService
    {
        private readonly IInterestedAnimalRepository _interestedAnimalRepository;
        private readonly IUserRepository _userRepository;
        private readonly IAnimalRepository _animalRepository;

        public InterestedAnimalService(IInterestedAnimalRepository interestedAnimalRepository, IUserRepository userRepository, IAnimalRepository animalRepository)
        {
            _interestedAnimalRepository = interestedAnimalRepository;
            _userRepository = userRepository;
            _animalRepository = animalRepository;
        }

        public void Add(InterestedAnimal entity)
        {
            if (entity.Animal == null)
            {
                entity.Animal = _animalRepository.FindByID(entity.AnimalID);
            }

            if (entity.User == null)
            {
                entity.User = _userRepository.FindByID(entity.UserID);
            }

            // Check if not more then three animals
            // If so allow to add
            if (entity.User.InterestCount < 3)
            {
                entity.Animal = null;
                try
                {
                    _userRepository.IncreaseAdoptionCount(entity.User);
                    entity.User = null;
                    _interestedAnimalRepository.Add(entity);
                }
                catch (Exception e)
                {
                    throw e;
                }
            } else
            {
                throw new InvalidOperationException("No more then three animals with interest");
            }

        }

        public InterestedAnimal FindByID(int ID)
        {
            return _interestedAnimalRepository.FindByID(ID);
        }

        public InterestedAnimal FindByIDAndUser(int ID, int userID)
        {
            return _interestedAnimalRepository.FindByIDAndUser(ID, userID);
        }

        public IEnumerable<InterestedAnimal> GetAll()
        {
            return _interestedAnimalRepository.GetAll();
        }

        public IEnumerable<InterestedAnimal> GetRelated(string userName)
        {
            // This Index function needs to work a bit differently
            // Get user & find the related ID (So Email => UserID)
            User user = _userRepository.FindByUsername(userName);
            // Then; Only get the animals that have the same User IDs
            // IEnumerable<InterestedAnimal> = FindRelatedAnimals(user.ID);
            // Maybe make this a different function then the getAll method
            return _interestedAnimalRepository.FindRelatedAnimals(user.ID);
        }

        public IEnumerable<InterestedAnimal> FindRelatedAnimals(int userID)
        {
            return _interestedAnimalRepository.FindRelatedAnimals(userID);
        }


        public void Remove(InterestedAnimal entity)
        {
            User user = entity.User;
            _userRepository.DecreaseAdoptionCount(user);
            _interestedAnimalRepository.Remove(entity);
        }

        public void SaveInterestedAnimal(InterestedAnimal interestedAnimal)
        {
            throw new System.NotImplementedException();
        }
    }
}
