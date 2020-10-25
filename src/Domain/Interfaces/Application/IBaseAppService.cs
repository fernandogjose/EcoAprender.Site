using System;
using System.Linq;
using System.Linq.Expressions;

namespace Domain.Interfaces.Application
{
    public interface IBaseAppService<T> where T : class
    {
        T Get(int id);

        T GetLast();

        IQueryable<T> GetAll();

        IQueryable<T> GetAll(Expression<Func<T, bool>> expression);

        void Add(T model);

        void Remove(T model);

        void Remove(Expression<Func<T, bool>> expression);

        void Update(T model);

        void Dispose();

        void Save(T model);
    }
}
