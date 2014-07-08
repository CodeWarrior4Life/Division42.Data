using System;
using System.Collections.Generic;
using System.Linq;
using Division42.Data.Tests.Mocks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SQLite.Net;
using SQLite.Net.Platform.Win32;

namespace Division42.Data.Tests.Repository
{
    [TestClass]
    public class InProcRepositoryBaseTests
    {
        [TestMethod]
        public void ConstructorWithNoArguments_ReturnsValidInstance()
        {
            CustomerInProcRepository repository = new CustomerInProcRepository();

            Assert.IsNotNull(repository);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void ConstructorWithNullList_ReturnsValidInstance()
        {
            CustomerInProcRepository repository = new CustomerInProcRepository(null);

            Assert.Fail("Should have thrown ArgumentNullException.");
        }

        [TestMethod]
        [ExpectedException(typeof(ObjectDisposedException))]
        public void GetAllAfterDispose_ShouldThrowException()
        {
            CustomerInProcRepository repository = new CustomerInProcRepository();

            repository.Dispose();
            repository.GetAll().ToList();

            Assert.Fail("Should have thrown an ObjectDisposedException.");
        }

        [TestMethod]
        public void GetAll_ReturnsExpected()
        {
            Int32 expected = 2;
            Int32 actual = -1;

            Customer customer1 = new Customer() { CustomerId = Guid.NewGuid() };
            Customer customer2 = new Customer() { CustomerId = Guid.NewGuid() };
            List<Customer> list = new List<Customer> {customer1, customer2};

            using (CustomerInProcRepository repository = new CustomerInProcRepository(list))
            {
                IEnumerable<Customer> customers = repository.GetAll().ToList();
                actual = customers.Count();

                Assert.AreEqual(expected, actual);
            }
        }

        [TestMethod]
        public void GetByIdWithValidId_ReturnsExpected()
        {
            Customer expected = new Customer() { CustomerId = Guid.NewGuid() };
            Customer actual;
            List<Customer> list = new List<Customer> { expected };

            using (CustomerInProcRepository repository = new CustomerInProcRepository(list))
            {
                actual = repository.GetById(expected.CustomerId);

                Assert.AreEqual(expected, actual);
            }
        }

        [TestMethod]
        public void GetByFilterWithValidArgument_ReturnsExpected()
        {
            Customer expected = new Customer() { CustomerId = Guid.NewGuid() };
            Customer actual;
            List<Customer> list = new List<Customer> { expected };

            using (CustomerInProcRepository repository = new CustomerInProcRepository(list))
            {
                actual = repository.GetByFilter(item=>item.CustomerId.Equals(expected.CustomerId));

                Assert.AreEqual(expected, actual);
            }
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void GetByFilterWithNullArgument_ShouldThrowException()
        {
            using (CustomerInProcRepository repository = new CustomerInProcRepository())
            {
                repository.GetByFilter(null);

                Assert.Fail("Should have thrown an ArgumentNullException.");
            }
        }

        [TestMethod]
        public void InsertWithValidItem_ShouldBeRetrievable()
        {
            Customer expected = new Customer() { CustomerId = Guid.NewGuid() };
            Customer actual;

            using (CustomerInProcRepository repository = new CustomerInProcRepository())
            {
                repository.Insert(expected);

                actual = repository.GetById(expected.CustomerId);

                Assert.AreEqual(expected, actual);
            }
        }

        [TestMethod]
        public void UpdateWithValidItem_ShouldUpdate()
        {
            String expected = "Unittest";
            String actual;

            Customer customer = new Customer() { CustomerId = Guid.NewGuid() };
            List<Customer> list = new List<Customer> { customer };

            using (CustomerInProcRepository repository = new CustomerInProcRepository(list))
            {
                customer.FirstName = expected;
                repository.Update(customer);

                actual = repository.GetById(customer.CustomerId).FirstName;

                Assert.AreEqual(expected, actual);
            }
        }

        [TestMethod]
        public void DeleteWithValidItem_ShouldDelete()
        {
            Customer actual;
            Customer customer = new Customer() { CustomerId = Guid.NewGuid() };
            List<Customer> list = new List<Customer> { customer };

            using (CustomerInProcRepository repository = new CustomerInProcRepository(list))
            {
                repository.Delete(customer);

                actual = repository.GetById(customer.CustomerId);

                Assert.IsNull(actual);
            }
        }


        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void InsertWithNullArgument_ShouldThrowException()
        {
            using (CustomerInProcRepository repository = new CustomerInProcRepository())
            {
                repository.Insert(null);

                Assert.Fail("Should have thrown an ArgumentNullException.");
            }
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void UpdateWithNullArgument_ShouldThrowException()
        {
            using (CustomerInProcRepository repository = new CustomerInProcRepository())
            {
                repository.Update(null);

                Assert.Fail("Should have thrown an ArgumentNullException.");
            }
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void DeleteWithNullArgument_ShouldThrowException()
        {
            using (CustomerInProcRepository repository = new CustomerInProcRepository())
            {
                repository.Delete(null);

                Assert.Fail("Should have thrown an ArgumentNullException.");
            }
        }
    }
}
