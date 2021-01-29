using AS_Core.DomainModel;
using System.Collections.Generic;

namespace AS_DomainServices.Repositories
{
    public interface IInterestedAnimalRepository : IGenericRepository<InterestedAnimal>
    {
        void SaveInterestedAnimal(InterestedAnimal interestedAnimal);

        IEnumerable<InterestedAnimal> FindRelatedAnimals(int ID);

        InterestedAnimal FindByIDAndUser(int id, int userID);
    }
}
