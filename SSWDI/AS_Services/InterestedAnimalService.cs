using AS_Core.DomainModel;
using AS_DomainServices.Repositories;
using AS_DomainServices.Services;
using System.Collections.Generic;

namespace AS_Services
{
    public class InterestedAnimalService : IInterestedAnimalService
    {
        private readonly IInterestedAnimalRepository _interestedAnimalRepository;

        public InterestedAnimalService(IInterestedAnimalRepository interestedAnimalRepository)
        {
            _interestedAnimalRepository = interestedAnimalRepository;
        }

        public void Add(InterestedAnimal entity)
        {
            // Check if not more then three animals
            // If so allow to add
            _interestedAnimalRepository.Add(entity);
        }

        public InterestedAnimal FindByID(int ID)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<InterestedAnimal> GetAll()
        {
            return _interestedAnimalRepository.GetAll();
        }

        public void Remove(InterestedAnimal entity)
        {
            throw new System.NotImplementedException();
        }

        public void SaveInterestedAnimal(InterestedAnimal interestedAnimal)
        {
            throw new System.NotImplementedException();
        }
    }
}
