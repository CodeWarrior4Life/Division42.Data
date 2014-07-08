using System;
using Division42.Data.ViewModels;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Division42.Data.Tests.ViewModels
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void ConstructorWithNoArguments_ReturnsInstance()
        {
            ViewModelException instance = new ViewModelException();

            Assert.IsNotNull(instance);
        }

        [TestMethod]
        public void ConstructorWithValidMessage_ShouldPopulateProperty()
        {
            String expected = "The quick brown fox jumped over the lazy dog.";
            String actual = String.Empty;

            ViewModelException instance = new ViewModelException(expected);
            actual = instance.Message;

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void ConstructorWithNullMessage_ShouldPopulatePropertyDefault()
        {
            String expected = "Exception of type 'Division42.Data.ViewModels.ViewModelException' was thrown.";
            String actual = String.Empty;

            ViewModelException instance = new ViewModelException(null);
            actual = instance.Message;

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void ConstructorWithEmptyMessage_ShouldPopulateProperty()
        {
            String expected = String.Empty;
            String actual = "NOT empty.";

            ViewModelException instance = new ViewModelException(expected);
            actual = instance.Message;

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void ConstructorWithValidMessageAndException_ShouldPopulateProperty()
        {
            Exception expected = new InvalidTimeZoneException("Unit Test");
            Exception actual = null;

            ViewModelException instance = new ViewModelException("The quick brown fox jumped over the lazy dog.", expected);
            actual = instance.InnerException;

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void ConstructorWithNullMessageAndValidException_ShouldPopulatePropertyDefault()
        {
            Exception expected = new InvalidTimeZoneException("Unit Test");
            Exception actual = null;

            ViewModelException instance = new ViewModelException(null, expected);
            actual = instance.InnerException;

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void ConstructorWithEmptyMessageAndValidException_ShouldPopulateProperty()
        {
            Exception expected = new InvalidTimeZoneException("Unit Test");
            Exception actual = null;

            ViewModelException instance = new ViewModelException(String.Empty, expected);
            actual = instance.InnerException;

            Assert.AreEqual(expected, actual);
        }
    }
}
