using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AS_Core.DomainModel;
using AS_DomainServices.Services;
using AS_Identity;
using AS_Management.ViewModels;
using AutoMapper;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.WebUtilities;

namespace AS_Management.Controllers
{
    public class AccountController : Controller
    {
        private RoleManager<IdentityRole> _roleManager;

        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IUserService _userService;
        private readonly IMapper _mapper;
        public IList<AuthenticationScheme> ExternalLogins { get; set; }

        public AccountController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, 
            IUserService userService, RoleManager<IdentityRole> roleManager, IMapper mapper)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _userService = userService;
            _roleManager = roleManager;
            _mapper = mapper;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult Register(string returnUrl = null)
        {
            ViewData["ReturnUrl"] = returnUrl;
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(RegisterViewModel model, string returnUrl = null)
        {
            ViewData["ReturnUrl"] = returnUrl;

            returnUrl = returnUrl ?? Url.Content("~/");
            ExternalLogins = (await _signInManager.GetExternalAuthenticationSchemesAsync()).ToList();

            // TODO: Clean up if possible
            if (ModelState.IsValid)
            {
                var domainUser = new User
                {
                    Email = model.Email,
                    Firstname = model.Firstname,
                    Lastname = model.Lastname,
                    BirthDay = model.BirthDay,
                    Address = model.Address,
                    Cellphone = model.Cellphone,
                    PostalCode = model.PostalCode
                };
                var mappedEntity = _mapper.Map<User, ApplicationUser>(domainUser);

                var result = await _userService.HandleVolunteerRegistration(domainUser, mappedEntity);

                if (result.Succeeded)
                {
                    if (_userManager.Options.SignIn.RequireConfirmedAccount)
                    {
                        return RedirectToPage("RegisterConfirmation", new { email = model.Email, returnUrl = returnUrl });
                    }
                    else
                    {
                        await _signInManager.SignInAsync(mappedEntity, isPersistent: false);
                        return LocalRedirect(returnUrl);
                    }
                }

            foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
            }

            // If we got this far, something failed, redisplay form
            return View("Areas/Identity/Pages/Account/Register.cshtml", model);
        }

    }
}
