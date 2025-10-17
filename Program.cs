using System;

namespace PersonalBudgetTracker
{
    internal class Program
    {
        static void Main(string[] args)
        {
            BudgetManager manager = new BudgetManager();
            bool running = true;

            while (running)
            {
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("\n=== Personal Budget Tracker ===");
                Console.ResetColor();
                Console.WriteLine("1. Lägg till transaktion");
                Console.WriteLine("2. Visa alla transaktioner");
                Console.WriteLine("3. Visa total balans och statistik");
                Console.WriteLine("4. Ta bort transaktion");
                Console.WriteLine("5. Filtrera eller sortera transaktioner");
                Console.WriteLine("6. Avsluta programmet");
                Console.Write("Välj ett alternativ (1-6): ");

                string choice = Console.ReadLine();
                Console.Clear();

                switch (choice)
                {
                    case "1":
                        manager.AddTransaction();
                        break;
                    case "2":
                        manager.ShowAll();
                        break;
                    case "3":
                        manager.CalculateBalance();
                        break;
                    case "4":
                        manager.DeleteTransaction();
                        break;
                    case "5":
                        manager.FilterOrSort();
                        break;
                    case "6":
                        running = false;
                        Console.WriteLine("Programmet avslutas...");
                        break;
                    default:
                        Console.WriteLine("Felaktigt val, försök igen.");
                        break;
                }
            }
        }
    }
}
