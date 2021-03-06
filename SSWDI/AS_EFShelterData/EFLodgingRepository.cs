﻿using System;
using System.Linq;
using AS_Core.DomainModel;
using AS_DomainServices;
using AS_DomainServices.Repositories;

namespace AS_EFShelterData
{
    public class EFLodgingRepository : EFGenericRepository<Lodging>, ILodgingRepository
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="EFLodgingRepository"/> class.
        /// </summary>
        /// <param name="context"></param>
        public EFLodgingRepository(ApplicationDbContext context) : base(context) { }

        // TODO: Add specific functions here
        public void SaveLodging(Lodging lodging)
        {
            if (lodging.ID == 0)
            {
                _context.Lodgings.Add(lodging);
            }
            else
            {
                Lodging DBLodging = _context.Lodgings
                    .FirstOrDefault(a => a.ID == lodging.ID);
                if (DBLodging != null)
                {
                    _context.Entry<Lodging>(DBLodging).CurrentValues.SetValues(lodging);
                }
            }

            _context.SaveChanges();
        }
    }
}
