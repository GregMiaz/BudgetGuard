using BudgetGuard.App.Interfaces;
using BudgetGuard.Domain.Models;
using BudgetGuard.Infrastructure.Interfaces;
using System;
using System.Collections.Generic;

namespace BudgetGuard.App.Implementations
{
    public class EntryService : IEntryService
    {
        private readonly IEntryRepository _repository;

        public EntryService(IEntryRepository repository)
        {
            _repository = repository;
        }

        public int AddNewIncome(decimal amount, string name, DateTime date)
        {
            var id = _repository.GetNextId();
            var newIncome = new Income(id, amount, name, date);

            _repository.Add(newIncome);
            return newIncome.Id;
        }

        public int AddNewOutcome(decimal amount, string name, DateTime date)
        {
            var id = _repository.GetNextId();
            var newOutcome = new Outcome(id, amount, name, date);

            _repository.Add(newOutcome);

            return newOutcome.Id;
        }

        public Entry GetEntryById(int id)
        {
            var entry = _repository.GetById(id);
            return entry;
        }

        public void RemoveEntryById(int id)
        {
            _repository.RemoveById(id);
        }

        public IEnumerable<Entry> ShowAllEntries()
        {
            return _repository.GetAll();
        }
    }
}
