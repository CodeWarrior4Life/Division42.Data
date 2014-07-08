using System;
using Division42.Data.Tests.Mocks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Division42.Data.Tests
{
    [TestClass]
    public class DisposableBaseTests
    {
        [TestMethod]
        public void Constructor_CreatesValidInstance()
        {
            DisposableMock instance = new DisposableMock();

            Assert.IsNotNull(instance);
        }

        [TestMethod]
        public void CallMethodWhileNotDisposed_ShouldNotThrowException()
        {
            DisposableMock instance = new DisposableMock();
            
            instance.DoNothing();
            
            // No exception should be thrown.
        }

        [TestMethod]
        [ExpectedException(typeof(ObjectDisposedException))]
        public void CallMethodAfterDisposed_ShouldThrowObjectDisposedException()
        {
            DisposableMock instance = new DisposableMock();
            instance.Dispose();
            instance.DoNothing();

            Assert.Fail("Should have thrown ObjectDisposedException.");
        }
    }
}
