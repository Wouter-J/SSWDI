using AS_Core.DomainModel;
using System.Collections.Generic;

namespace AS_DomainServices.Repositories
{
    public interface IStayRepository : IGenericRepository<Stay>
    {
        // TODO: Add specific functions here
        void SaveStay(Stay stay);

        /// <summary>
        /// Will get all stays with their related animal
        /// </summary>
        /// <returns></returns>
        IEnumerable<Stay> GetStayWithAnimal();
    }
}
