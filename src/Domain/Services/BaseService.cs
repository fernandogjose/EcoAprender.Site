using System;
using System.Linq;
using System.Linq.Expressions;
using Domain.Interfaces.Repositories;
using Domain.Interfaces.Services;


namespace Domain.Services
{
    public class BaseService<T> : IDisposable, IBaseService<T> where T : class
    {
        private readonly IBaseRepository<T> _baseRepository;

        public BaseService(IBaseRepository<T> baseRepository)
        {
            _baseRepository = baseRepository;
        }

        public T Get(int id)
        {
            return _baseRepository.Get(id);
        }

        public T GetLast()
        {
            return _baseRepository.GetLast();
        }

        public virtual IQueryable<T> GetAll()
        {
            return _baseRepository.GetAll();
        }

        public IQueryable<T> GetAll(Expression<Func<T, bool>> expression)
        {
            return _baseRepository.GetAll(expression);
        }

        public virtual void Add(T model)
        {
            _baseRepository.Add(model);
        }

        public void Remove(T model)
        {
            _baseRepository.Remove(model);
        }

        public void Remove(Expression<Func<T, bool>> expression)
        {
            _baseRepository.Remove(expression);
        }

        public virtual void Update(T model)
        {
            _baseRepository.Update(model);
        }

        public void Dispose()
        {
            _baseRepository.Dispose();
        }

        public virtual void Validate(T model)
        {

        }
    }
}