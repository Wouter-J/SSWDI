using AS_Core.DomainModel;
using System.Collections.Generic;

namespace AS_DomainServices.Repositories
{
    public interface IUserRepository : IGenericRepository<User>
    {
        // Add any specific functions here
        User FindByUsername(string username);

        void IncreaseAdoptionCount(User user);

        void DecreaseAdoptionCount(User user);
    }
}
