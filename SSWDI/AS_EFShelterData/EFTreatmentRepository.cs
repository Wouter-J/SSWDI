using System;
using System.Linq;
using AS_Core.DomainModel;
using AS_DomainServices;
using AS_DomainServices.Repositories;

namespace AS_EFShelterData
{
    public class EFTreatmentRepository : EFGenericRepository<Treatment>, ITreatmentRepository
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="EFTreatmentRepository"/> class.
        /// </summary>
        /// <param name="context"></param>
        public EFTreatmentRepository(ApplicationDbContext context) : base(context) { }

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
                    _context.Entry<Treatment>(DBTreatment).CurrentValues.SetValues(treatment);
                }
            }

            _context.SaveChanges();
        }
    }
}
