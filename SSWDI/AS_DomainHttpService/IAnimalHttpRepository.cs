using AS_Core.DomainModel;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;

namespace AS_DomainHttpService
{
    public interface IAnimalHttpRepository
    {
        public Task<IEnumerable<Animal>> HttpIndex();

        public Task<Animal> HttpGetByID(int ID);

        public Task<Animal> Add(Animal animal);

        public Task<IEnumerable<Animal>> GetInterestedAnimal(ClaimsPrincipal currentUser);
    }
}
