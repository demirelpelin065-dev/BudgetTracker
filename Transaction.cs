using System;

namespace PersonalBudgetTracker
{
    // Representerar en enskild transaktion
    public class Transaction
    {
        public string Description { get; set; }
        public decimal Amount { get; set; }
        public string Category { get; set; }
        public DateTime Date { get; set; }

        public Transaction(string description, decimal amount, string category, DateTime date)
        {
            Description = description;
            Amount = amount;
            Category = category;
            Date = date;
        }

        public void ShowInfo()
        {
            if (Amount >= 0)
                Console.ForegroundColor = ConsoleColor.Green;
            else
                Console.ForegroundColor = ConsoleColor.Red;

            Console.WriteLine($"[{Date:yyyy-MM-dd}] {Description} ({Category}) : {Amount} kr");
            Console.ResetColor();
        }
    }
}
