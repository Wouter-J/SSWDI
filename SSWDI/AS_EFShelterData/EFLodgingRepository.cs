using AS_Core.DomainModel;
using AS_DomainServices;
using System;
using System.Linq;

namespace AS_EFShelterData
{
    public class EFLodgingRepository : EFGenericRepository<Lodging>, ILodgingRepository
    {
        public EFLodgingRepository(ApplicationDbContext context) : base(context) { }

        // TODO: Add specific functions here
        public void SaveLodging(Lodging lodging)
        {
            if (lodging.ID == 0)
            {
                _context.Lodgings.Add(lodging);
            }
            else
            {
                Lodging DBLodging = _context.Lodgings
                    .FirstOrDefault(a => a.ID == lodging.ID);
                if (DBLodging != null)
                {
                    // Update specific lodging fields; Only LodgingType for now
                    DBLodging.LodgingType = lodging.LodgingType;
                }
            }
            _context.SaveChanges();
        }
    }
}
