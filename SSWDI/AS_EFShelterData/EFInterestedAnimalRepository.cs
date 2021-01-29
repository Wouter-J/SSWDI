using AS_Core.DomainModel;
using AS_DomainServices.Repositories;
using Microsoft.EntityFrameworkCore;
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

        public override IEnumerable<InterestedAnimal> GetAll()
        {
            // Include related animal & User
            return _context.InterestedAnimals
                        .Include(x => x.Animal)
                        .Include(x => x.User);
        }

        public InterestedAnimal FindByIDAndUser(int id, int userID)
        {
            var interest = from Interests in _context.InterestedAnimals
                           where Interests.AnimalID == id && Interests.UserID == userID
                           select Interests;

            InterestedAnimal animal = interest.FirstOrDefault();

            return animal;
        }

        public IEnumerable<InterestedAnimal> FindRelatedAnimals(int ID)
        {
            /*
            // TODO: Cleanup func
            IEnumerable<InterestedAnimal> AllInterests = GetAll();

            var interest = from Interest in AllInterests
                           where Interest.UserID == ID
                           select Interest;

            List < InterestedAnimal > interestList = new List<InterestedAnimal>();
            _context.InterestedAnimals.Where(x => x.UserID == ID);
            interestList.Add()
                */

            var interests = from Interests in _context.InterestedAnimals.Include(x => x.Animal)
                            where Interests.UserID == ID
                            select Interests;

            return interests;
        }

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
