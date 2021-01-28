using AS_Core.DomainModel;

namespace AS_DomainServices.Repositories
{
    public interface IInterestedAnimalRepository : IGenericRepository<InterestedAnimal>
    {
        void SaveInterestedAnimal(InterestedAnimal interestedAnimal);
    }
}
