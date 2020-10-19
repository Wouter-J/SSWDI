using AS_Core.DomainModel;
using AS_DomainServices;
using AS_DomainServices.Services;

namespace AS_Services
{
    public class TreatmentService : ITreatmentService
    {
        private readonly ITreatmentRepository _treatmentRepository;

        /// <summary>
        /// Initializes a new instance of the <see cref="TreatmentService"/> class.
        /// </summary>
        /// <param name="treatmentRepository"></param>
        public TreatmentService(ITreatmentRepository treatmentRepository)
        {
            _treatmentRepository = treatmentRepository;
        }

        /// <summary>
        /// Adds a Treatment with specific domain logic.
        /// </summary>
        /// <param name="treatment">The treatment that needs to be added.</param>
        public void Add(Treatment treatment)
        {
            Animal animal = treatment.Stay.Animal;
            Stay stay = treatment.Stay;

            // Animal needs to be here & alive and not adopted
            if (treatment.Date < stay.ArrivalDate ||
                stay.AdoptionDate != null || animal.DateOfDeath != null)
            {
                // return err
            }

            // RequiredAge needs to be lower then animal age
            if (treatment.RequiredAge > animal.Age)
            {
                // return err
            }

            // Vaccination, operation, Chipping & Euthanasia need a description
            if (treatment.Description == null)
            {
                if (treatment.TreatmentType != TreatmentType.Castration || treatment.TreatmentType != TreatmentType.Sterilasation)
                {
                    // Throw err
                }
            }

            // If no error; treatment follows all business rules.
            _treatmentRepository.Add(treatment);
        }

        public Treatment FindByID(int ID)
        {
            // Add specific business logic here
            return _treatmentRepository.FindByID(ID);
        }

        public Treatment GetAll()
        {
            throw new System.NotImplementedException();
        }

        public void Remove(Treatment treatment)
        {
            // Add specific business logic here
            _treatmentRepository.Remove(treatment);
        }

        public void SaveTreatment(Treatment treatment)
        {
            // Add specific business logic here
            _treatmentRepository.SaveTreatment(treatment);
        }


    }
}
