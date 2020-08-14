using BudgetGuard.App.Interfaces;
using BudgetGuard.Domain.Models;
using BudgetGuard.Infrastructure.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace BudgetGuard.App.Implementations
{
    public class EntryService : IEntryService
    {
        private readonly IEntryRepository _repository;

        public EntryService(IEntryRepository repository)
        {
            _repository = repository;
        }

        public void AddNewIncome(decimal amount, string name, DateTime date)
        {
            var id = _repository.GetNextId();
            var newIncome = new Income(id, amount, name, date);

            _repository.Add(newIncome);
        }

        public void AddNewOutcome(decimal amount, string name, DateTime date)
        {
            var id = _repository.GetNextId();
            var newOutcome = new Outcome(id, amount, name, date);

            _repository.Add(newOutcome);
        }

        public void RemoveEntryById(int id)
        {
            throw new NotImplementedException();
        }
    }
}
