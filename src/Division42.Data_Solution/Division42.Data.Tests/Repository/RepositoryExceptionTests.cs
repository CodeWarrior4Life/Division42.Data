using System;
using Division42.Data.Repository;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Division42.Data.Tests.Repository
{
    [TestClass]
    public class RepositoryExceptionTests
    {
        [TestMethod]
        public void ConstructorWithNoArguments_ReturnsInstance()
        {
            RepositoryException instance = new RepositoryException();

            Assert.IsNotNull(instance);
        }

        [TestMethod]
        public void ConstructorWithValidMessage_ShouldPopulateProperty()
        {
            String expected = "The quick brown fox jumped over the lazy dog.";
            String actual = String.Empty;

            RepositoryException instance = new RepositoryException(expected);
            actual = instance.Message;

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void ConstructorWithNullMessage_ShouldPopulatePropertyDefault()
        {
            String expected = "Exception of type 'Division42.Data.Repository.RepositoryException' was thrown.";
            String actual = String.Empty;

            RepositoryException instance = new RepositoryException(null);
            actual = instance.Message;

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void ConstructorWithEmptyMessage_ShouldPopulateProperty()
        {
            String expected = String.Empty;
            String actual = "NOT empty.";

            RepositoryException instance = new RepositoryException(expected);
            actual = instance.Message;

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void ConstructorWithValidMessageAndException_ShouldPopulateProperty()
        {
            Exception expected = new InvalidTimeZoneException("Unit Test");
            Exception actual = null;

            RepositoryException instance = new RepositoryException("The quick brown fox jumped over the lazy dog.", expected);
            actual = instance.InnerException;

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void ConstructorWithNullMessageAndValidException_ShouldPopulatePropertyDefault()
        {
            Exception expected = new InvalidTimeZoneException("Unit Test");
            Exception actual = null;

            RepositoryException instance = new RepositoryException(null, expected);
            actual = instance.InnerException;

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void ConstructorWithEmptyMessageAndValidException_ShouldPopulateProperty()
        {
            Exception expected = new InvalidTimeZoneException("Unit Test");
            Exception actual = null;

            RepositoryException instance = new RepositoryException(String.Empty, expected);
            actual = instance.InnerException;

            Assert.AreEqual(expected, actual);
        }
    }
}
