using System;
using System.Collections.Generic;
using System.Text;

namespace BudgetGuard.Domain.Models
{
    public abstract class BaseModel : AuditableModel
    {
        public int Id { get; set; }
    }
}
