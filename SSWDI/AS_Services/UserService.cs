using AS_Core.DomainModel;
using AS_DomainServices;
using AS_DomainServices.Repositories;
using AS_DomainServices.Services;
using System;
using System.Collections.Generic;
using System.Linq;


namespace AS_Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public void Add(User user)
        {
            _userRepository.Add(user);
        }

        public User FindByID(int ID)
        {
            return _userRepository.FindByID(ID);
        }

        public IEnumerable<User> GetAll()
        {
            return _userRepository.GetAll();
        }

        public void Remove(User user)
        {
            _userRepository.Remove(user);
        }
    }
}
