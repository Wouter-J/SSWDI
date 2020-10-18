using AS_Core.DomainModel;
using AS_DomainServices;
using System;
using System.Linq;

namespace AS_EFShelterData
{
    public class EFStayRepository : EFGenericRepository<Stay>, IStayRepository
    {
        public EFStayRepository(ApplicationDbContext context) : base (context) { }

        // TODO: Add specific functions here
        public void SaveStay(Stay stay)
        {
            if (stay.ID == 0)
            {
                _context.Stays.Add(stay);
            }
            else
            {
                Stay DBStay = _context.Stays
                    .FirstOrDefault(a => a.ID == stay.ID);
                if (DBStay != null)
                {
                    // Update specific stay fields; Only Adoption status for now
                    DBStay.CanBeAdopted = stay.CanBeAdopted;
                }
            }
            _context.SaveChanges();
        }
    }
}
