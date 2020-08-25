using System;

namespace BudgetGuard.Domain.Models
{
    public abstract class Entry : BaseModel
    {
        public string Name { get; protected set; }
        public decimal Amount { get; protected set; }
        public EntryType Type { get; protected set; }
        public DateTime Date { get; protected set; }
    }
}
