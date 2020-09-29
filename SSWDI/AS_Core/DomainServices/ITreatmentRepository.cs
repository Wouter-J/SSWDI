using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AS_Core.DomainModel;

namespace AS_Core.DomainServices
{
    public interface ITreatmentRepository
    {
        IQueryable<Treatment> GetAll();
        Treatment GetById(int id);
        Treatment AddTreatment(Treatment treatment);


    }
}
