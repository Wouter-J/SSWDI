using System;
using System.Collections.Generic;
using System.Linq;
using AS_Core;
using AS_DomainServices;

namespace AS_EFShelterData
{
    public class EFGenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class
    {
        protected readonly ApplicationDbContext _context;

        /// <summary>
        /// Initializes a new instance of the <see cref="EFGenericRepository{TEntity}"/> class.
        /// </summary>
        /// <param name="context"></param>
        public EFGenericRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public IEnumerable<TEntity> GetAll()
        {
            return _context.Set<TEntity>().ToList();
        }

        public TEntity FindByID(int ID)
        {
            return _context.Set<TEntity>().Find(ID);
        }

        public void Add(TEntity entity)
        {
            _context.Set<TEntity>().Add(entity);
            _context.SaveChanges();
        }

        public void Remove(TEntity entity)
        {
            _context.Set<TEntity>().Remove(entity);
        }
    }
}
