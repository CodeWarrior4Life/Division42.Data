using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Division42.Data.Repository
{
    /// <summary>
    /// Interface for interacting with an entity in an underlying data store.
    /// </summary>
    /// <typeparam name="TEntity">The data structure type on which this repository operates.</typeparam>
    public interface IRepository<TEntity> : IDisposable
        where TEntity : class, new()
    {
        /// <summary>
        /// Gets all records.
        /// </summary>
        IEnumerable<TEntity> GetAll();

        /// <summary>
        /// Gets a record by the specified ID.
        /// </summary>
        /// <param name="id">The id, or primary key of the record to retrieve.</param>
        TEntity GetById(Guid id);

        /// <summary>
        /// Gets a record by the specified <paramref name="whereClause"/> condition.
        /// </summary>
        /// <param name="whereClause">The condition.</param>
        /// <exception cref="ArgumentNullException"></exception>
        TEntity GetByFilter(Expression<Func<TEntity, Boolean>> whereClause);

        /// <summary>
        /// Inserts a new record.
        /// </summary>
        /// <param name="instance">The new record to insert.</param>
        /// <exception cref="ArgumentNullException"></exception>
        void Insert(TEntity instance);

        /// <summary>
        /// Updates an existing record.
        /// </summary>
        /// <param name="instance">The updated record.</param>
        /// <exception cref="ArgumentNullException"></exception>
        void Update(TEntity instance);

        /// <summary>
        /// Deletes an existing record.
        /// </summary>
        /// <param name="instance">The record to delete.</param>
        /// <exception cref="ArgumentNullException"></exception>
        void Delete(TEntity instance);
    }
}
