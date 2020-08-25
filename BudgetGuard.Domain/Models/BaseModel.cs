namespace BudgetGuard.Domain.Models
{
    public abstract class BaseModel : AuditableModel
    {
        public int Id { get; set; }
    }
}
