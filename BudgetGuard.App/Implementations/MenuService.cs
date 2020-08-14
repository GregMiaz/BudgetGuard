using BudgetGuard.App.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace BudgetGuard.App.Implementations
{
    public class MenuService : IMenuService
    {

        public void InitializeMenu()
        {
            Console.Clear();
            Console.WriteLine("Welcome to Budget Guard - protector of your finances!\r\n");
            Console.WriteLine("Select an operation: \r\n");
            Console.WriteLine("1. Add new income");
            Console.WriteLine("2. Add new outcome");
            Console.WriteLine("3. Remove existing entry");
            Console.WriteLine("4. Show all entries");
            Console.WriteLine("5 - Generate monthly report");
            Console.WriteLine("6 - Exit from application");
            Console.Write("You chose option number: ");
        }

        public void ProcessSelectedOperation(string operation)
        {
            switch (operation)
            {
                case "1":
                    SelectionService.AddNewIncome();
                    break;
                case "2":
                    SelectionService.AddNewOutcome();
                    break;
                case "3":
                    SelectionService.RemoveExistingEntry();
                    break;
                case "4":
                    SelectionService.ShowAllEntries();
                    break;
                case "5":
                    SelectionService.GenerateMonthlyReport();
                    break;
            }
        }
    }
}