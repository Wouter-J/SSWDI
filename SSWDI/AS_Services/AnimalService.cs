﻿using AS_Core.DomainModel;
using AS_Core.Enums;
using AS_Core.Filters;
using AS_DomainServices;
using AS_DomainServices.Repositories;
using AS_DomainServices.Services;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace AS_Services
{
    public class AnimalService : IAnimalService
    {
        private readonly IAnimalRepository _animalRepository;
        private readonly ILodgingRepository _lodgingRepository;

        /// <summary>
        /// Initializes a new instance of the <see cref="AnimalService"/> class.
        /// </summary>
        /// <param name="animalRepository"></param>
        public AnimalService(IAnimalRepository animalRepository, ILodgingRepository lodgingRepository)
        {
            _animalRepository = animalRepository;
            _lodgingRepository = lodgingRepository;
        }

        /// <summary>
        /// Adds an animal. Age is automatically calculated if a birthday is added.
        /// If not, the estimated age becomes the actual age.
        /// </summary>
        /// <param name="animal">The animal object.</param>
        public void Add(Animal animal)
        {
            try
            {

                animal.Age = CalculateAge(animal);
                if (animal.Age == -1)
                {
                    throw new InvalidOperationException("Age can't be less then 0");
                }

                _animalRepository.Add(animal);
            } catch (InvalidOperationException e)
            {
                throw e;
            }
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

        public IEnumerable<Animal> GetAllAvailableAnimals()
        {
            return _animalRepository.GetAll().Where(a => a.DateOfDeath == null).ToList();
        }
        /*
        public IEnumerable<Animal> GetRelatedAnimal(string user)
        {
            return _animalRepository.GetAll().Where(a => a == user).ToList();
        }
        */
        public void Remove(Animal animal)
        {
            // Add specific business logic here
            _animalRepository.Remove(animal);
        }

        public void SaveAnimal(Animal animal)
        {
            try
            {

                animal.Age = CalculateAge(animal);
                if (animal.Age == -1)
                {
                    throw new InvalidOperationException("Age can't be less then 0");
                }

                _animalRepository.SaveAnimal(animal);
            }
            catch (InvalidOperationException e)
            {
                throw e;
            }
        }

        public async Task<string> SaveImage(Animal animal, string wwwRootPath)
        {
            // Upload image
            string fileName = Path.GetFileNameWithoutExtension(animal.ImageFile.FileName);
            string extension = Path.GetExtension(animal.ImageFile.FileName);
            fileName = fileName + DateTime.Now.ToString("yymmssfff") + extension; // Make the image name to always be unique
            animal.ImageName = fileName;

            string path = Path.Combine(wwwRootPath + "/images", fileName);
            using (var fileStream = new FileStream(path, FileMode.Create))
            {
                await animal.ImageFile.CopyToAsync(fileStream);
            }

            return fileName;
        }

        public void RemoveImage(Animal animal, string wwwRootPath)
        {
            if (animal.ImageName != null)
            {
                var imagePath = Path.Combine(wwwRootPath, "images", animal.ImageName);
                if (File.Exists(imagePath)) { File.Delete(imagePath); } // Removes image if it exists
            }
        }

        /// <summary>
        /// Returns all available lodging locations on basis of Animal.
        /// Automatically check if one more animal would fit; and other business rules.
        /// </summary>
        /// <param name="ID">ID of the animal.</param>
        /// <returns>Available Lodges.</returns>
        public IEnumerable<Lodging> ReturnAvailableLocations(Animal animal)
        {
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

        private int CalculateAge(Animal animal)
        {
            if (animal.Age < 0) {
                throw new InvalidOperationException("Age can't be less then 0");
            }

            // If both EstimagedAge and Birthdate are filled in; return error
            if (animal.EstimatedAge != 0 && animal.Birthdate > DateTime.MinValue)
            {
                throw new InvalidOperationException("Animal can't have estimated age & birthday");
            }

            // Check if EstimagedAge has value, if so that becomes the Age.
            if (animal.EstimatedAge != 0 && animal.Birthdate == DateTime.MinValue)
            {
                return animal.EstimatedAge;
            }

            // Check if BirthDate has value, if so that becomes the Age.
            if (animal.Birthdate != null && animal.EstimatedAge == 0)
            {
                var today = DateTime.Today;

                // Yes, we are not accounting for leap years here.
                var age = today.Year - animal.Birthdate.Year + 1;

                return age;
            }
            // In case anything goes wrong; return -1; will be caught be service.
            return -1;
        }
    }
}
