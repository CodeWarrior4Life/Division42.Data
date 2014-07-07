using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Division42.Data.Repository
{
    /// <summary>
    /// An in-process repository for unit testing and design-time support.
    /// </summary>
    /// <typeparam name="TEntity">The data structure on which this repository operates</typeparam>
    public abstract class InProcRepositoryBase<TEntity> : IRepository<TEntity>
        where TEntity : class, new()
    {
        /// <summary>
        /// Gets all records.
        /// </summary>
        public IEnumerable<TEntity> GetAll()
        {
            return list;
        }

        /// <summary>
        /// Gets a record by the specified ID.
        /// </summary>
        /// <param name="id">The id, or primary key of the record to retrieve.</param>
        public abstract TEntity GetById(Guid id);

        /// <summary>
        /// Gets a record by the specified <paramref name="whereClause"/> condition.
        /// </summary>
        /// <param name="whereClause">The condition.</param>
        /// <exception cref="ArgumentNullException"></exception>
        public TEntity GetByFilter(Expression<Func<TEntity, bool>> whereClause)
        {
            if (whereClause == null)
                throw new ArgumentNullException("whereClause");

            return GetAll().Where(whereClause.Compile()).FirstOrDefault();
        }

        /// <summary>
        /// Inserts a new record.
        /// </summary>
        /// <param name="instance">The new record to insert.</param>
        /// <exception cref="ArgumentNullException"></exception>
        public void Insert(TEntity instance)
        {
            if (instance == null)
                throw new ArgumentNullException("instance");

            list.Add(instance);
        }

        /// <summary>
        /// Updates an existing record.
        /// </summary>
        /// <param name="instance">The updated record.</param>
        /// <exception cref="ArgumentNullException"></exception>
        public abstract void Update(TEntity instance);

        /// <summary>
        /// Deletes an existing record.
        /// </summary>
        /// <param name="instance">The record to delete.</param>
        /// <exception cref="ArgumentNullException"></exception>
        public void Delete(TEntity instance)
        {
            if (instance == null)
                throw new ArgumentNullException("instance");

            list.Remove(instance);
        }

        private List<TEntity> list = new List<TEntity>();
    }
}