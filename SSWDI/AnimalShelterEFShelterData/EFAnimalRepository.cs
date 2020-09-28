using System;
using System.Collections.Generic;
using System.Linq;
using AnimalShelterCore.DomainModel;
using AnimalShelterCore.DomainServices;

namespace AnimalShelterEFShelterData
{
    public class EFAnimalRepository : IAnimalRepository
    {
        public Animal AddAnimal(Animal Animal)
        {
            throw new NotImplementedException();
        }

        public IQueryable<Animal> GetAll()
        {
            throw new NotImplementedException();
        }

        public Animal GetById(int id)
        {
            throw new NotImplementedException();
        }
    }
}
