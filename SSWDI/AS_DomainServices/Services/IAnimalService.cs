using AS_Core.DomainModel;

namespace AS_DomainServices.Services
{
    public interface IAnimalService
    {
        public Animal GetAll();
        public Animal FindByID(int ID);
        public void Add(Animal animal);
        public void Remove(Animal animal);
        //TODO: implement specific functions
        void SaveAnimal(Animal animal);
    }
}
