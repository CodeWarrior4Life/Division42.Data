using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using SQLite.Net;
using SQLite.Net.Interop;

namespace Division42.Data.Repository
{
    /// <summary>
    /// A SQLite implementation of a repository.
    /// </summary>
    /// <typeparam name="TEntity">The data structure type on which this repository operates.</typeparam>
    public abstract class SqliteRepositoryBase<TEntity> : IDisposable, IRepository<TEntity> 
        where TEntity : class, new()
    {
        /// <summary>
        /// Gets the SQLite platform to be used by the SQLite PCL library.
        /// </summary>
        public ISQLitePlatform SqlitePlatform { get; protected set; }

        /// <summary>
        /// Gets the SQLite connection string to be used by the SQLite PCL library.
        /// </summary>
        public SQLiteConnectionString SqliteConnectionString { get; protected set; }
        
        /// <summary>
        /// Gets the SQLite connection pool to be used by the SQLite PCL library.
        /// </summary>
        public SQLiteConnectionPool ConnectionPool { get; protected set; }

        /// <summary>
        /// Creates a new instance of this type.
        /// </summary>
        /// <param name="sqlitePlatform">The SQLite platform to be used by the SQLite PCL library.</param>
        /// <param name="sqliteConnectionString">The SQLite connection string to be used by the SQLite PCL library.</param>
        /// <exception cref="ArgumentNullException"></exception>
        protected SqliteRepositoryBase(ISQLitePlatform sqlitePlatform, SQLiteConnectionString sqliteConnectionString)
        {
            if (sqlitePlatform == null)
                throw new ArgumentNullException("sqlitePlatform");
            if (sqliteConnectionString == null)
                throw new ArgumentNullException("sqliteConnectionString");

            SqlitePlatform = sqlitePlatform;
            SqliteConnectionString = sqliteConnectionString;

            ConnectionPool = new SQLiteConnectionPool(sqlitePlatform);
            ConnectionPool.Reset();
        }

        /// <summary>
        /// Gets all records.
        /// </summary>
        /// <exception cref="ObjectDisposedException"></exception>
        public IEnumerable<TEntity> GetAll()
        {
            CheckIfDisposed();

            try
            {
                using (SQLiteConnection connection = 
                    new SQLiteConnection(SqlitePlatform, SqliteConnectionString.DatabasePath)) // TODO: ConnectionPool.GetConnection(SqliteConnectionString))
                {
                    return connection.Table<TEntity>().ToList();
                }
            }
            catch (SQLiteException exception)
            {
                throw new DataException<TEntity>("Exception \"" + exception.GetType().ToString() 
                    + "\" occurred while trying to connect to the database. " 
                    + exception.Message, exception)
                {
                    ConnectionPool = ConnectionPool,
                    ConnectionString = SqliteConnectionString,
                    Platform = SqlitePlatform,
                    Repository = this
                };
            }
        }

        /// <summary>
        /// Gets a record by the specified <paramref name="whereClause"/> condition.
        /// </summary>
        /// <param name="whereClause">The condition.</param>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="ObjectDisposedException"></exception>
        public TEntity GetByFilter(Expression<Func<TEntity, Boolean>> whereClause)
        {
            CheckIfDisposed();

            if (whereClause == null)
                throw new ArgumentNullException("whereClause");

            try
            {
                using (SQLiteConnection connection = 
                    new SQLiteConnection(SqlitePlatform, SqliteConnectionString.DatabasePath)) // TODO: ConnectionPool.GetConnection(SqliteConnectionString))
                {
                    return connection.Find<TEntity>(whereClause);
                }
            }
            catch (SQLiteException exception)
            {
                throw new DataException<TEntity>("Exception \"" + exception.GetType().ToString() 
                    + "\" occurred while trying to connect to the database. " 
                    + exception.Message, exception)
                {
                    ConnectionPool = ConnectionPool,
                    ConnectionString = SqliteConnectionString,
                    Platform = SqlitePlatform,
                    Repository = this
                };
            }
        }

        /// <summary>
        /// Gets a record by the specified ID.
        /// </summary>
        /// <param name="id">The id, or primary key of the record to retrieve.</param>
        /// <exception cref="ObjectDisposedException"></exception>
        public TEntity GetById(Guid id)
        {
            CheckIfDisposed();

            try
            {
                using (SQLiteConnection connection = 
                    new SQLiteConnection(SqlitePlatform, SqliteConnectionString.DatabasePath)) // TODO: ConnectionPool.GetConnection(SqliteConnectionString))
                {
                    return connection.Get<TEntity>(id);
                }
            }
            catch (SQLiteException exception)
            {
                throw new DataException<TEntity>("Exception \"" + exception.GetType().ToString() 
                    + "\" occurred while trying to connect to the database. " 
                    + exception.Message, exception)
                {
                    ConnectionPool = ConnectionPool,
                    ConnectionString = SqliteConnectionString,
                    Platform = SqlitePlatform,
                    Repository = this
                };
            }
        }

        /// <summary>
        /// Inserts a new record.
        /// </summary>
        /// <param name="instance">The new record to insert.</param>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="ObjectDisposedException"></exception>
        public void Insert(TEntity instance)
        {
            CheckIfDisposed();

            if (instance == null)
                throw new ArgumentNullException("instance");

            try
            {
                using (SQLiteConnection connection = 
                    new SQLiteConnection(SqlitePlatform, SqliteConnectionString.DatabasePath)) // TODO: ConnectionPool.GetConnection(SqliteConnectionString))
                {
                    connection.InsertOrReplace(instance, typeof(TEntity));
                }
            }
            catch (SQLiteException exception)
            {
                throw new DataException<TEntity>("Exception \"" + exception.GetType().ToString() 
                    + "\" occurred while trying to connect to the database. " 
                    + exception.Message, exception)
                {
                    ConnectionPool = ConnectionPool,
                    ConnectionString = SqliteConnectionString,
                    Platform = SqlitePlatform,
                    Repository = this
                };
            }
        }

        /// <summary>
        /// Updates an existing record.
        /// </summary>
        /// <param name="instance">The updated record.</param>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="ObjectDisposedException"></exception>
        public void Update(TEntity instance)
        {
            CheckIfDisposed();

            if (instance == null)
                throw new ArgumentNullException("instance");

            try
            {
                using (SQLiteConnection connection = 
                    new SQLiteConnection(SqlitePlatform, SqliteConnectionString.DatabasePath)) // TODO: ConnectionPool.GetConnection(SqliteConnectionString))
                {
                    connection.Update(instance, typeof(TEntity));
                }
            }
            catch (SQLiteException exception)
            {
                throw new DataException<TEntity>("Exception \"" + exception.GetType().ToString() 
                    + "\" occurred while trying to connect to the database. " 
                    + exception.Message, exception)
                {
                    ConnectionPool = ConnectionPool,
                    ConnectionString = SqliteConnectionString,
                    Platform = SqlitePlatform,
                    Repository = this
                };
            }
        }

        /// <summary>
        /// Deletes an existing record.
        /// </summary>
        /// <param name="instance">The record to delete.</param>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="ObjectDisposedException"></exception>
        public void Delete(TEntity instance)
        {
            CheckIfDisposed();

            if (instance == null)
                throw new ArgumentNullException("instance");

            try
            {
                using (SQLiteConnection connection = 
                    new SQLiteConnection(SqlitePlatform, SqliteConnectionString.DatabasePath)) // TODO: ConnectionPool.GetConnection(SqliteConnectionString))
                {
                    connection.Delete(instance);
                }
            }
            catch (SQLiteException exception)
            {
                throw new DataException<TEntity>("Exception \"" + exception.GetType().ToString() 
                    + "\" occurred while trying to connect to the database. " 
                    + exception.Message, exception)
                {
                    ConnectionPool = ConnectionPool,
                    ConnectionString = SqliteConnectionString,
                    Platform = SqlitePlatform,
                    Repository = this
                };
            }
        }

        /// <summary>
        /// Disposes of resources when this instance is doing being used.
        /// </summary>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        /// <summary>
        /// Disposes of resources when this instance is doing being used.
        /// </summary>
        /// <param name="isDisposing">True if being called from <see cref="Dispose()"/>.</param>
        protected void Dispose(Boolean isDisposing)
        {
            if (this.ConnectionPool != null)
            {
                this.ConnectionPool.ApplicationSuspended();
                this.ConnectionPool = null;
            }

            this.SqliteConnectionString = null;
            this.SqlitePlatform = null;

            _isDisposed = true;
        }

        /// <summary>
        /// Checks to see if the current object is currently disposed. If so, then 
        /// <see cref="ObjectDisposedException"/> is thrown.
        /// </summary>
        /// <exception cref="ObjectDisposedException"></exception>
        protected void CheckIfDisposed()
        {
            if (_isDisposed)
                throw new ObjectDisposedException(this.GetType().ToString());
        }

        private Boolean _isDisposed = false;
    }
}