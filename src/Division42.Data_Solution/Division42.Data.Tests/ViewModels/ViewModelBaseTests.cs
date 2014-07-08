using System;
using Division42.Data.Repository;
using Division42.Data.Tests.Mocks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Division42.Data.Tests.ViewModels
{
    [TestClass]
    public class ViewModelBaseTests
    {
        [TestMethod]
        public void ConstructorWithValidRepository_ShouldReturnValidInstance()
        {
            IRepository<Customer> repository = new CustomerInProcRepository();
            CustomerViewModel instance = new CustomerViewModel(repository);

            Assert.IsNotNull(instance);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void ConstructorWithNullRepository_ShouldThrowArgumentNullException()
        {
            IRepository<Customer> repository = null;
            CustomerViewModel instance = new CustomerViewModel(repository);

            Assert.Fail("Should have thrown an ArgumentNullException.");
        }

        [TestMethod]
        public void EnsureDisposableIsImplemented_ShouldNotThrowException()
        {
            IRepository<Customer> repository = new CustomerInProcRepository();
            using (CustomerViewModel instance = new CustomerViewModel(repository))
            {
            }
        }

        [TestMethod]
        public void InvokeRefresh_ShouldNotThrowException()
        {
            IRepository<Customer> repository = new CustomerInProcRepository();
            using (CustomerViewModel instance = new CustomerViewModel(repository))
            {
                instance.Refresh.Execute(null);
            }
        }
    }
}
