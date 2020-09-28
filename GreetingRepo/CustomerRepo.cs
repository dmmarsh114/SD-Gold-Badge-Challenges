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

        public Customer GetCustomerByLName(string lname)
        {
            foreach (Customer c in _customers)
            {
                if (lname.ToUpper() == c.LastName.ToUpper())
                {
                    return c;
                }
            }
            return null;
        }

        // Update
        public bool UpdateCustomer(string originalLName, Customer newCustomer)
        {
            Customer oldCustomer = GetCustomerByLName(originalLName);
            if (oldCustomer == null) { return false; }

            oldCustomer.FirstName = newCustomer.FirstName;
            oldCustomer.LastName = newCustomer.LastName;
            oldCustomer.TypeOfCustomer = newCustomer.TypeOfCustomer;
            oldCustomer.Email = Customer.CreateEmail(newCustomer.TypeOfCustomer);            

            return true;
        }

        // Delete
        public bool DeleteCustomer(string lname)
        {
            Customer customerToDelete = GetCustomerByLName(lname);
            if (customerToDelete == null) { return false; }

            int initialCount = _customers.Count;
            _customers.Remove(customerToDelete);

            if (initialCount > _customers.Count) { return true; }
            return false;
        }

        // Helper
        public void PopulateCustomers()
        {
            for (int i = 1; i <= 3; i++)
            {
                string fname = $"Robot";
                string lname = $"Customer {i}";
                CustomerType type = (CustomerType)i;
                Customer customerToAdd = new Customer(fname, lname, type);
                CreateCustomer(customerToAdd);
            }
        }
    }
}
