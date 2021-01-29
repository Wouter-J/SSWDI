using AS_Core.DomainModel;
using AS_DomainServices.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
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

        public User FindByUsername(string username)
        {
            IEnumerable<User> AllUsers = GetAll();

            // Usinq LINQ to find relatedStay
            var user = from User in AllUsers
                       where User.Email == username
                       select User;
            User userFound = user.FirstOrDefault();

            return userFound;
        }

        public void IncreaseAdoptionCount(User user)
        {
            User DbUser = _context.Users.AsNoTracking()
                       .FirstOrDefault(a => a.ID == user.ID);
            if (DbUser != null)
            {
                DbUser.InterestCount++;
                _context.SaveChanges();
            }
        }

        public void DecreaseAdoptionCount(User user)
        {
            User DbUser = _context.Users.AsNoTracking()
                       .FirstOrDefault(a => a.ID == user.ID);
            if (DbUser != null)
            {
                DbUser.InterestCount--;
            }
            _context.SaveChanges();
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
