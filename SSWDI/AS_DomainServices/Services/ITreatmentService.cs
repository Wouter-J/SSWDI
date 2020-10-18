using AS_Core.DomainModel;

namespace AS_DomainServices.Services
{
    public interface ITreatmentService
    {
        public Treatment GetAll();

        public Treatment FindByID(int ID);

        public void Add(Treatment treatment);

        public void Remove(Treatment treatment);

        // TODO: implement specific functions
        void SaveTreatment(Treatment treatment);
    }
}
