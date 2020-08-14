using BudgetGuard.App.Implementations;
using BudgetGuard.App.Interfaces;
using System;

namespace BudgetGuard
{
    class Program
    {
        static void Main(string[] args)
        {
            const string EXIT = "6";
            string operation;
            IMenuService menuService = new MenuService();

            do
            {
                menuService.InitializeMenu();
                operation = Console.ReadLine();
                menuService.ProcessSelectedOperation(operation);
            } while (operation != EXIT);

        }
    }
}