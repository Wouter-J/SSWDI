using AS_Core.DomainModel;
using AS_DomainServices.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AS_EFShelterData
{
    public class EFInterestedAnimalRepository : EFGenericRepository<InterestedAnimal>, IInterestedAnimalRepository
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="EFInterestedAnimalRepository"/> class.
        /// </summary>
        /// <param name="context"></param>
        public EFInterestedAnimalRepository(ApplicationDbContext context) : base(context) { }

        public void SaveInterestedAnimal(InterestedAnimal animal)
        {

            if (animal.ID == 0)
            {
                _context.InterestedAnimals.Add(animal);
            }
            else
            {
                InterestedAnimal DBInterest = _context.InterestedAnimals
                    .FirstOrDefault(a => a.ID == animal.ID);
                if (DBInterest != null)
                {
                    _context.Entry<InterestedAnimal>(DBInterest).CurrentValues.SetValues(animal);
                }
            }

            _context.SaveChanges();
        }
    }
}
