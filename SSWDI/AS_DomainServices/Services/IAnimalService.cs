using System.Collections.Generic;
using AS_Core.DomainModel;

namespace AS_DomainServices.Services
{
    public interface IAnimalService
    {
        public IEnumerable<Animal> GetAll();

        public Animal FindByID(int ID);

        public void Add(Animal animal);

        public void Remove(Animal animal);

        // TODO: implement specific functions
        void SaveAnimal(Animal animal);

        /// <summary>
        /// Interface
        /// Finds related Stay location on Animal basis.
        /// </summary>
        /// <param name="ID">The ID of the Animal.</param>
        /// <returns>The related stay to the animal.</returns>
        Stay FindRelatedStay(int ID);
    }
}
