using CafeRepo;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoldBadgeChallenges
{
    class CafeUI
    {
        bool running = true;
        MenuRepo menu = new MenuRepo();
        public void Run()
        {
            Console.WriteLine("Welcome to the Komodo Cafe Console App!");

            while(running)
            {
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("Press any key to continue...");
                Console.ReadKey();
                Console.Clear();
                Menu();
            }
        }

        private void Menu()
        {
            Console.WriteLine("Please make a selection:");
            Console.WriteLine("" +
                "1. View all menu items\n" +
                "2. Add a new menu item\n" +
                "3. Delete a menu item\n" +
                "4. Exit");

            string input = Console.ReadLine();
            switch (input)
            {
                case "1":
                    ViewMenuItems();
                    break;
                case "2":
                    CreateMenuItem();
                    break;
                case "3":
                    DeleteMenuItem();
                    break;
                case "4":
                    ExitApp();
                    break;
                default:
                    Console.Clear();
                    Console.WriteLine("I did not understand that command. Please enter a valid selection.");
                    break;
            }
        }

        private void ExitApp()
        {
            Console.Clear();
            Console.WriteLine("Goodbye!");
            Console.ReadKey();
            running = false;
        }

        private void ViewMenuItems()
        {
            List<Meal> menuItems = menu.GetAllMeals();
            if (menuItems.Count == 0)
            {
                Console.WriteLine("There are no menu items yet. Add some!\n");
                return;
            }

            foreach (Meal m in menuItems)
            {
                Console.WriteLine(
                    $"Name: {m.Name}\n" +
                    $"Number: {m.Number}\n" +
                    $"Description: {m.Description}\n" +
                    $"Ingredients:");
                    foreach (string i in m.Ingredients)
                    {
                        Console.WriteLine("\t* " + i);
                    }
                    Console.WriteLine($"Price: ${m.Price}\n" +
                    $"================================================");
            }
        }

        private void CreateMenuItem()
        {
            Meal newMenuItem = new Meal();

            Console.Clear();
            Console.WriteLine("Please enter the name of the new menu item:");
            newMenuItem.Name = Console.ReadLine();

            Console.Clear();
            Console.WriteLine("Please enter the new menu item's description:");
            newMenuItem.Description = Console.ReadLine();

            Console.Clear();
            List<string> newMenuItemIngs = new List<string>();
            Console.WriteLine($"What ingredients are required to make {newMenuItem.Name}?");
            for (int i = 0; i < 3; i++)
            {
                Console.WriteLine("Please type an ingredient:");
                string newIng = Console.ReadLine();
                newMenuItemIngs.Add(newIng);
            }
            newMenuItem.Ingredients = newMenuItemIngs;

            Console.Clear();
            CreateNewMenuItemPrice(newMenuItem);

            Console.Clear();
            menu.CreateMeal(newMenuItem);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("New Menu Item created!");
        }

        // Helper functions

        private static void CreateNewMenuItemPrice(Meal newMenuItem)
        {
            Console.WriteLine("Please enter the new menu item's price:");
            try
            {
                newMenuItem.Price = Decimal.Parse(Console.ReadLine());
            }
            catch
            {
                Console.WriteLine("Sorry, that is not a valid price.");
                CreateNewMenuItemPrice(newMenuItem);
            }
        }

        private void DeleteMenuItem()
        {
            Console.WriteLine("Please enter the name of the meal you would like to delete:");
            string input = Console.ReadLine();
            bool success = menu.DeleteMeal(input);
            if (success)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Menu Item successfully deleted!");
            }
            else
            {
                Console.WriteLine("Sorry, I could not find a menu item with that name.");
            }
        }
    }
}
