using System;
using System.Collections.Generic;
using System.Linq;

namespace PersonalBudgetTracker
{
    public class BudgetManager
    {
        private List<Transaction> transactions = new List<Transaction>();

        public void AddTransaction()
        {
            Console.Write("Skriv en beskrivning: ");
            string description = Console.ReadLine()?.Trim();

            decimal amount;
            while (true)
            {
                Console.Write("Skriv belopp (positivt = inkomst, negativt = utgift): ");
                if (decimal.TryParse(Console.ReadLine(), out amount))
                    break;
                Console.WriteLine("Felaktig inmatning. Försök igen med ett numeriskt värde.");
            }

            Console.Write("Skriv kategori: ");
            string category = Console.ReadLine()?.Trim();

            DateTime date = DateTime.Now;
            Transaction t = new Transaction(description, amount, category, date);
            transactions.Add(t);

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(" Transaktion tillagd!");
            Console.ResetColor();
        }

        public void ShowAll()
        {
            if (!transactions.Any())
            {
                Console.WriteLine("Det finns inga transaktioner att visa.");
                return;
            }

            Console.WriteLine("\n--- Alla Transaktioner ---");
            foreach (var t in transactions)
                t.ShowInfo();
            Console.WriteLine("---------------------------");
        }

        public void CalculateBalance()
        {
            decimal totalIncome = transactions.Where(t => t.Amount > 0).Sum(t => t.Amount);
            decimal totalExpense = transactions.Where(t => t.Amount < 0).Sum(t => t.Amount);
            decimal balance = totalIncome + totalExpense;

            Console.WriteLine("\n Statistik:");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"Totala inkomster: {totalIncome} kr");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"Totala utgifter: {totalExpense} kr");
            Console.ResetColor();

            Console.WriteLine($"Antal transaktioner: {transactions.Count}");
            Console.WriteLine("---------------------------");

            Console.WriteLine("Aktuell balans: ");
            Console.ForegroundColor = balance >= 0 ? ConsoleColor.Green : ConsoleColor.Red;
            Console.WriteLine($"{balance} kr\n");
            Console.ResetColor();
        }

        public void DeleteTransaction()
        {
            if (!transactions.Any())
            {
                Console.WriteLine("Det finns inga transaktioner att ta bort.");
                return;
            }

            Console.WriteLine("\n--- Lista över transaktioner ---");
            for (int i = 0; i < transactions.Count; i++)
            {
                Console.Write($"{i + 1}. ");
                transactions[i].ShowInfo();
            }

            Console.Write("Ange numret på transaktionen du vill ta bort: ");
            if (int.TryParse(Console.ReadLine(), out int index) && index > 0 && index <= transactions.Count)
            {
                transactions.RemoveAt(index - 1);
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine(" Transaktionen har tagits bort.");
                Console.ResetColor();
            }
            else
            {
                Console.WriteLine("Felaktigt val, försök igen.");
            }
        }

        public void FilterOrSort()
        {
            if (!transactions.Any())
            {
                Console.WriteLine("Det finns inga transaktioner att filtrera eller sortera.");
                return;
            }

            Console.WriteLine("\n=== Filtrera / Sortera ===");
            Console.WriteLine("1. Filtrera efter kategori");
            Console.WriteLine("2. Sortera efter datum (nyast först)");
            Console.WriteLine("3. Sortera efter belopp (störst först)");
            Console.Write("Välj ett alternativ (1-3): ");
            string choice = Console.ReadLine();

            IEnumerable<Transaction> result = transactions;

            switch (choice)
            {
                case "1":
                    Console.Write("Ange kategori att filtrera på: ");
                    string cat = Console.ReadLine()?.Trim();
                    result = transactions.Where(t => t.Category.Equals(cat, StringComparison.OrdinalIgnoreCase));
                    break;
                case "2":
                    result = transactions.OrderByDescending(t => t.Date);
                    break;
                case "3":
                    result = transactions.OrderByDescending(t => t.Amount);
                    break;
                default:
                    Console.WriteLine("Felaktigt val.");
                    return;
            }

            Console.WriteLine("\n--- Resultat ---");
            foreach (var t in result)
                t.ShowInfo();
            Console.WriteLine("---------------------------");
        }
    }
}
