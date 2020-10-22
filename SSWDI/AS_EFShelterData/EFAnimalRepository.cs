using System;
using System.Linq;
using AS_Core.DomainModel;
using AS_DomainServices.Repositories;

namespace AS_EFShelterData
{
    public class EFAnimalRepository : EFGenericRepository<Animal>, IAnimalRepository
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="EFAnimalRepository"/> class.
        /// </summary>
        /// <param name="context"></param>
        public EFAnimalRepository(ApplicationDbContext context) : base(context)
        {
        }

        // TODO: Add Specific functions here
        public void SaveAnimal(Animal animal)
        {
            if (animal.ID == 0)
            {
                _context.Animals.Add(animal);
            }
            else
            {
                Animal DBAnimal = _context.Animals
                    .FirstOrDefault(a => a.ID == animal.ID);
                if (DBAnimal != null)
                {
                    // Specify all fields so that EF notices that changes have been done.
                    DBAnimal.Name = animal.Name;
                    DBAnimal.Birthdate = animal.Birthdate;
                    DBAnimal.EstimatedAge = animal.EstimatedAge;
                    DBAnimal.Age = animal.Age;
                    DBAnimal.Description = animal.Description;
                    DBAnimal.Race = animal.Race;
                    DBAnimal.Picture = animal.Picture;
                    DBAnimal.DateOfDeath = animal.DateOfDeath;
                    DBAnimal.ChildFriendly = animal.ChildFriendly;
                    DBAnimal.ReasonGivenAway = animal.ReasonGivenAway;
                }
            }

            _context.SaveChanges();
        }

    }
}
