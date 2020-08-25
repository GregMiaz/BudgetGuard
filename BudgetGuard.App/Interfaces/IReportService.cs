using BudgetGuard.App.Helpers;

namespace BudgetGuard.App.Interfaces
{
    public interface IReportService
    {
        Summary ShowSummaryFromSelectedMonth(int year, int month);
    }
}