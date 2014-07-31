using System;
using System.Collections.ObjectModel;
using Division42.Data.Repository;
using Division42.Data.Tests.Mocks;
using Division42.Data.ViewModels;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Division42.Data.Tests.ViewModels
{
    [TestClass]
    public class ViewModelRefresherTests
    {
        [TestMethod]
        public void ConstructorWithValidArguments_ShouldReturnValidInstance()
        {
            IRepository<Customer,Guid> repository = new CustomerInProcRepository();
            ObservableCollection<Customer> collection = new ObservableCollection<Customer>();
            ViewModelRefresher<Customer> instance = new ViewModelRefresher<Customer>(collection, repository);

            Assert.IsNotNull(instance);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void ConstructorWithNullCollection_ShouldThrowArgumentNullException()
        {
            IRepository<Customer, Guid> repository = new CustomerInProcRepository();
            ObservableCollection<Customer> collection = null;
            ViewModelRefresher<Customer> instance = new ViewModelRefresher<Customer>(collection, repository);

            Assert.Fail("Should have thrown an ArgumentNullException.");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void ConstructorWithNullRepository_ShouldThrowArgumentNullException()
        {
            IRepository<Customer, Guid> repository = null;
            ObservableCollection<Customer> collection = new ObservableCollection<Customer>();
            ViewModelRefresher<Customer> instance = new ViewModelRefresher<Customer>(collection, repository);

            Assert.Fail("Should have thrown an ArgumentNullException.");
        }

        [TestMethod]
        public void DefaultCanExecute_ShouldBeTrue()
        {
            Boolean expected = true;
            Boolean actual = false;

            IRepository<Customer, Guid> repository = new CustomerInProcRepository();
            ObservableCollection<Customer> collection = new ObservableCollection<Customer>();
            ViewModelRefresher<Customer> instance = new ViewModelRefresher<Customer>(collection, repository);

            actual = instance.CanExecute(null);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Execute_ShouldFireEventTwice()
        {
            Int32 expected = 2;
            Int32 actual = 0;

            IRepository<Customer, Guid> repository = new CustomerInProcRepository();
            ObservableCollection<Customer> collection = new ObservableCollection<Customer>();
            ViewModelRefresher<Customer> instance = new ViewModelRefresher<Customer>(collection, repository);

            // Should fire twice: once to disallow execution, then again to allow.
            instance.CanExecuteChanged += (sender, e) => { actual ++; };
            instance.Execute(null);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void ExecuteWithMissingItems_ShouldUpdateCollection()
        {
            Int32 expected = 1;
            Int32 actual = 0;

            IRepository<Customer, Guid> repository = new CustomerInProcRepository();
            ObservableCollection<Customer> collection = new ObservableCollection<Customer>();
            repository.Insert(new Customer() { CustomerId = Guid.NewGuid() });

            // Nothing in collection; add 1 to repository; execute; collection has 1
            ViewModelRefresher<Customer> instance = new ViewModelRefresher<Customer>(collection, repository);
            instance.Execute(null);
            actual = collection.Count;

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void ExecuteWithStaleItems_ShouldUpdateCollection()
        {
            Int32 expected = 0;
            Int32 actual = 0;

            IRepository<Customer, Guid> repository = new CustomerInProcRepository();
            ObservableCollection<Customer> collection = new ObservableCollection<Customer>();
            collection.Add(new Customer() { CustomerId = Guid.NewGuid() });

            // 1 in collection; nothing in repository; execute; collection has 0
            ViewModelRefresher<Customer> instance = new ViewModelRefresher<Customer>(collection, repository);
            instance.Execute(null);
            actual = collection.Count;

            Assert.AreEqual(expected, actual);
        }
    }
}
