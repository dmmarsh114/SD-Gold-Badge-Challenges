using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CafeRepo
{
    public class Meal
    {
        public string Name { get; set; }
        public int Number { get; set; }
        public string Description { get; set; }
        public List<string> Ingredients { get; set; }
        public decimal Price { get; set; }

        public Meal() { }

        public Meal(string name, int number, string desc, List<string> ings, decimal price)
        {
            Name = name;
            Number = number;
            Description = desc;
            Ingredients = ings;
            Price = price;
        }
    }
}
