using System;
using System.Collections.Generic;
using System.Text;

namespace BudgetGuard.App.Interfaces
{
    public interface IMenuService
    {
        void InitializeMenu();
        void ProcessSelectedOperation(string operation);
    }
}
