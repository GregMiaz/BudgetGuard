using BudgetGuard.Domain.Models;
using System.Collections.Generic;

namespace BudgetGuard.Infrastructure.Interfaces
{
    public interface IEntryRepository : IRepository<Entry>
    {
        int GetNextId();
    }
}
