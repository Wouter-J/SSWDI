using AS_Core.DomainModel;
using AS_DomainServices.Services;
using System.Collections.Generic;
using AS_Core.Enums;
using AS_DomainServices.Repositories;
using System;

namespace AS_Services
{
    public class TreatmentService : ITreatmentService
    {
        private readonly ITreatmentRepository _treatmentRepository;
        private readonly IAnimalRepository _animalRepository;

        /// <summary>
        /// Initializes a new instance of the <see cref="TreatmentService"/> class.
        /// </summary>
        /// <param name="treatmentRepository"></param>
        public TreatmentService(ITreatmentRepository treatmentRepository, IAnimalRepository animalRepository)
        {
            _treatmentRepository = treatmentRepository;
            _animalRepository = animalRepository;
        }

        /// <summary>
        /// Adds a Treatment with specific domain logic.
        /// </summary>
        /// <param name="treatment">The treatment that needs to be added.</param>
        public void Add(Treatment treatment)
        {
            try
            {
                ValidateTreatment(treatment);
                Animal animal = _animalRepository.FindByID(treatment.Stay.AnimalID);

                // Treatment of Type castration or Sterilasation updates the animal castration status
                if (treatment.TreatmentType == TreatmentType.Castration || treatment.TreatmentType == TreatmentType.Sterilasation)
                {
                    animal.Castrated = true;
                    _animalRepository.SaveAnimal(animal);
                }

                // If no error; treatment follows all business rules.
                _treatmentRepository.Add(treatment);

            } catch (InvalidOperationException e)
            {
                throw e;
            }
        }

        public Treatment FindByID(int ID)
        {
            // Add specific business logic here
            return _treatmentRepository.FindByID(ID);
        }

        public IEnumerable<Treatment> GetAll()
        {
            return _treatmentRepository.GetAll();
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

        private void ValidateTreatment(Treatment treatment)
        {
            Animal animal = _animalRepository.FindByID(treatment.Stay.AnimalID);
            Stay stay = treatment.Stay;

            // Animal needs to be here and not adopted
            if (treatment.Date < stay.ArrivalDate || stay.AdoptionDate != null )
            {
                throw new InvalidOperationException("Animal needs to be at location");
            }

            // Animal needs to be alive
            if(animal.DateOfDeath > DateTime.MinValue)
            {
                throw new InvalidOperationException("Animal must be alive in order to perform treatment");
            }

            // RequiredAge needs to be lower then animal age
            if (treatment.RequiredAge > animal.Age)
            {
                throw new InvalidOperationException("Animal needs to be older to have this treatment");
            }

            // Vaccination, operation, Chipping & Euthanasia need a description
            if (treatment.Description == null)
            {
                if (treatment.TreatmentType != TreatmentType.Castration || treatment.TreatmentType != TreatmentType.Sterilasation)
                {
                    throw new InvalidOperationException("Vaccination, operation, chipping & euthanasia need a description");
                }
            }
        }
    }
}
