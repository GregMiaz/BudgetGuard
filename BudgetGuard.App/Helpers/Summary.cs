using System;

namespace BudgetGuard.App.Helpers
{
    public class Summary
    {
        public Summary(decimal incomes, decimal outcomes, decimal balance)
        {
            Incomes = incomes;
            Outcomes = outcomes;
            Balance = balance;
        }

        public decimal Incomes { get; private set; }
        public decimal Outcomes { get; private set; }
        public decimal Balance { get; private set; }

        public static void ShowReportOnScreen(int year, int month, Summary result)
        {
            Console.WriteLine($"Summary {month}/{year}");
            Console.WriteLine("---------------------------");
            Console.WriteLine($"Sum of incomes: {result.Incomes:C}");
            Console.WriteLine($"Sum of outcomes: {result.Outcomes:C}");
            Console.WriteLine("---------------------------");
            Console.WriteLine($"Balance: {result.Balance:C}");

        }
    }
}
