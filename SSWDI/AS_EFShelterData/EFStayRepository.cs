using System;
using System.Collections.Generic;
using System.Linq;
using AS_Core.DomainModel;
using AS_DomainServices;
using AS_DomainServices.Repositories;
using Microsoft.EntityFrameworkCore;

namespace AS_EFShelterData
{
    public class EFStayRepository : EFGenericRepository<Stay>, IStayRepository
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="EFStayRepository"/> class.
        /// </summary>
        /// <param name="context"></param>
        public EFStayRepository(ApplicationDbContext context) : base(context) { }

        public IEnumerable<Stay> GetStayWithAnimal()
        {
            return  _context.Stays.Include(Animal => Animal.Animal).ToList();
        }

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
                    _context.Entry<Stay>(DBStay).CurrentValues.SetValues(stay);
                }
            }

            _context.SaveChanges();
        }
    }
}
