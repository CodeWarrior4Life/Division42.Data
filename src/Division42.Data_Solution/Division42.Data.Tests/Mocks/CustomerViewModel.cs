using Division42.Data.Repository;
using Division42.Data.ViewModels;

namespace Division42.Data.Tests.Mocks
{
    public class CustomerViewModel : ViewModelBase<Customer>
    {
        /// <summary>
        /// Creates a new instance of this type.
        /// </summary>
        /// <param name="repository">The repository to use for the primary data type.</param>
        public CustomerViewModel(IRepository<Customer> repository) : base(repository)
        {
        }
    }
}