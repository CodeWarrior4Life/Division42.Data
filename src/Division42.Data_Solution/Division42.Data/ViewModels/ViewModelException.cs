using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite.Net;
using SQLite.Net.Interop;

namespace Division42.Data.ViewModels
{
    /// <summary>
    /// Exception class for errors within the Division42.Data.ViewModels namespace.
    /// </summary>
    /// <remarks>
    /// <para>
    /// For guidelines regarding the creation of new exception types, see:
    ///    http://msdn.microsoft.com/library/default.asp?url=/library/en-us/cpgenref/html/cpconerrorraisinghandlingguidelines.asp
    /// and
    ///    http://msdn.microsoft.com/library/default.asp?url=/library/en-us/dncscol/html/csharp07192001.asp
    /// </para>
    /// </remarks>
    public class ViewModelException : DataException
    {
        /// <summary>
        /// Creates a new instance of this type.
        /// </summary>
        public ViewModelException()
        {
        }

        /// <summary>
        /// Creates a new instance of this type.
        /// </summary>
        /// <param name="message">A message giving more detail about this exception.</param>
        public ViewModelException(string message)
            : base(message)
        {
        }

        /// <summary>
        /// Creates a new instance of this type.
        /// </summary>
        /// <param name="message">A message giving more detail about this exception.</param>
        /// <param name="inner">The inner exception which caused this exception, or null.</param>
        public ViewModelException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}
