using System;
using System.Collections.Generic;
using GreetingRepo;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GreetingTests
{
    [TestClass]
    public class GreetingTests
    {
        CustomerRepo cRepo = new CustomerRepo();

        private static Customer CreateTestCustomer(string name, string name2)
        {
            string fname = name;
            string lname = name2;
            CustomerType type = CustomerType.Current;
            Customer newCustomer = new Customer(fname, lname, type);
            return newCustomer;
        }

        [TestMethod]
        public void CreateCustomerTest()
        {
            Customer newCustomer = CreateTestCustomer("Test", "LastName");
            cRepo.CreateCustomer(newCustomer);
            Assert.AreEqual(1, cRepo.GetAllCustomers().Count);
        }

        [TestMethod]
        public void GetAllCustomersTest()
        {
            for (int i = 0; i < 3; i++)
            {
                Customer testCustomer = CreateTestCustomer("Test", $"Customer {i}");
                cRepo.CreateCustomer(testCustomer);
            }
            Assert.AreEqual(3, cRepo.GetAllCustomers().Count);
        }

        [TestMethod]
        public void GetCustomerByLastNameTest()
        {
            Customer testCust = CreateTestCustomer("Test", "LastName");
            cRepo.CreateCustomer(testCust);
            Assert.AreEqual("LastName", cRepo.GetCustomerByLName(testCust.LastName).LastName);
        }

        [TestMethod]
        public void UpdateCustomerTest()
        {
            Customer testCust = CreateTestCustomer("Robot", "Customer");
            cRepo.CreateCustomer(testCust);
            Customer newCust = CreateTestCustomer("Human", "Customer");
            cRepo.UpdateCustomer(testCust.LastName, newCust);
            Assert.AreEqual("Human", testCust.FirstName);
        }

        [TestMethod]
        public void DeleteCustomerTest()
        {
            Customer testCust = CreateTestCustomer("Julius", "Caesar");
            cRepo.CreateCustomer(testCust);
            Assert.IsTrue(cRepo.DeleteCustomer(testCust.LastName));
        }

        [TestMethod]
        public void PopulateCustomersTest()
        {
            cRepo.PopulateCustomers();
            Assert.AreEqual(3, cRepo.GetAllCustomers().Count);
        }
    }
}
