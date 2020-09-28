using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AnimalShelterCore.DomainModel;

namespace AnimalShelterCore.DomainServices
{
    public interface IAnimalRepository
    {
        IQueryable<Animal> GetAll();
        Animal GetById(int id);
        Animal AddAnimal(Animal Animal);
    }
}
