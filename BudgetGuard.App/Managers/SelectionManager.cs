using BudgetGuard.App.Helpers;
using BudgetGuard.App.Implementations;
using BudgetGuard.App.Interfaces;
using BudgetGuard.Domain.Models;
using BudgetGuard.Infrastructure.Implementations;
using BudgetGuard.Infrastructure.Interfaces;
using System;
using System.Linq;

namespace BudgetGuard.App.Managers
{
    public class SelectionManager
    {
        private static IEntryRepository _repository = new TxtFileEntryRepository();
        private static IReportService _reportService = new ReportService(_repository);

        public static void AddNewIncome()
        {
            Console.Clear();

            Console.WriteLine("New income:");
            Console.WriteLine("Enter income name: ");
            string name = Console.ReadLine();

            Console.WriteLine("Enter amount:");
            decimal amount;
            while (!decimal.TryParse(Console.ReadLine(), out amount))
            {
                Console.WriteLine("Please enter valid amount: ");
            };

            Console.WriteLine("Enter date (YYYY-MM-DD): ");
            DateTime date;
            while (!DateTime.TryParse(Console.ReadLine(), out date))
            {
                Console.WriteLine("Please enter a valid date:");
            };

            IEntryService entryService = new EntryService(_repository);
            entryService.AddNewIncome(amount, name, date);

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("New income added");
            ReturnToMenuMessage();
        }

        public static void AddNewOutcome()
        {
            Console.Clear();

            Console.WriteLine("New outcome:");
            Console.WriteLine("Enter outcome name: ");
            string name = Console.ReadLine();

            Console.WriteLine("Enter amount:");
            decimal amount;
            while (!decimal.TryParse(Console.ReadLine(), out amount))
            {
                Console.WriteLine("Please enter valid amount: ");
            };

            Console.WriteLine("Enter date (YYYY-MM-DD): ");
            DateTime date;
            while (!DateTime.TryParse(Console.ReadLine(), out date))
            {
                Console.WriteLine("Please enter valid date:");
            };

            IEntryService entryService = new EntryService(_repository);
            entryService.AddNewOutcome(amount, name, date);

            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("New outcome added");
            ReturnToMenuMessage();
        }

        public static void RemoveExistingEntryById()
        {
            Console.Clear();

            var entries = _repository.GetAll().ToList();

            if (entries.Count() == 0)
            {
                Console.WriteLine("There are no entries available");
            }
            else
            {
                foreach (var item in entries)
                {
                    DisplayEntryColorBasedOnType(item);
                }

                Console.ResetColor();
                Console.WriteLine();
                Console.WriteLine("Please type id of entry to remove: ");
                int id;
                while (!int.TryParse(Console.ReadLine(), out id))
                {
                    Console.WriteLine("Please enter valid id:");
                };

                IEntryService entryService = new EntryService(_repository);
                entryService.RemoveEntryById(id);

                Console.WriteLine(Environment.NewLine + "Entry removed");
            }
            ReturnToMenuMessage();
        }

        public static void ShowAllEntries()
        {
            Console.Clear();

            var entries = _repository.GetAll().ToList();

            if (entries.Count() == 0)
            {
                Console.WriteLine("There are no entries available");
            }
            else
            {
                Console.WriteLine("List of all entries (green = income, red = outcome):" + Environment.NewLine);

                foreach (var item in entries)
                {
                    DisplayEntryColorBasedOnType(item);
                }
            }

            ReturnToMenuMessage();
        }

        public static void ShowEntryById()
        {
            Console.Clear();

            Console.WriteLine("Enter entry id to display details:");
            int id;
            while (!int.TryParse(Console.ReadLine(), out id))
            {
                Console.WriteLine("Please enter valid id: ");
            };

            var item = _repository.GetById(id);

            if (item == null)
            {
                Console.WriteLine("There is no entry with provided id");
                ReturnToMenuMessage();
            }
            else
            {
                DisplayEntryColorBasedOnType(item);
                ReturnToMenuMessage();
            }
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

            ReturnToMenuMessage();
        }

        private static void DisplayEntryColorBasedOnType(Entry item)
        {
            if (item.Type == EntryType.Income)
            {
                Console.ForegroundColor = ConsoleColor.Green;
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
            }
            Console.WriteLine($"ID: {item.Id} - NAME: {item.Name} - AMOUNT: {item.Amount:C} - DATE: {item.Date.ToShortDateString()} ");
        }

        private static void ReturnToMenuMessage()
        {
            Console.ResetColor();
            Console.WriteLine(Environment.NewLine + "Press any key to return to main menu...");
            Console.ReadKey();
        }
    }
}
