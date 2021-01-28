using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AS_Core.DomainModel;
using AS_HttpData;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace AS_Adoption.Controllers
{
    [Authorize(Policy = "RequireCustomer")]
    public class ShoppingCartController : Controller
    {
        private readonly IConfiguration _configuration;
        private string apiBaseUrl = "";
        private readonly InterestHttpService interestHttpService = new InterestHttpService();

        public ShoppingCartController(IConfiguration configuration)
        {
            _configuration = configuration;
            apiBaseUrl = _configuration.GetValue<string>("WebAPIBaseUrl");
        }

        public async Task<IActionResult> Index()
        {
            System.Security.Claims.ClaimsPrincipal currentUser = this.User;

            IEnumerable<InterestedAnimal> interestList = await interestHttpService.GetInterestedAnimal(currentUser);

            return View(interestList);
        }
    }
}
