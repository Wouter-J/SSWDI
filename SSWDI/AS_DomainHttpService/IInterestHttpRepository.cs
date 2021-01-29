using AS_Core.DomainModel;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace AS_DomainHttpService
{
    public interface IInterestHttpRepository
    {
        public Task<IEnumerable<InterestedAnimal>> HttpIndex();

        public Task<InterestedAnimal> FindInterest(Animal animal, ClaimsPrincipal currentUser);

        public Task<IEnumerable<InterestedAnimal>> GetInterestedAnimal(ClaimsPrincipal currentUser);

        public Task<User> GetUserByHttp(ClaimsPrincipal currentUser);

        public Task<InterestedAnimal> ShowInterest(Animal animal, ClaimsPrincipal currentUser);

        public Task<InterestedAnimal> RemoveInterest(Animal animal, ClaimsPrincipal currentUser);
    }
}
