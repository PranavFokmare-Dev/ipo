using Microsoft.VisualStudio.TestTools.UnitTesting;
using ipo.Models.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entitites.Models;

namespace ipo.Models.Validation.Tests
{
    [TestClass()]
    public class CheckValidatorTests
    {
        [TestMethod()]
        public void CheckValidatorTest_NoValidValues()
        {
            CheckValidator check = new CheckValidator();
            bool value = check.IsValid("1");
            Assert.IsTrue(value);
        }
        [TestMethod()]
        public void CheckValidatorTest_NoInput()
        {
            CheckValidator check = new CheckValidator();
            bool value = check.IsValid(null);
            Assert.IsTrue(value);
        }
        [TestMethod()]
        public void CheckValidatorTest_ipValidValue()
        {
            CheckValidator check = new CheckValidator("1","2");
            bool value = check.IsValid("1");
            Assert.IsTrue(value);
        }
        [TestMethod()]
        public void CheckValidatorTest_ipInValidValue()
        {
            CheckValidator check = new CheckValidator("1", "2");
            bool value = check.IsValid("3");
            Assert.AreEqual(false,value);
        }

        [TestMethod()]
        public void CheckValidatorTest_ipInt_valid()
        {
            CheckValidator check = new CheckValidator(1,2);
            bool value = check.IsValid(2);
            Assert.IsTrue(value);
        }
        [TestMethod()]
        public void CheckValidatorTest_ipInt_invalid()
        {
            CheckValidator check = new CheckValidator(1, 2);
            bool value = check.IsValid(3);
            Assert.AreEqual(false, value);

        }
        [TestMethod()]
        public void IsValidTest()
        {

        }
    }

    [TestClass()]
    public class ExchangeCheckValidatorTest
    {
        [TestMethod()]
        public void ExchangeTest_ExchangeNameNotSet()
        {
            Exchange e = new Exchange();
            CheckValidator check = new CheckValidator("BSE","NSE");
            bool valid = check.IsValid(e.ExchangeName);
            Assert.IsTrue(valid);
        }
        [TestMethod()]
        public void ExchangeTest_ExchangeNameBSE()
        {
            Exchange e = new Exchange();
            CheckValidator check = new CheckValidator("BSE", "NSE");
            e.ExchangeName = "BSE";

            bool valid = check.IsValid(e.ExchangeName);
            Assert.IsTrue(valid);
        }
    }
}