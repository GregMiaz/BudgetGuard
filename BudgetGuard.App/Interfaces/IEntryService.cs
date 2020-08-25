using BudgetGuard.Domain.Models;
using System;
using System.Collections.Generic;

namespace BudgetGuard.App.Interfaces
{
    public interface IEntryService
    {
        void AddNewIncome(decimal amount, string name, DateTime date);
        void AddNewOutcome(decimal amount, string name, DateTime date);

        void RemoveEntryById(int id);

        IEnumerable<Entry> ShowAllEntries();
    }
}
