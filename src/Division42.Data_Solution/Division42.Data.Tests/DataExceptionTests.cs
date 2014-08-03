using System;
using Division42.Data.Tests.Mocks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Division42.Data.Tests
{
    [TestClass]
    public class DataExceptionTests
    {
        [TestMethod]
        public void ConstructorWithNoArguments_ReturnsInstance()
        {
            DataException instance = new DataException();

            Assert.IsNotNull(instance);
        }

        [TestMethod]
        public void ConstructorWithValidMessage_ShouldPopulateProperty()
        {
            String expected = "The quick brown fox jumped over the lazy dog.";
            String actual = String.Empty;

            DataException instance = new DataException(expected);
            actual = instance.Message;

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void ConstructorWithNullMessage_ShouldPopulatePropertyDefault()
        {
            String expected = "Exception of type 'Division42.Data.DataException' was thrown.";
            String actual = String.Empty;

            DataException instance = new DataException(null);
            actual = instance.Message;

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void ConstructorWithEmptyMessage_ShouldPopulateProperty()
        {
            String expected = String.Empty;
            String actual = "NOT empty.";

            DataException instance = new DataException(expected);
            actual = instance.Message;

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void ConstructorWithValidMessageAndException_ShouldPopulateProperty()
        {
            Exception expected = new InvalidTimeZoneException("Unit Test");
            Exception actual = null;

            DataException instance = new DataException("The quick brown fox jumped over the lazy dog.", expected);
            actual = instance.InnerException;

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void ConstructorWithNullMessageAndValidException_ShouldPopulatePropertyDefault()
        {
            Exception expected = new InvalidTimeZoneException("Unit Test");
            Exception actual = null;

            DataException instance = new DataException(null, expected);
            actual = instance.InnerException;

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void ConstructorWithEmptyMessageAndValidException_ShouldPopulateProperty()
        {
            Exception expected = new InvalidTimeZoneException("Unit Test");
            Exception actual = null;

            DataException instance = new DataException(String.Empty, expected);
            actual = instance.InnerException;

            Assert.AreEqual(expected, actual);
        }


        [TestMethod]
        public void GenericConstructorWithNoArguments_ReturnsInstance()
        {
            DataException<Customer> instance = new DataException<Customer>();

            Assert.IsNotNull(instance);
        }

        [TestMethod]
        public void GenericConstructorWithValidMessage_ShouldPopulateProperty()
        {
            String expected = "The quick brown fox jumped over the lazy dog.";
            String actual = String.Empty;

            DataException<Customer> instance = new DataException<Customer>(expected);
            actual = instance.Message;

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void GenericConstructorWithNullMessage_ShouldPopulatePropertyDefault()
        {
            String expected = "Exception of type 'Division42.Data.DataException`1[Division42.Data.Tests.Mocks.Customer]' was thrown.";
            String actual = String.Empty;

            DataException<Customer> instance = new DataException<Customer>(null);
            actual = instance.Message;

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void GenericConstructorWithEmptyMessage_ShouldPopulateProperty()
        {
            String expected = String.Empty;
            String actual = "NOT empty.";

            DataException<Customer> instance = new DataException<Customer>(expected);
            actual = instance.Message;

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void GenericConstructorWithValidMessageAndException_ShouldPopulateProperty()
        {
            Exception expected = new InvalidTimeZoneException("Unit Test");
            Exception actual = null;

            DataException<Customer> instance = new DataException<Customer>("The quick brown fox jumped over the lazy dog.", expected);
            actual = instance.InnerException;

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void GenericConstructorWithNullMessageAndValidException_ShouldPopulatePropertyDefault()
        {
            Exception expected = new InvalidTimeZoneException("Unit Test");
            Exception actual = null;

            DataException<Customer> instance = new DataException<Customer>(null, expected);
            actual = instance.InnerException;

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void GenericConstructorWithEmptyMessageAndValidException_ShouldPopulateProperty()
        {
            Exception expected = new InvalidTimeZoneException("Unit Test");
            Exception actual = null;

            DataException<Customer> instance = new DataException<Customer>(String.Empty, expected);
            actual = instance.InnerException;

            Assert.AreEqual(expected, actual);
        }


        [TestMethod]
        public void GenericWithKeyConstructorWithNoArguments_ReturnsInstance()
        {
            DataException<Customer, Guid> instance = new DataException<Customer, Guid>();

            Assert.IsNotNull(instance);
        }

        [TestMethod]
        public void GenericWithKeyConstructorWithValidMessage_ShouldPopulateProperty()
        {
            String expected = "The quick brown fox jumped over the lazy dog.";
            String actual = String.Empty;

            DataException<Customer, Guid> instance = new DataException<Customer, Guid>(expected);
            actual = instance.Message;

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void GenericWithKeyConstructorWithNullMessage_ShouldPopulatePropertyDefault()
        {
            String expected = "Exception of type 'Division42.Data.DataException`2[Division42.Data.Tests.Mocks.Customer,System.Guid]' was thrown.";
            String actual = String.Empty;

            DataException<Customer, Guid> instance = new DataException<Customer, Guid>(null);
            actual = instance.Message;

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void GenericWithKeyConstructorWithEmptyMessage_ShouldPopulateProperty()
        {
            String expected = String.Empty;
            String actual = "NOT empty.";

            DataException<Customer, Guid> instance = new DataException<Customer, Guid>(expected);
            actual = instance.Message;

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void GenericWithKeyConstructorWithValidMessageAndException_ShouldPopulateProperty()
        {
            Exception expected = new InvalidTimeZoneException("Unit Test");
            Exception actual = null;

            DataException<Customer, Guid> instance = new DataException<Customer, Guid>("The quick brown fox jumped over the lazy dog.", expected);
            actual = instance.InnerException;

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void GenericWithKeyConstructorWithNullMessageAndValidException_ShouldPopulatePropertyDefault()
        {
            Exception expected = new InvalidTimeZoneException("Unit Test");
            Exception actual = null;

            DataException<Customer, Guid> instance = new DataException<Customer, Guid>(null, expected);
            actual = instance.InnerException;

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void GenericWithKeyConstructorWithEmptyMessageAndValidException_ShouldPopulateProperty()
        {
            Exception expected = new InvalidTimeZoneException("Unit Test");
            Exception actual = null;

            DataException<Customer, Guid> instance = new DataException<Customer, Guid>(String.Empty, expected);
            actual = instance.InnerException;

            Assert.AreEqual(expected, actual);
        }
    }
}
