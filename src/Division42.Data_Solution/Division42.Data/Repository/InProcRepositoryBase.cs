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
    /// <typeparam name="TKey">The data type of the primary key.</typeparam>
    public abstract class InProcRepositoryBase<TEntity, TKey> : DisposableBase, IRepository<TEntity, TKey>
        where TEntity : class, new()
    {
        /// <summary>
        /// Creates a new instance of this type.
        /// </summary>
        protected InProcRepositoryBase()
        {
        }

        /// <summary>
        /// Creates a new instance of this type.
        /// </summary>
        /// <param name="initialList">Records to pre-include in the repository.</param>
        protected InProcRepositoryBase(IEnumerable<TEntity> initialList)
            : this()
        {
            if (initialList == null)
                throw new ArgumentNullException("initialList");

            _list.AddRange(initialList);
        }

        /// <summary>
        /// Gets all records.
        /// </summary>
        public IEnumerable<TEntity> GetAll()
        {
            CheckIfDisposed();

            return _list;
        }

        /// <summary>
        /// Gets a record by the specified ID.
        /// </summary>
        /// <param name="id">The id, or primary key of the record to retrieve.</param>
        public abstract TEntity GetById(TKey id);

        /// <summary>
        /// Gets a record by the specified <paramref name="whereClause"/> condition.
        /// </summary>
        /// <param name="whereClause">The condition.</param>
        /// <exception cref="ArgumentNullException"></exception>
        public TEntity GetByFilter(Expression<Func<TEntity, bool>> whereClause)
        {
            CheckIfDisposed();

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
            CheckIfDisposed();

            if (instance == null)
                throw new ArgumentNullException("instance");

            _list.Add(instance);
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
            CheckIfDisposed();

            if (instance == null)
                throw new ArgumentNullException("instance");

            _list.Remove(instance);
        }

        private readonly List<TEntity> _list = new List<TEntity>();
    }

    /// <summary>
    /// An in-process repository for unit testing and design-time support.
    /// </summary>
    /// <typeparam name="TEntity">The data structure on which this repository operates</typeparam>
    public abstract class InProcRepositoryBase<TEntity> : InProcRepositoryBase<TEntity, Guid>
        where TEntity : class, new()
    {
        /// <summary>
        /// Creates a new instance of this type.
        /// </summary>
        protected InProcRepositoryBase() : base()
        {
        }

        /// <summary>
        /// Creates a new instance of this type.
        /// </summary>
        /// <param name="initialList">Records to pre-include in the repository.</param>
        protected InProcRepositoryBase(IEnumerable<TEntity> initialList) : base(initialList)
        {
        }
    }
}