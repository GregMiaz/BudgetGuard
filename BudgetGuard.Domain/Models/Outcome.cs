﻿using System;

namespace BudgetGuard.Domain.Models
{
    public class Outcome : Entry
    {
        public Outcome(int id, decimal amount, string name, DateTime date)
        {
            Id = id;
            Name = name;
            Amount = amount;
            Type = EntryType.Outcome;
            Date = date;
        }
    }
}
