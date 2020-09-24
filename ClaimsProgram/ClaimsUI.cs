using ClaimsRepo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
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
            cRepo.PopulateClaims();

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
                    InvalidSelection();
                    break;
            }

            return running;
        }

        // TODO - Make the table actually readable
        private void ViewClaims()
        {
            List<ClaimsRepo.Claim> allClaims = cRepo.ViewAllClaims();

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("ID\tType\tDescription\t  Amount\tDate Of Incident\tDate Of Claim\tIs Valid");
            Console.ForegroundColor = ConsoleColor.White;

            foreach (ClaimsRepo.Claim c in allClaims)
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
            ClaimsRepo.Claim claimToHandle = cRepo.ViewAllClaims()[0];
            Console.WriteLine($"Your next claim is:\n" +
                $"Id: {claimToHandle.ClaimId}\n" +
                $"Type: {claimToHandle.ClaimType}\n" +
                $"Amount: {claimToHandle.ClaimAmount}\n" +
                $"Date of Incident: {claimToHandle.DateOfIncident}\n" +
                $"Date of Claim: {claimToHandle.DateOfClaim}\n" +
                $"Is Valid: {claimToHandle.IsValid}\n\n" +
                $"Would you like to handle this claim now? y/n");

            string input = Console.ReadLine();
            Console.Clear();
            switch (input)
            {
                case "y":
                case "yes":
                    AttemptToHandleClaim(claimToHandle);
                    break;
                case "n":
                case "no":
                    Console.WriteLine("Okay, we'll deal with that claim another time.");
                    break;
                default:
                    InvalidSelection();
                    HandleNextClaim();
                    break;
            }
        }

        private void AttemptToHandleClaim(ClaimsRepo.Claim claimToHandle)
        {
            if (cRepo.HandleClaim(claimToHandle.ClaimId))
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Claim processed!");
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Sorry, I could not process that claim.");
            }
        }

        private void EnterNewClaim()
        {
            TypeOfClaim claimType;
            string desc;
            decimal amt;
            DateTime dateInc;
            DateTime dateClaim;

            // type
            Console.WriteLine("What is the type of claim to be made? Please select from below:\n" +
                "1. Car\n" +
                "2. Home\n" +
                "3. Theft");
            string claimTypeString = Console.ReadLine();
            switch(claimTypeString)
            {
                case "1":
                case "2":
                case "3":
                    claimType = (TypeOfClaim) int.Parse(claimTypeString);
                    break;
                default:
                    Console.WriteLine("Sorry, I could not understand that. Using default setting...");
                    Console.ReadKey();
                    claimType = TypeOfClaim.Car;
                    break;
            }

            // desc 
            Console.Clear();
            Console.WriteLine("Please briefly describe the incident:");
            desc = Console.ReadLine();

            // amt
            Console.Clear();
            Console.WriteLine("Please enter the amount of the claim:");
            string amtString = Console.ReadLine();
            try
            {
                amt = Decimal.Parse(amtString);
            }
            catch
            {
                Console.WriteLine("Sorry, I could not understand that. Using default setting...");
                Console.ReadKey();
                amt = 400M;
            }

            // dateinc
            Console.Clear();
            Console.WriteLine("On what date did the incident occur?\n" +
                "Please write in the following format: mm/dd/yyyy");
            string dateIncString = Console.ReadLine();
            try
            {
                dateInc = DateTime.Parse(dateIncString);
            }
            catch
            {
                Console.WriteLine("Sorry, I could not understand that. Using default setting...");
                Console.ReadKey();
                dateInc = new DateTime(2020, 10, 01);
            }

            // dateclaim
            Console.Clear();
            Console.WriteLine("On what date was the claim filed?\n" +
                "Please write in the following format: mm/dd/yyyy");
            string dateClaimString = Console.ReadLine();
            try
            {
                dateClaim = DateTime.Parse(dateClaimString);
            }
            catch
            {
                Console.WriteLine("Sorry, I could not understand that. Using default setting...");
                Console.ReadKey();
                dateClaim = new DateTime(2020, 10, 20);
            }

            Console.Clear();
            ClaimsRepo.Claim claimToAdd = new ClaimsRepo.Claim(claimType, desc, amt, dateInc, dateClaim);
            cRepo.NewClaim(claimToAdd);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Claim Added!");
        }

        // Helper Functions
        private static void InvalidSelection()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("I did not understand that command. Please enter a valid selection.");
            Console.ForegroundColor = ConsoleColor.White;
        }
    }
}
