using System;
using System.Linq;
using System.Linq.Expressions;

namespace Domain.Interfaces.Services
{
    public interface IBaseService<T> where T : class
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

        void Validate(T model);
    }
}
