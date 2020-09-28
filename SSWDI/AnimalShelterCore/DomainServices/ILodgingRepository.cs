using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AnimalShelterCore.DomainModel;

namespace AnimalShelterCore.DomainServices
{
    public interface ILodgingRepository
    {
        IQueryable<Lodging> GetAll();
        Lodging GetById(int id);
        Lodging AddLodging(Lodging lodging);
    }
}
