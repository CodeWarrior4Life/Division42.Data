using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using SQLite.Net.Attributes;

namespace Division42.Data.Tests.Mocks
{
    /// <summary>
    /// Sample observable data structure for unit testing.
    /// </summary>
    public class Customer : ObservableBase
    {
        /// <summary>
        /// Gets or sets the customer ID.
        /// </summary>
        [PrimaryKey]
        public Guid CustomerId
        {
            get { return _customerId; }
            set { _customerId = value; OnPropertyChanged(); }
        } private Guid _customerId;

        /// <summary>
        /// Gets or sets the first name.
        /// </summary>
        public String FirstName
        {
            get { return _firstName; }
            set { _firstName = value; OnPropertyChanged(); }
        } private String _firstName;

        /// <summary>
        /// Gets or sets the last name.
        /// </summary>
        public String LastName
        {
            get { return _lastName; }
            set { _lastName = value; OnPropertyChanged(); }
        } private String _lastName;
    }
}
