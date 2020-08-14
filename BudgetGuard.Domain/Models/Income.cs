using System;
using System.Collections.Generic;
using System.Text;

namespace BudgetGuard.Domain.Models
{
    public class Income : Entry
    {
        public Income(int id, decimal amount, string name, DateTime date)
        {
            Id = id;
            Name = name;
            Amount = amount;
            Type = EntryType.Income;
            Date = date;
        }
    }
}
