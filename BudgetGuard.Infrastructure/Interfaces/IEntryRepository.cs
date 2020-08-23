using BudgetGuard.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BudgetGuard.Infrastructure.Interfaces
{
    public interface IEntryRepository : IRepository<Entry>
    {
        IList<Entry> Entries { get; set; }

        int GetNextId();
    }
}
