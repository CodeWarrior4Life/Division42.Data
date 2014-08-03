using System;
using System.Collections.Generic;
using System.Linq;
using Division42.Data.Repository;

namespace Division42.Data.Tests.Mocks
{
    public class CustomerWithInferredKeyInProcRepository : InProcRepositoryBase<Customer>
    {
        /// <summary>
        /// Creates a new instance of this type.
        /// </summary>
        public CustomerWithInferredKeyInProcRepository()
            : base()
        {
        }

        /// <summary>
        /// Creates a new instance of this type.
        /// </summary>
        /// <param name="initialList">Records to pre-include in the repository.</param>
        public CustomerWithInferredKeyInProcRepository(IEnumerable<Customer> initialList)
            : base(initialList)
        {
        }

        /// <summary>
        /// Gets a record by the specified ID.
        /// </summary>
        /// <param name="id">The id, or primary key of the record to retrieve.</param>
        public override Customer GetById(Guid id)
        {
            CheckIfDisposed();

            return this.GetAll().FirstOrDefault(item => item.CustomerId.Equals(id));
        }

        /// <summary>
        /// Updates an existing record.
        /// </summary>
        /// <param name="instance">The updated record.</param>
        /// <exception cref="System.ArgumentNullException"></exception>
        public override void Update(Customer instance)
        {
            CheckIfDisposed();

            if (instance == null)
                throw new ArgumentNullException("instance");

            Customer oldItem = GetById(instance.CustomerId);
            Delete(oldItem);
            Insert(instance);
        }
    }
}