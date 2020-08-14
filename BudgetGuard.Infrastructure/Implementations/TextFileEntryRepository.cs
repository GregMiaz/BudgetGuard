using BudgetGuard.Domain.Models;
using BudgetGuard.Infrastructure.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace BudgetGuard.Infrastructure.Implementations
{
    public class TextFileEntryRepository : IEntryRepository
    {
        private readonly string _filePath;

        public TextFileEntryRepository(string filePath)
        {
            _filePath = filePath;
        }

        public void Add(Entry entry)
        {
            var record = ConvertEntryObjectToFileRecord(entry);
            File.AppendAllText(_filePath, record);
        }

        public IList<Entry> GetAll()
        {
            IList<Entry> entries = new List<Entry>();

            if (File.Exists(_filePath) == false)
            {
                return entries;
            }

            IEnumerable<string> records = File.ReadAllLines(_filePath);

            foreach (var record in records)
            {
                Entry entry = ConvertFileRecordToEntryObject(record);

                entries.Add(entry);
            }

            return entries;
        }

        public void Remove(Entry entry)
        {
            throw new NotImplementedException();
        }

        public int GetNextId()
        {
            IList<Entry> entries = GetAll();

            if (entries.Count() > 0)
            {
                int lastIndex = entries.Count() - 1;

                return entries.ElementAt(lastIndex).Id + 1;
            }
            else
            {
                return 1;
            }
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
    }
}
