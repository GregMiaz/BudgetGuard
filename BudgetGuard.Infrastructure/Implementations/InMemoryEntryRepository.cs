using BudgetGuard.Domain.Models;
using BudgetGuard.Infrastructure.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace BudgetGuard.Infrastructure.Implementations
{
    public class InMemoryEntryRepository : IEntryRepository
    {
        private IList<Entry> _entries;

        public InMemoryEntryRepository()
        {
            _entries = new List<Entry>();
        }

        public void Add(Entry entry)
        {
            _entries.Add(entry);
        }

        public IList<Entry> GetAll() 
            => _entries;

        public Entry GetById(int id)
        {
            var entry = _entries.FirstOrDefault(p => p.Id == id);
            return entry;
        }

        public int GetNextId()
        {
            _entries = GetAll();

            if (_entries.Count() > 0)
            {
                int lastIndex = _entries.Count() - 1;

                return _entries.ElementAt(lastIndex).Id + 1;
            }
            else
            {
                return 1;
            }
        }
        public void Remove(Entry entry)
        {
            _entries.Remove(entry);
        }

        public void RemoveById(int id)
        {
            var entryToRemove = _entries.FirstOrDefault(p => p.Id == id);
            _entries.Remove(entryToRemove);
        }
    }
}
