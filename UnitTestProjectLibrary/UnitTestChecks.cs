using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BookLib;
using FluentAssertions;

namespace UnitTestProjectLibrary
{
    [TestClass]
    public class UnitTestChecks
    {
        [TestMethod]
        public void IsNotEmptyNullOrWhiteCheckTrue()
        {
            Checks.IsNotEmptyNullOrWhite("hfdj").Should().Be(true);
        }
        [TestMethod]
        public void IsNotEmptyNullOrWhiteCheckSpeace()
        {
            Checks.IsNotEmptyNullOrWhite("     ").Should().Be(false);
        }
        [TestMethod]
        public void IsNotEmptyNullOrWhiteCheckEmpty()
        {
            Checks.IsNotEmptyNullOrWhite("").Should().Be(false);
        }
        [TestMethod]
        public void isTextDoubleCheckTrue()
        {
            Checks.isTextDouble("4354232").Should().Be(true);
            
        }
        [TestMethod]
        public void isTextDoubleCheckFalse()
        {
            Checks.isTextDouble("dsfgst435").Should().Be(false);
        }
        [TestMethod]
        public void isTextIntTrue()
        {
            Checks.isTextInt("45").Should().Be(true);
        }
        [TestMethod]
        public void isTextIntFalse()
        {
            Checks.isTextInt("5.567").Should().Be(false);
        }

    }
}
