using System;
using System.Collections.Generic;
using System.Text;

//TODO: Finish summary(s)
namespace AS_DomainServices
{
    /// <summary>
    /// Generic repository class for basic operations
    /// </summary>
    /// <typeparam name="TEntity"></typeparam>
    public interface IGenericRepository<TEntity> where TEntity : class
    {
        /// <summary>
        /// Get all of <typeparamref name="TEntity"/>
        /// </summary>
        /// <returns>An IEnumerable object of TEntity</returns>
        IEnumerable<TEntity> GetAll();

        /// <summary>
        /// Gets the first entity that matches the ID and reeturns it
        /// </summary>
        /// <param name="ID">ID of the object to find</param>
        /// <returns>The first entity found</returns>
        TEntity FindByID(int ID);

        /// <summary>
        /// Creates a new entity
        /// </summary>
        /// <param name="entity"></param>
        void Add(TEntity entity);

        void Remove(TEntity entity);
    }
}
