using BudgetGuard.Domain.Models;
using BudgetGuard.Infrastructure.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BudgetGuard.Infrastructure.Implementations
{
    public class InMemoryEntryRepository : IEntryRepository
    {
        public IList<Entry> Entries { get; set; }

        public InMemoryEntryRepository()
        {
            Entries = new List<Entry>();
        }

        public void Add(Entry item)
        {
            Entries.Add(item);
        }

        public IList<Entry> GetAll() 
            => Entries;

        public Entry GetById(int id)
        {
            var entry = Entries.FirstOrDefault(p => p.Id == id);
            return entry;
        }

        public int GetNextId()
        {
            Entries = GetAll();

            if (Entries.Count() > 0)
            {
                int lastIndex = Entries.Count() - 1;

                return Entries.ElementAt(lastIndex).Id + 1;
            }
            else
            {
                return 1;
            }
        }

        public void Remove(Entry item)
        {
            Entries.Remove(item);
        }

        public void RemoveById(int id)
        {
            var entryToRemove = Entries.FirstOrDefault(p => p.Id == id);
            Entries.Remove(entryToRemove);
        }
    }
}
