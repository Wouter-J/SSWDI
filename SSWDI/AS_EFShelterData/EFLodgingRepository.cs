using System;
using System.Collections.Generic;
using System.Linq;
using AS_Core.DomainModel;
using AS_Core.DomainServices;

namespace AS_EFShelterData
{
    public class EFLodgingRepository : ILodgingRepository
    {
        public Lodging AddLodging(Lodging lodging)
        {
            throw new NotImplementedException();
        }

        public IQueryable<Lodging> GetAll()
        {
            throw new NotImplementedException();
        }

        public Lodging GetById(int id)
        {
            throw new NotImplementedException();
        }
    }
}
