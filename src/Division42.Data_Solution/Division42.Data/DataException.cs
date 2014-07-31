using System;
using Division42.Data.Repository;
using SQLite.Net;
using SQLite.Net.Interop;

namespace Division42.Data
{
    /// <summary>
    /// Exception class for errors within the Division42.Data namespace.
    /// </summary>
    /// <remarks>
    /// <para>
    /// For guidelines regarding the creation of new exception types, see:
    ///    http://msdn.microsoft.com/library/default.asp?url=/library/en-us/cpgenref/html/cpconerrorraisinghandlingguidelines.asp
    /// and
    ///    http://msdn.microsoft.com/library/default.asp?url=/library/en-us/dncscol/html/csharp07192001.asp
    /// </para>
    /// </remarks>
    public class DataException : Exception
    {
        /// <summary>
        /// Creates a new instance of this type.
        /// </summary>
        public DataException()
        {
        }

        /// <summary>
        /// Creates a new instance of this type.
        /// </summary>
        /// <param name="message">A message giving more detail about this exception.</param>
        public DataException(string message)
            : base(message)
        {
        }

        /// <summary>
        /// Creates a new instance of this type.
        /// </summary>
        /// <param name="message">A message giving more detail about this exception.</param>
        /// <param name="inner">The inner exception which caused this exception, or null.</param>
        public DataException(string message, Exception inner)
            : base(message, inner)
        {
        }

        /// <summary>
        /// Gets or sets the current SQLite platform, if available.
        /// </summary>
        public ISQLitePlatform Platform { get; set; }

        /// <summary>
        /// Gets or sets the current SQLite connection string, if available.
        /// </summary>
        public SQLiteConnectionString ConnectionString { get; set; }

        /// <summary>
        /// Gets or sets the device-specific I/O helper, if available.
        /// </summary>
        public IIOHelper IOHelper  { get; set; }
        
        /// <summary>
        /// Gets or sets the current SQLite connection pool, if available.
        /// </summary>
        public SQLiteConnectionPool ConnectionPool  { get; set; }


    }

    /// <summary>
    /// Exception class for errors within the Division42.Data namespace.
    /// </summary>
    /// <remarks>
    /// <para>
    /// For guidelines regarding the creation of new exception types, see:
    ///    http://msdn.microsoft.com/library/default.asp?url=/library/en-us/cpgenref/html/cpconerrorraisinghandlingguidelines.asp
    /// and
    ///    http://msdn.microsoft.com/library/default.asp?url=/library/en-us/dncscol/html/csharp07192001.asp
    /// </para>
    /// </remarks>
    public class DataException<TEntity> : DataException where TEntity: class,new()
    {
        /// <summary>
        /// Creates a new instance of this type.
        /// </summary>
        public DataException()
        {
        }

        /// <summary>
        /// Creates a new instance of this type.
        /// </summary>
        /// <param name="message">A message giving more detail about this exception.</param>
        public DataException(string message)
            : base(message)
        {
        }

        /// <summary>
        /// Creates a new instance of this type.
        /// </summary>
        /// <param name="message">A message giving more detail about this exception.</param>
        /// <param name="inner">The inner exception which caused this exception, or null.</param>
        public DataException(string message, Exception inner)
            : base(message, inner)
        {
        }

        /// <summary>
        /// Gets or sets the current repository, if available.
        /// </summary>
        public IRepository<TEntity> Repository { get; set; }
    }

    /// <summary>
    /// Exception class for errors within the Division42.Data namespace.
    /// </summary>
    /// <remarks>
    /// <para>
    /// For guidelines regarding the creation of new exception types, see:
    ///    http://msdn.microsoft.com/library/default.asp?url=/library/en-us/cpgenref/html/cpconerrorraisinghandlingguidelines.asp
    /// and
    ///    http://msdn.microsoft.com/library/default.asp?url=/library/en-us/dncscol/html/csharp07192001.asp
    /// </para>
    /// </remarks>
    public class DataException<TEntity, TKey> : DataException where TEntity : class,new()
    {
        /// <summary>
        /// Creates a new instance of this type.
        /// </summary>
        public DataException()
        {
        }

        /// <summary>
        /// Creates a new instance of this type.
        /// </summary>
        /// <param name="message">A message giving more detail about this exception.</param>
        public DataException(string message)
            : base(message)
        {
        }

        /// <summary>
        /// Creates a new instance of this type.
        /// </summary>
        /// <param name="message">A message giving more detail about this exception.</param>
        /// <param name="inner">The inner exception which caused this exception, or null.</param>
        public DataException(string message, Exception inner)
            : base(message, inner)
        {
        }

        /// <summary>
        /// Gets or sets the current repository, if available.
        /// </summary>
        public IRepository<TEntity, TKey> Repository { get; set; }
    }
}