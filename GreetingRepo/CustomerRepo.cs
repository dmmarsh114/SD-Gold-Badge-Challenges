using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreetingRepo
{
    public class CustomerRepo
    {
        private List<Customer> _customers = new List<Customer>();

        // Create
        public void CreateCustomer(Customer customerToCreate)
        {
            _customers.Add(customerToCreate);
        }

        // Read
        public List<Customer> GetAllCustomers()
        {
            return _customers;
        }

        // Update
        // Delete
        // Helper
        public void PopulateCustomers()
        {
            for (int i = 1; i <= 3; i++)
            {
                string fname = $"Test";
                string lname = $"Robot{i}";
                CustomerType type = (CustomerType)i;
                Customer customerToAdd = new Customer(fname, lname, type);
                CreateCustomer(customerToAdd);
            }
        }
    }
}
