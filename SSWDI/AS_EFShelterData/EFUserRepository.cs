using AS_Core.DomainModel;
using AS_DomainServices.Repositories;
using System.Linq;

namespace AS_EFShelterData
{
    /// <summary>
    /// User repository, note that this model only contains domain information
    /// Identity framework is used for the Login & Auth data.
    /// </summary>
    public class EFUserRepository : EFGenericRepository<User>, IUserRepository
    {

        /// <summary>
        /// Initializes a new instance of the <see cref="EFUserRepository"/> class.
        /// </summary>
        /// <param name="context"></param>
        public EFUserRepository(ApplicationDbContext context) : base(context)
        {
        }

        public void SaveUser(User user)
        {
            if (user.ID == 0)
            {
                _context.Users.Add(user);
            }   
            else
            {
                User DbUser = _context.Users
                    .FirstOrDefault(a => a.ID == user.ID);
                if (DbUser != null)
                {
                    _context.Entry<User>(DbUser).CurrentValues.SetValues(user);
                }
            }

            _context.SaveChanges();
        }
    }
}
