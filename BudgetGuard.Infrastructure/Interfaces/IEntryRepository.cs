using BudgetGuard.Domain.Models;
using System.Collections.Generic;

namespace BudgetGuard.Infrastructure.Interfaces
{
    public interface IEntryRepository : IRepository<Entry>
    {
        IList<Entry> Entries { get; set; }
        int GetNextId();
    }
}
