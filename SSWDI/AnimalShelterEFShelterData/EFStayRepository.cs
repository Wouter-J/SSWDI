using System;
using System.Collections.Generic;
using System.Linq;
using AnimalShelterCore.DomainModel;
using AnimalShelterCore.DomainServices;

namespace AnimalShelterEFShelterData
{
    public class EFStayRepository : IStayRepository
    {
        public Stay AddStay(Stay stay)
        {
            throw new NotImplementedException();
        }

        public IQueryable<Stay> GetAll()
        {
            throw new NotImplementedException();
        }

        public Stay GetById(int id)
        {
            throw new NotImplementedException();
        }
    }
}
