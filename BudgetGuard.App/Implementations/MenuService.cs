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
            Console.WriteLine("1. Add income");
            Console.WriteLine("2. Add outcome");
            Console.WriteLine("3. Delete an entry");
            Console.WriteLine("4. Show list");
            Console.WriteLine("5 - Generate monthly report");
            Console.WriteLine("6 - Exit from application");
            Console.Write("You chose option number: ");
        }

        public void ProcessSelectedOperation(string operation)
        {
            switch (operation)
            {
                case "1":
                    break;
                case "2":
                    break;
                case "3":
                    break;
                case "4":
                    break;
                case "5":
                    break;
                default:
                    break;
            }
        }
    }
}