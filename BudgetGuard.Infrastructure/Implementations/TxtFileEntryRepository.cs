using BudgetGuard.Domain.Models;
using BudgetGuard.Infrastructure.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace BudgetGuard.Infrastructure.Implementations
{
    public class TxtFileEntryRepository : IEntryRepository
    {
        private const string _filePath = "entries.txt";

        private IList<Entry> _entries;

        public TxtFileEntryRepository()
        {
            _entries = new List<Entry>();
        }

        public int Add(Entry entry)
        {
            var record = ConvertEntryObjectToFileRecord(entry);
            File.AppendAllText(_filePath, record);
            return entry.Id;
        }

        public IList<Entry> GetAll()
        {
            _entries = new List<Entry>();

            if (File.Exists(_filePath) == false)
            {
                return _entries;
            }

            IEnumerable<string> records = File.ReadAllLines(_filePath);

            foreach (var record in records)
            {
                Entry entry = ConvertFileRecordToEntryObject(record);

                _entries.Add(entry);
            }

            return _entries;
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

        public Entry GetById(int id)
        {
            var entries = File.ReadAllLines(_filePath);
            Entry entryToGet = null;

            foreach (var entry in entries)
            {
                if (EntryHasId(id, entry))
                {
                    entryToGet = ConvertFileRecordToEntryObject(entry);
                    break;
                }
            }
            return entryToGet;
        }

        public void RemoveById(int id)
        {
            var entries = File.ReadAllLines(_filePath);

            var entriesToSave = new List<string>();

            foreach (var entry in entries)
            {
                if (!EntryHasId(id, entry))
                {
                    entriesToSave.Add(entry);
                }
            }
            File.WriteAllLines(_filePath, entriesToSave);
        }

        private Entry ConvertFileRecordToEntryObject(string record)
        {
            string[] columns = record.Split(';');

            int id = int.Parse(columns[0]);
            string name = columns[1];
            string type = columns[2];
            decimal amount = decimal.Parse(columns[3]);
            DateTime date = DateTime.ParseExact(columns[4], "yyyy-MM-dd", null);

            if (type == "Income")
            {
                return new Income(id, amount, name, date);
            }

            return new Outcome(id, amount, name, date);
        }

        private string ConvertEntryObjectToFileRecord(Entry entry)
        {
            string type = (entry.Type == EntryType.Income) ? "Income" : "Outcome";

            string record =
                $"{entry.Id};{entry.Name};{type};{entry.Amount};{entry.Date:yyyy-MM-dd}" + Environment.NewLine;

            return record;
        }

        private bool EntryHasId(int id, string entry)
        {
            string[] columns = entry.Split(';');

            int.TryParse(columns[0], out int entryId);

            return id == entryId;
        }
    }
}
