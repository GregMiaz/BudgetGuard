using BudgetGuard.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BudgetGuard.Infrastructure.Interfaces
{
    public interface IEntryRepository
    {
        IList<Entry> GetAll();
        void Add(Entry entry);
        void Remove(Entry entry);
        int GetNextId();
    }
}
