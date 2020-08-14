using BudgetGuard.App.Implementations;
using BudgetGuard.App.Interfaces;
using System;

namespace BudgetGuard
{
    class Program
    {
        static void Main(string[] args)
        {

            IMenuService menuService = new MenuService();
            string operation = string.Empty;

            do
            {
                menuService.InitializeMenu();
                operation = Console.ReadLine();
            } while (operation != "6");

        }
    }
}
