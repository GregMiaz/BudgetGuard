using BudgetGuard.App.Interfaces;
using BudgetGuard.Infrastructure.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace BudgetGuard.App.Implementations
{
    public class SelectionService
    {
        static IEntryRepository _repository;

        public static void AddNewIncome() 
        {
            Console.Clear();

            Console.WriteLine("New income:");
            Console.WriteLine("Name: ");
            string name = Console.ReadLine();


            Console.WriteLine("Amount:");
            decimal amount;
            decimal.TryParse(Console.ReadLine(), out amount);

            Console.WriteLine("Date: ");
            DateTime date = DateTime.Today;
            DateTime.TryParse(Console.ReadLine(), out date);

            IEntryService entryService = new EntryService(_repository);
            entryService.AddNewIncome(amount, name, date);
        }

        public static void AddNewOutcome() 
        {
            
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