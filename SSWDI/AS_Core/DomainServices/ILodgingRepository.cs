﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AS_Core.DomainModel;

namespace AS_Core.DomainServices
{
    public interface ILodgingRepository
    {
        IQueryable<Lodging> GetAll();
        Lodging GetById(int id);
        Lodging AddLodging(Lodging lodging);
    }
}