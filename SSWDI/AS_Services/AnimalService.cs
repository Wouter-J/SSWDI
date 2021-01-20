using AS_Core.DomainModel;
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
            animal.Age = CalculateAge(animal);
            if (animal.Age == -1)
            {
                // TODO: Return error; Age wrong
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

        public IEnumerable<Animal> GetAllAvailableAnimals()
        {
            return _animalRepository.GetAll().Where(a => a.DateOfDeath == null).ToList();
        }

        public void Remove(Animal animal)
        {
            // Add specific business logic here
            _animalRepository.Remove(animal);
        }

        public void SaveAnimal(Animal animal)
        {
            animal.Age = CalculateAge(animal);
            if (animal.Age == -1)
            {
                // TODO: Return error; Age wrong
            }

            _animalRepository.SaveAnimal(animal);
        }

        public async Task<string> SaveImage(Animal animal, string wwwRootPath)
        {
            // Upload image
            //string wwwRootPath = _hostEnvironment.WebRootPath;

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

        private int CalculateAge(Animal animal)
        {
            // Check if both age(s) have a value.
            if (animal.EstimatedAge != 0 && animal.Birthdate != null)
            {
                // TODO: Return err
                return -1;
            }

            // Check if EstimagedAge has value, if so that becomes the Age.
            if (animal.EstimatedAge != 0 && animal.Birthdate == null)
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

            return -1;
        }
    }
}
