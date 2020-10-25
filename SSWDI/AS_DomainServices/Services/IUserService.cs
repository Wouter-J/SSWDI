using AS_Core.DomainModel;
using AS_DomainServices.Repositories;

namespace AS_DomainServices.Services
{
    public interface IUserService : IUserRepository
    {
        /// <summary>
        /// Finds user based on provided email.
        /// </summary>
        /// <param name="Email">Email as string.</param>
        /// <returns>The User object.</returns>
        User FindByUsername(string Email);
    }
}
