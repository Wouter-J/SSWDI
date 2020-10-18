using AS_Core.DomainModel;
using AS_DomainServices;
using AS_DomainServices.Services;

namespace AS_Services
{

    public class StayService : IStayService
    {
        private readonly IStayRepository _stayRepository;

        /// <summary>
        /// Initializes a new instance of the <see cref="StayService"/> class.
        /// </summary>
        /// <param name="stayRepository"></param>
        public StayService(IStayRepository stayRepository)
        {
            _stayRepository = stayRepository;
        }

        public void Add(Stay stay)
        {
            Lodging lodge = stay.LodgingLocation;
            Animal animal = stay.Animal;

            // Check if lodging has free space if new animal is added && animal is of correct type
            if (lodge.MaxCapacity != lodge.CurrentCapacity + 1 && lodge.AnimalType == animal.AnimalType)
            {
                // err on lodge
            }

            // Check if group lodging & castrated or not
            if (!animal.Castrated && lodge.LodgingType == LodgingType.Group)
            {
                // err on animal
            }

            _stayRepository.Add(stay);

        }

        public Stay FindByID(int ID)
        {
            // Add specific business logic here
            return _stayRepository.FindByID(ID);
        }

        public Stay GetAll()
        {
            // Add specific business logic here
            throw new System.NotImplementedException();
        }

        public void Remove(Stay stay)
        {
            // Add specific business logic here
            _stayRepository.Remove(stay);
        }

        public void SaveAnimal(Stay stay)
        {
            // Add specific business logic here
            _stayRepository.SaveStay(stay);
        }
    }
}
