using AS_Core.DomainModel;

namespace AS_DomainServices
{
    public interface IAnimalRepository : IGenericRepository<Animal>
    {
        //TODO: Add specific functions here
        void SaveAnimal(Animal animal);
    }
}
