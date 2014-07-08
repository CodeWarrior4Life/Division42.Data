using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Division42.Data.Tests
{
    [TestClass]
    public class NotifyPropertyChangedInvocatorAttributeTests
    {
        [TestMethod]
        public void ConstructorWithNoArguments_ReturnsValidInstance()
        {
            NotifyPropertyChangedInvocatorAttribute instance = new NotifyPropertyChangedInvocatorAttribute();

            Assert.IsNotNull(instance);
        }

        [TestMethod]
        public void ConstructorWithValidArgument_PopulatedProperty()
        {
            String expected = "UnitTest";
            String actual = String.Empty;
            NotifyPropertyChangedInvocatorAttribute instance = new NotifyPropertyChangedInvocatorAttribute(expected);
            
            actual = instance.ParameterName;

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void ConstructorWithEmptyArgument_PopulatedProperty()
        {
            String expected = String.Empty;
            String actual = "NOT Empty.";
            NotifyPropertyChangedInvocatorAttribute instance = new NotifyPropertyChangedInvocatorAttribute(expected);

            actual = instance.ParameterName;

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void ConstructorWithNullArgument_PopulatedProperty()
        {
            String expected = null;
            String actual = String.Empty;
            NotifyPropertyChangedInvocatorAttribute instance = new NotifyPropertyChangedInvocatorAttribute(expected);

            actual = instance.ParameterName;

            Assert.AreEqual(expected, actual);
        }


    }
}
