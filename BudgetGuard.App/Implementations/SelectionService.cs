using BudgetGuard.App.Interfaces;
using BudgetGuard.Infrastructure.Implementations;
using BudgetGuard.Infrastructure.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace BudgetGuard.App.Implementations
{
    public class SelectionService
    {
        private static IEntryRepository _repository = new TextFileEntryRepository("entryrecords.txt");

        public static void AddNewIncome() 
        {
            Console.Clear();

            Console.WriteLine("New income:");
            Console.WriteLine("Name: ");
            string name = Console.ReadLine();

            Console.WriteLine("Amount:");
            decimal.TryParse(Console.ReadLine(), out decimal amount);

            Console.WriteLine("Date: ");
            DateTime.TryParse(Console.ReadLine(), out DateTime date);

            IEntryService entryService = new EntryService(_repository);
            entryService.AddNewIncome(amount, name, date);
        }

        public static void AddNewOutcome() 
        {
            Console.Clear();

            Console.WriteLine("New outcome:");
            Console.WriteLine("Name: ");
            string name = Console.ReadLine();

            Console.WriteLine("Amount:");
            decimal.TryParse(Console.ReadLine(), out decimal amount);

            Console.WriteLine("Date: ");
            DateTime.TryParse(Console.ReadLine(), out DateTime date);

            IEntryService entryService = new EntryService(_repository);
            entryService.AddNewOutcome(amount, name, date);
        }

        public static void RemoveExistingEntry() 
        {
            
        }

        public static void ShowAllEntries() 
        {
            
        }

        public static void GenerateMonthlyReport() 
        {
            
        }
    }
}