using System.Collections.Generic;
using AS_Core.DomainModel;
using AS_DomainServices.Repositories;

namespace AS_DomainServices.Services
{
    public interface IAnimalService : IAnimalRepository
    {
        /// <summary>
        /// Interface
        /// Finds related Stay location on Animal basis.
        /// </summary>
        /// <param name="ID">The ID of the Animal.</param>
        /// <returns>The related stay to the animal.</returns>
        Stay FindRelatedStay(int ID);
    }
}
