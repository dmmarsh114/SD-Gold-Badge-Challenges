using ClaimsRepo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClaimsProgram
{
    class ClaimsUI
    {
        ClaimRepo cRepo = new ClaimRepo();
        public void Run()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Welcome to Komodo Insurance!");

            bool running = true;

            while (running)
            {
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("\nPress any key to continue...");
                Console.ReadKey();
                Console.Clear();

                running = Menu(running);
            }
        }

        private bool Menu(bool running)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Please Choose an Option:");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine(
                "1. View All Claims\n" +
                "2. Handle Next Claim\n" +
                "3. Enter a New Claim\n" +
                "4. Exit");

            string input = Console.ReadLine();
            Console.Clear();
            switch (input)
            {
                case "1":
                    ViewClaims();
                    break;
                case "2":
                    HandleNextClaim();
                    break;
                case "3":
                    EnterNewClaim();
                    break;
                case "4":
                    Console.Clear();
                    Console.WriteLine("Goodbye!");
                    Console.ReadKey();
                    running = false;
                    break;
                default:
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("I did not understand that command. Please enter a valid selection.");
                    break;
            }

            return running;
        }

        private void ViewClaims()
        {
            List<Claim> allClaims = cRepo.ViewAllClaims();
            cRepo.PopulateClaims();

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("ID\tType\tDescription\t  Amount\tDate Of Incident\tDate Of Claim\tIs Valid");
            Console.ForegroundColor = ConsoleColor.White;

            foreach (Claim c in allClaims)
            {
                // Note to self: I hate hard-coding all these spaces
                Console.WriteLine(
                    $"{c.ClaimId}\t" +
                    $"{c.ClaimType}\t" +
                    $"{c.Description}\t  " +
                    $"{"$" + c.ClaimAmount}\t\t" +
                    $"{c.DateOfIncident.ToShortDateString()}\t\t" +
                    $"{c.DateOfClaim.ToShortDateString()}\t" +
                    $"{c.IsValid}\t");
            }
        }
        
        private void HandleNextClaim()
        {

        }

        private void EnterNewClaim()
        {

        }
    }
}
