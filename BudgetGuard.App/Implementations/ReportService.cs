using BudgetGuard.App.Helpers;
using BudgetGuard.App.Interfaces;
using BudgetGuard.Domain.Models;
using BudgetGuard.Infrastructure.Interfaces;
using System.Collections.Generic;

namespace BudgetGuard.App.Implementations
{
    public class ReportService : IReportService
    {
        private readonly IEntryRepository _repository;

        public ReportService(IEntryRepository repository)
        {
            _repository = repository;
        }

        public Summary ShowSummaryFromSelectedMonth(int year, int month)
        {
            IEnumerable<Entry> entries = GetEntriesFromSelectedMonth(year, month);

            var income = SumIncomes(entries);
            var outcome = SumOutcomes(entries);

            var balance = CalculateBalance(income, outcome);

            var summary = new Summary(income, outcome, balance);

            return summary;
        }

        private decimal CalculateBalance(decimal incomes, decimal outcomes)
            => incomes - outcomes;

        private IEnumerable<Entry> GetEntriesFromSelectedMonth(int year, int month)
        {
            IEnumerable<Entry> entries = _repository.GetAll();

            IList<Entry> entriesForStatistics = new List<Entry>();

            foreach (var entry in entries)
            {
                if (entry.Date.Year == year && entry.Date.Month == month)
                {
                    entriesForStatistics.Add(entry);
                }
            }

            return entriesForStatistics;
        }

        private decimal SumIncomes(IEnumerable<Entry> entries)
        {
            decimal result = 0.0M;

            foreach (var entry in entries)
            {
                if (entry.Type == EntryType.Income)
                {
                    result += entry.Amount;
                }
            }
            return result;
        }

        private decimal SumOutcomes(IEnumerable<Entry> entries)
        {
            decimal result = 0.0M;

            foreach (var entry in entries)
            {
                if (entry.Type == EntryType.Outcome)
                {
                    result += entry.Amount;
                }
            }
            return result;
        }
    }
}
