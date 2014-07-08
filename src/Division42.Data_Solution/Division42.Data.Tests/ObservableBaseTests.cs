using System;
using Division42.Data.Tests.Mocks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Division42.Data.Tests
{
    [TestClass]
    public class ObservableBaseTests
    {
        [TestMethod]
        public void ChangeProperty_ShouldFireEvent()
        {
            Boolean expected = true;
            Boolean actual = false;
            
            Customer instance = new Customer();
            instance.PropertyChanged += (sender, e) =>
            {
                if (e.PropertyName == "FirstName") 
                    actual = true;
            };

            instance.FirstName = "Unit Test";

            Assert.AreEqual(expected, actual);
        }
    }
}
