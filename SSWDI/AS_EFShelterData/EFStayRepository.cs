using System;
using System.Linq;
using AS_Core.DomainModel;
using AS_DomainServices;
using AS_DomainServices.Repositories;

namespace AS_EFShelterData
{
    public class EFStayRepository : EFGenericRepository<Stay>, IStayRepository
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="EFStayRepository"/> class.
        /// </summary>
        /// <param name="context"></param>
        public EFStayRepository(ApplicationDbContext context) : base(context) { }

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
                    // Update specific lodging fields; General save for now
                    DBStay = stay;
                }
            }

            _context.SaveChanges();
        }
    }
}
