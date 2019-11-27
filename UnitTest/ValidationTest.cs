using System;
using App;
using App.Enumerations;
using App.Validation;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTest
{
    [TestClass]
    public class ValidationTest
    {
        [TestMethod]
        public void TestValidateCorrectData()
        {
            // ARRANGE

            bool expected = true;

            // ACT
            bool  actual = Validation.Validate("Gregory", "Libert", "grego525@hotmail.com", new DateTime(1995,1,1));

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestValidateNoAtMailAddress()
        {
            // ARRANGE

            bool expected = false;

            // ACT
            bool actual = Validation.Validate("Gregory", "Libert", "grego525hotmail.com", new DateTime(1995, 1, 1));

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestValidateNoDotMailAddress()
        {
            // ARRANGE

            bool expected = false;

            // ACT
            bool actual = Validation.Validate("Gregory", "Libert", "grego525@hotmailcom", new DateTime(1995, 1, 1));

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestValidateNoFirstname()
        {
            // ARRANGE

            bool expected = false;

            // ACT
            bool actual = Validation.Validate("", "Libert", "grego525@hotmailcom", new DateTime(1995, 1, 1));

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestValidateNoLastname()
        {
            // ARRANGE

            bool expected = false;

            // ACT
            bool actual = Validation.Validate("Gregory", "", "grego525@hotmailcom", new DateTime(1995, 1, 1));

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestValidateIncorrectData()
        {
            // ARRANGE

            bool expected = false;

            // ACT
            bool actual = Validation.Validate("Gregory", "", "grego525hotmailcom", new DateTime(1995, 1, 1));

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestValidateAgeIncorrectData()
        {
            // ARRANGE

            bool expected = false;

            // ACT
            bool actual = Validation.Validate("Gregory", "Libert", "grego525@hotmail.com", new DateTime(1999,11,20));

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestValidateAgeCorrectData()
        {
            // ARRANGE

            bool expected = true;

            // ACT
            bool actual = Validation.Validate("Gregory", "Libert", "grego525@hotmail.com", new DateTime(1995, 11, 20));

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestValidateCustomerCorrectData()
        {
            // ARRANGE
            bool expected = true;

            // ACT
            var company = new Company
            {
                Id = 1,
                Name = "default",
                Classification = Classification.Gold
            };
            var customer = new TestCustomer("Gregory", "Libert", "grego525@hotmail.com", new DateTime(1995, 11, 20), company, 400, false);
            // Should mock the data
            bool actual = Validation.ValidateCustomer(customer);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestValidateCustomerCorrectData2()
        {
            // ARRANGE
            bool expected = true;

            // ACT
            var company = new Company
            {
                Id = 1,
                Name = "default",
                Classification = Classification.Gold
            };
            var customer = new TestCustomer("Gregory", "Libert", "grego525@hotmail.com", new DateTime(1995, 11, 20), company, 600, true);
            // Should mock the data
            bool actual = Validation.ValidateCustomer(customer);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestValidateCustomerIncorrectData()
        {
            // ARRANGE
            bool expected = false;

            // ACT
            var company = new Company
            {
                Id = 1,
                Name = "default",
                Classification = Classification.Gold
            };
            var customer = new TestCustomer("Gregory", "Libert", "grego525@hotmail.com", new DateTime(1995, 11, 20), company,400, true);
            // Should mock the data
            bool actual = Validation.ValidateCustomer(customer);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestAddCustomer()
        {
            // ARRANGE
            bool expected = true;

            // ACT
            var company = new Company
            {
                Id = 1,
                Name = "default",
                Classification = Classification.Gold
            };

            // Should mock the data
            var service = new CustomerServiceTest();
            bool actual = service.AddCustomer("Gregory", "Libert", "grego525@hotmail.com", new DateTime(1995, 11, 20),1);

            Assert.AreEqual(expected, actual);
        }


    }
}
