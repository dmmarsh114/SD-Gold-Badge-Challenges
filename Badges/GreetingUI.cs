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

            bool running = true;
            while (running)
            {
                Console.ForegroundColor = ConsoleColor.White;
                Console.ReadKey();
                Console.Clear();

                cRepo.PopulateCustomers();

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
            }
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
            CustomerType type;
            Console.WriteLine("What type of customer do you want to add?\n" +
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

            Customer newCustomer = new Customer(fname, lname, type);
            cRepo.CreateCustomer(newCustomer);
            Console.WriteLine("Customer added!");
            PrintCustomerData(newCustomer);
        }

        private void EditCustomer()
        {

        }

        private void DeleteCustomer()
        {

        }
        private static void PrintCustomerData(Customer c)
        {
            Console.WriteLine(
                $"FName: {c.FirstName}\n" +
                $"LName: {c.LastName}\n" +
                $"Type: {c.TypeOfCustomer}\n" +
                $"Email: {c.Email}\n");
        }
    }
}
