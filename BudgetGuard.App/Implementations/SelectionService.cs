using BudgetGuard.App.Interfaces;
using BudgetGuard.Infrastructure.Implementations;
using BudgetGuard.Infrastructure.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BudgetGuard.App.Implementations
{
    public class SelectionService
    {
        private static IEntryRepository _repository = new InMemoryEntryRepository();

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

            Console.WriteLine(Environment.NewLine + "New income added, press any key to return to main menu...");
            Console.ReadKey();
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

            Console.WriteLine(Environment.NewLine + "New outcome added, press any key to return to main menu...");
            Console.ReadKey();
        }

        public static void RemoveExistingEntryById()
        {
            Console.Clear();

            Console.WriteLine("Please type id of entry to remove: ");
            int.TryParse(Console.ReadLine(), out int id);

            IEntryService entryService = new EntryService(_repository);
            entryService.RemoveEntryById(id);

            Console.WriteLine(Environment.NewLine + "Entry removed, press any key to return to main menu...");
            Console.ReadKey();
        }

        public static void ShowAllEntries()
        {
            Console.Clear();

            Console.WriteLine("List of all entries:" + Environment.NewLine);

            var entries = _repository.GetAll().ToList();
            foreach (var item in entries)
            {
                Console.WriteLine($"ID: {item.Id}, NAME: {item.Name}, AMOUNT: {item.Amount}, DATE: {item.Date.ToShortDateString()} ");
            }

            Console.WriteLine(Environment.NewLine + "Press any key to return to main menu...");
            Console.ReadKey();
        }

        public static void GenerateMonthlyReport()
        {

        }
    }
}