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
            User FoundUser = _userRepository.FindByUsername(Email);

            return FoundUser;
        }

        public async Task<IdentityResult> HandleVolunteerRegistration(User user, ApplicationUser applicationUser)
        {
            applicationUser.Id = Guid.NewGuid().ToString();
            applicationUser.UserName = user.Email;

            var result = await _userManager.CreateAsync(applicationUser);

            // TODO: Move this
            var volunteer = new IdentityRole("Volunteer");
            await _roleManager.CreateAsync(volunteer);

            if (result.Succeeded)
            {
                var volunteerRole = await _roleManager.FindByNameAsync("Volunteer");

                await _userManager.AddToRoleAsync(applicationUser, volunteerRole.Name);

                // Create Domain level user
                Add(user);
            }

            return result;
        }

        public async Task<IdentityResult> HandleUserRegistration(User user, ApplicationUser applicationUser)
        {
            applicationUser.Id = Guid.NewGuid().ToString();
            applicationUser.UserName = user.Email;

            var result = await _userManager.CreateAsync(applicationUser);

            // TODO: Move this
            var customer = new IdentityRole("Customer");
            await _roleManager.CreateAsync(customer);

            if (result.Succeeded)
            {
                var volunteerRole = await _roleManager.FindByNameAsync("Customer");

                await _userManager.AddToRoleAsync(applicationUser, volunteerRole.Name);

                // Create Domain level user
                Add(user);
            }

            return result;
        }

        public void IncreaseAdoptionCount(User user)
        {
            _userRepository.IncreaseAdoptionCount(user);
        }

        public void DecreaseAdoptionCount(User user)
        {
            _userRepository.DecreaseAdoptionCount(user);
        }
    }
}
