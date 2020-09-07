using BudgetGuard.Domain.Models;
using System;
using System.Collections.Generic;

namespace BudgetGuard.App.Interfaces
{
    public interface IEntryService
    {
        int AddNewIncome(decimal amount, string name, DateTime date);
        int AddNewOutcome(decimal amount, string name, DateTime date);

        void RemoveEntryById(int id);

        IEnumerable<Entry> ShowAllEntries();
    }
}
