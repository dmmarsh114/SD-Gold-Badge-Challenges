using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreetingRepo
{
    public enum CustomerType
    {
        Current = 1,
        Past,
        Potential
    }

    public class Customer 
    { 

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public CustomerType TypeOfCustomer { get; set; }
        public string Email { get; set; }

        public Customer(string fname, string lname, CustomerType type)
        {
            FirstName = fname;
            LastName = lname;
            TypeOfCustomer = type;
            Email = CreateEmail(TypeOfCustomer);
        }

        public static string CreateEmail(CustomerType type)
        {
            switch (type)
            {
                case CustomerType.Current:
                    return "We have discounts on Helicopter Insurance!";
                case CustomerType.Past:
                    return "Please come back we miss you so!";
                case CustomerType.Potential:
                default:
                    return "We're cool, we promise! Buy insurance from us!!";
            }
        } 
    }
}
