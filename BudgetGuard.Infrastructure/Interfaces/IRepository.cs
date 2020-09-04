using System.Collections.Generic;

namespace BudgetGuard.Infrastructure.Interfaces
{
    public interface IRepository<T>
    {
        IList<T> GetAll();
        T GetById(int id);
        void Add(T item);
        void RemoveById(int id);
    }
}
