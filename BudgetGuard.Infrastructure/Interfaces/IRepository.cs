using System;
using System.Collections.Generic;
using System.Text;

namespace BudgetGuard.Infrastructure.Interfaces
{
    public interface IRepository<T>
    {
        IList<T> GetAll();
        T GetById(int id);
        void Add(T item);
        void Remove(T item);
        void RemoveById(int id);
    }
}
