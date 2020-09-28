using GreetingRepo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace Badges
{
    public class GreetingUI
    {
        CustomerRepo cRepo = new CustomerRepo();

        public void Run()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Welcome to Komodo Greeting App!");
            cRepo.PopulateCustomers();

            bool running = true;
            while (running)
            {
                Console.ForegroundColor = ConsoleColor.White;
                Console.ReadKey();
                Console.Clear();
                running = MainMenu(running);
            }
        }

        private bool MainMenu(bool running)
        {
            Console.WriteLine("Please choose an option from below:\n" +
                "1. View All Customers\n" +
                "2. Add a new Customer\n" +
                "3. Edit an existing Customer\n" +
                "4. Delete a Customer\n" +
                "5. Exit");
            string input = Console.ReadLine();
            Console.Clear();

            switch (input)
            {
                case "1":
                    ViewAllCustomers();
                    break;
                case "2":
                    AddNewCustomer();
                    break;
                case "3":
                    EditCustomer();
                    break;
                case "4":
                    DeleteCustomer();
                    break;
                case "5":
                    Console.WriteLine("Goodbye!");
                    Console.Clear();
                    running = false;
                    break;
                default:
                    Console.WriteLine("That is an invalid selection. Please type a number between 1 and 5.");
                    break;
            }

            return running;
        }

        private void ViewAllCustomers()
        {
            List<Customer> customers = cRepo.GetAllCustomers();
            foreach (Customer c in customers)
            {
                PrintCustomerData(c);
                Console.WriteLine("==========================================================");
            }
        }

        private void AddNewCustomer()
        {
            Console.Clear();
            Console.WriteLine("Please enter the customer's first name:");
            string fname = Console.ReadLine();

            Console.Clear();
            Console.WriteLine("Please enter the customer's last name");
            string lname = Console.ReadLine();

            Console.Clear();
            CustomerType type = SelectCustomerType();

            Customer newCustomer = new Customer(fname, lname, type);
            cRepo.CreateCustomer(newCustomer);

            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Customer added!");
            Console.ForegroundColor = ConsoleColor.White;

            PrintCustomerData(newCustomer);
        }

        private void EditCustomer()
        {
            Console.WriteLine("Please enter the last name of the customer you wish to edit:");
            string lname = Console.ReadLine();
            // TODO: Extract this method ?
            Customer customerToEdit = cRepo.GetCustomerByLName(lname);
            if (customerToEdit == null)
            {
                Console.Clear();
                Console.WriteLine("Sorry, I could not find that customer.");
                return;
            }

            Customer newCustomer = new Customer(customerToEdit.FirstName, customerToEdit.LastName, customerToEdit.TypeOfCustomer);

            Console.Clear();
            PrintCustomerData(customerToEdit);
            Console.WriteLine("\nWhat would you like to edit about this customer?\n" +
                "1. First Name\n" +
                "2. Last Name\n" +
                "3. Type");
            string input = Console.ReadLine(); 
            Console.Clear();

            switch (input)
            {
                case "1":
                    Console.WriteLine("Please enter a new value for the customer's first name:");
                    string newFName = Console.ReadLine();
                    newCustomer.FirstName = newFName;
                    break;
                case "2":
                    Console.WriteLine("Please enter a new value for the customer's last name:"); 
                    string newLName = Console.ReadLine();
                    newCustomer.LastName = newLName;
                    break;
                case "3":
                    CustomerType newType = SelectCustomerType();
                    newCustomer.TypeOfCustomer = newType;
                    break;
                default:
                    Console.WriteLine("That is an invalid selection.");
                    return;
            }

            bool success = cRepo.UpdateCustomer(customerToEdit.LastName, newCustomer);
            if (!success)
            {
                Console.WriteLine("Something went wrong. The new data could not be processed.");
                return;
            }

            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Customer Updated!");
            Console.ForegroundColor = ConsoleColor.White;
            PrintCustomerData(customerToEdit);
        }

        private void DeleteCustomer()
        {
            Console.WriteLine("Please enter the last name of the customer you wish to delete:");
            string lname = Console.ReadLine();
            // TODO: Extract this method ?
            Customer customerToDelete = cRepo.GetCustomerByLName(lname);
            if (customerToDelete == null)
            {
                Console.Clear();
                Console.WriteLine("Sorry, I could not find that customer.");
                return;
            }

            bool success = cRepo.DeleteCustomer(customerToDelete.LastName);
            if (!success)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"Something went wrong. Customer {customerToDelete.LastName} could not be deleted.");
                return;
            }
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Customer successfully deleted!");
        }

        // Helper
        private static void PrintCustomerData(Customer c)
        {
            Console.WriteLine(
                $"FName: {c.FirstName}\n" +
                $"LName: {c.LastName}\n" +
                $"Type: {c.TypeOfCustomer}\n" +
                $"Email: {c.Email}");
        }

        private static CustomerType SelectCustomerType()
        {
            CustomerType type;
            Console.WriteLine("What is the customer's type?\n" +
                "1. Current\n" +
                "2. Past\n" +
                "3. Potential");
            string typeInput = Console.ReadLine();
            bool parseable = Int32.TryParse(typeInput, out int typeInt);
            if (!parseable || typeInt > 3)
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("That is an invalid selection. Setting type to 'Potential'.");
                Console.ForegroundColor = ConsoleColor.White;
                type = CustomerType.Potential;
                Console.ReadKey();
                Console.Clear();
            }
            else
            {
                type = (CustomerType)typeInt;
            }

            return type;
        }
    }
}
