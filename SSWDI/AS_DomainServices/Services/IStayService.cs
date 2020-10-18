using AS_Core.DomainModel;

namespace AS_DomainServices.Services
{
    public interface IStayService
    {
        public Stay GetAll();
        public Stay FindByID(int ID);
        public void Add(Stay stay);
        public void Remove(Stay stay);
        //TODO: implement specific functions
        void SaveAnimal(Stay stay);
    }
}
