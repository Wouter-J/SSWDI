using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AnimalShelterCore.DomainModel;

namespace AnimalShelterCore.DomainServices
{
    public interface IStayRepository
    {
        IQueryable<Stay> GetAll();
        Stay GetById(int id);
        Stay AddStay(Stay stay);
    }
}
