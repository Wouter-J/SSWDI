using AS_Core.DomainModel;
using AS_Core.Filters;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AS_DomainHttpService
{
    public interface IStayHttpService
    {
        public Task<IEnumerable<Stay>> HandleFilter(AnimalFilter filter)
    }
}
