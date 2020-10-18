using AS_Core.DomainModel;
using AS_DomainServices;
using System;
using System.Linq;

namespace AS_EFShelterData
{
    public class EFTreatmentRepository : EFGenericRepository<Treatment>, ITreatmentRepository
    {
        public EFTreatmentRepository(ApplicationDbContext context) : base (context) { }

        // TODO: Add specific functions here
        public void SaveTreatment(Treatment treatment)
        {
            if (treatment.ID == 0)
            {
                _context.Treatments.Add(treatment);
            }
            else
            {
                Treatment DBTreatment = _context.Treatments
                    .FirstOrDefault(a => a.ID == treatment.ID);
                if (DBTreatment != null)
                {
                    // Update specific treatment fields; Only Description for now
                    DBTreatment.Description = treatment.Description;
                }
            }
            _context.SaveChanges();
        }
    }
}
