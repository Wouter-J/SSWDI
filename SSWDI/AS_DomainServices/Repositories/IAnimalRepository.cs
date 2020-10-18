using AS_Core.DomainModel;

namespace AS_DomainServices.Repositories
{
    public interface IAnimalRepository : IGenericRepository<Animal>
    {
        // TODO: Add specific functions here
        void SaveAnimal(Animal animal);
    }
}
