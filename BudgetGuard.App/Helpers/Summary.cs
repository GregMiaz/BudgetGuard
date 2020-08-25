namespace BudgetGuard.App.Helpers
{
    public class Summary
    {
        public Summary(decimal incomes, decimal outcomes, decimal balance)
        {
            Incomes = incomes;
            Outcomes = outcomes;
            Balance = balance;
        }

        public decimal Incomes { get; private set; }
        public decimal Outcomes { get; private set; }
        public decimal Balance { get; private set; }
    }
}
