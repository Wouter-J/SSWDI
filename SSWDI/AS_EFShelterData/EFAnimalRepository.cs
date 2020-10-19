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
                    // Update specific animal fields; Only name for now
                    DBAnimal.Name = animal.Name;
                }
            }

            _context.SaveChanges();
        }

    }
}
