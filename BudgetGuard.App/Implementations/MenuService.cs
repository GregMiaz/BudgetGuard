﻿using BudgetGuard.App.Interfaces;
using BudgetGuard.App.Managers;
using System;

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
            Console.WriteLine("3. Show single entry details");
            Console.WriteLine("4. Remove existing entry");
            Console.WriteLine("5. Show all entries");
            Console.WriteLine("6. Generate financial report");
            Console.WriteLine("7. Exit from application");
            Console.Write("You chose option number: ");
        }

        public void ProcessSelectedOperation(string operation)
        {
            switch (operation)
            {
                case "1":
                    SelectionManager.AddNewIncome();
                    break;
                case "2":
                    SelectionManager.AddNewOutcome();
                    break;
                case "3":
                    SelectionManager.ShowEntryById();
                    break;
                case "4":
                    SelectionManager.RemoveExistingEntryById();
                    break;
                case "5":
                    SelectionManager.ShowAllEntries();
                    break;
                case "6":
                    SelectionManager.GenerateMonthlyFinancialReport();
                    break;
            }
        }
    }
}