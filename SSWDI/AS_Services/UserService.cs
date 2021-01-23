using AS_Core.DomainModel;
using AS_DomainServices;
using AS_DomainServices.Repositories;
using AS_DomainServices.Services;
using AS_Identity;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AS_Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        // Remove these from Controller later
        private readonly UserManager<ApplicationUser> _userManager;
        private RoleManager<IdentityRole> _roleManager;
        private readonly SignInManager<ApplicationUser> _signInManager;

        public UserService(IUserRepository userRepository, UserManager<ApplicationUser> userManager,
            RoleManager<IdentityRole> roleManager, SignInManager<ApplicationUser> signInManager)
        {
            _userRepository = userRepository;
            _userManager = userManager;
            _roleManager = roleManager;
            _signInManager = signInManager;
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

        public User FindByUsername(string Email)
        {
            IEnumerable<User> AllUsers = _userRepository.GetAll();

            // Usinq LINQ to find relatedStay
            var user = from User in AllUsers
                            where User.Email == Email
                       select User;

            // TODO: Clean this up with a cast?
            User FoundUser = user.FirstOrDefault();

            return FoundUser;
        }

        public async Task<IdentityResult> HandleRegistration(User user, ApplicationUser applicationUser)
        {
            applicationUser.Id = Guid.NewGuid().ToString();
            applicationUser.UserName = user.Email;

            var result = await _userManager.CreateAsync(applicationUser);

            // TODO: Move this
            var volunteer = new IdentityRole("Volunteer");
            var customer = new IdentityRole("Customer");
            await _roleManager.CreateAsync(volunteer);
            await _roleManager.CreateAsync(customer);

            if (result.Succeeded)
            {
                var volunteerRole = await _roleManager.FindByNameAsync("Volunteer");

                await _userManager.AddToRoleAsync(applicationUser, volunteerRole.Name);

                // Create Domain level user
                Add(user);
            }

            return result;
        }
    }
}
