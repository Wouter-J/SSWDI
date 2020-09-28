using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AnimalShelterCore.DomainModel;

namespace AnimalShelterCore.DomainServices
{
    public interface ITreatmentRepository
    {
        IQueryable<Treatment> GetAll();
        Treatment GetById(int id);
        Treatment AddTreatment(Treatment treatment);


    }
}
