using AS_Core.DomainModel;
using AS_DomainServices;
using System;
using System.Linq;

namespace AS_EFShelterData
{
    public class EFAnimalRepository : EFGenericRepository<Animal>, IAnimalRepository
    {
        public EFAnimalRepository(ApplicationDbContext context) : base (context)
        {
        }
        //TODO: Add Specific functions here

        public void SaveAnimal(Animal animal)
        {
            if(animal.ID == 0)
            {
                _context.Animals.Add(animal);
            } else
            {
                Animal DBAnimal = _context.Animals
                    .FirstOrDefault(a => a.ID == animal.ID);
                if(DBAnimal != null)
                {
                    //Update specific animal fields; Only name for now
                    DBAnimal.Name = animal.Name;
                }
            }
            _context.SaveChanges();
        }

    }
}
