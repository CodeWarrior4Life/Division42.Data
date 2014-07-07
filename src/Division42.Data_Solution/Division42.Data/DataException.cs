using System;
using SQLite.Net;
using SQLite.Net.Interop;

namespace Division42.Data
{
    /// <summary>
    /// Exception class for errors within the Division42.PropertyManager.Data namespace.
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

        public ISQLitePlatform Platform { get; set; }
        public SQLiteConnectionString ConnectionString { get; set; }
        public IIOHelper IOHelper  { get; set; }
        public SQLiteConnectionPool ConnectionPool  { get; set; }
    }
}