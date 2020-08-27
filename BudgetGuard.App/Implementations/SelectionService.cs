using BudgetGuard.App.Helpers;
using BudgetGuard.App.Interfaces;
using BudgetGuard.Infrastructure.Implementations;
using BudgetGuard.Infrastructure.Interfaces;
using System;
using System.Linq;

namespace BudgetGuard.App.Implementations
{
    public class SelectionService
    {
        private static IEntryRepository _repository = new InMemoryEntryRepository();
        private static IReportService _reportService = new ReportService(_repository);

        public static void AddNewIncome()
        {
            Console.Clear();

            Console.WriteLine("New income:");
            Console.WriteLine("Enter name: ");
            string name = Console.ReadLine();

            Console.WriteLine("Enter amount:");
            decimal amount;
            while (!decimal.TryParse(Console.ReadLine(), out amount)) 
            {
                Console.WriteLine("Please enter valid amount:");
            };

            Console.WriteLine("Enter date: ");
            DateTime date;
            while (!DateTime.TryParse(Console.ReadLine(), out date)) 
            {
                Console.WriteLine("Please enter a valid date:");
            };

            IEntryService entryService = new EntryService(_repository);
            entryService.AddNewIncome(amount, name, date);

            Console.WriteLine(Environment.NewLine + "New income added, press any key to return to main menu...");
            Console.ReadKey();
        }

        public static void AddNewOutcome()
        {
            Console.Clear();

            Console.WriteLine("New outcome:");
            Console.WriteLine("Enter name: ");
            string name = Console.ReadLine();

            Console.WriteLine("Enter amount:");
            decimal amount;
            while (!decimal.TryParse(Console.ReadLine(), out amount))
            {
                Console.WriteLine("Please enter valid amount:");
            };

            Console.WriteLine("Enter date: ");
            DateTime date;
            while (!DateTime.TryParse(Console.ReadLine(), out date))
            {
                Console.WriteLine("Please enter valid date:");
            };

            IEntryService entryService = new EntryService(_repository);
            entryService.AddNewOutcome(amount, name, date);

            Console.WriteLine(Environment.NewLine + "New outcome added, press any key to return to main menu...");
            Console.ReadKey();
        }

        public static void RemoveExistingEntryById()
        {
            Console.Clear();

            Console.WriteLine("Please type id of entry to remove: ");
            int id;
            while (!int.TryParse(Console.ReadLine(), out id)) 
            {
                Console.WriteLine("Please enter valid id:");
            };

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
                Console.WriteLine($"ID: {item.Id} - NAME: {item.Name} - AMOUNT: {item.Amount:C} - DATE: {item.Date.ToShortDateString()} ");
            }

            Console.WriteLine(Environment.NewLine + "Press any key to return to main menu...");
            Console.ReadKey();
        }

        public static void GenerateMonthlyFinancialReport()
        {
            Console.Clear();

            Console.WriteLine("Financial report:");
            Console.WriteLine("Enter year:");
            int year;
            while (!int.TryParse(Console.ReadLine(), out year))
            {
                Console.WriteLine("Please enter valid year:");
            };

            Console.WriteLine("Enter month:");
            int month;
            while (!int.TryParse(Console.ReadLine(), out month))
            {
                Console.WriteLine("Please enter valid month:");
            };

            var result = _reportService.ShowSummaryFromSelectedMonth(year, month);

            Summary.ShowReportOnScreen(year, month, result);

            Console.WriteLine(Environment.NewLine + "Press any key to return to main menu...");
            Console.ReadKey();
        }
    }
}
