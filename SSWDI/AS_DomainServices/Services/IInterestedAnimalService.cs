using AS_Core.DomainModel;
using AS_DomainServices.Repositories;
using System.Collections.Generic;

namespace AS_DomainServices.Services
{
    public interface IInterestedAnimalService : IInterestedAnimalRepository
    {
        IEnumerable<InterestedAnimal> GetRelated(string userName);
    }
}
