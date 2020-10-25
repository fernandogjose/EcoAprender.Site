using System;
using Domain.Interfaces.Application;
using Domain.Interfaces.Services;


namespace Application.Services
{
    public class BaseAppService<T> : IDisposable, IBaseAppService<T> where T : class
    {
        private readonly IBaseService<T> _baseService;

        public BaseAppService(IBaseService<T> baseService)
        {
            _baseService = baseService;
        }

        public T Get(int id)
        {
            return _baseService.Get(id);
        }

        public T GetLast()
        {
            return _baseService.GetLast();
        }

        public System.Linq.IQueryable<T> GetAll()
        {
            return _baseService.GetAll();
        }

        public System.Linq.IQueryable<T> GetAll(System.Linq.Expressions.Expression<Func<T, bool>> expression)
        {
            return _baseService.GetAll(expression);
        }

        public virtual void Add(T model)
        {
            _baseService.Validate(model);
            _baseService.Add(model);
        }

        public virtual void Remove(T model)
        {
            _baseService.Remove(model);
        }

        public void Remove(System.Linq.Expressions.Expression<Func<T, bool>> expression)
        {
            _baseService.Remove(expression);
        }

        public virtual void Update(T model)
        {
            _baseService.Validate(model);
            _baseService.Update(model);
        }

        public virtual void Save(T model)
        {
            var id = 0;
            id = (int)model.GetType().GetProperty("Id").GetValue(model);

            if (id > 0)
            {
                Update(model);
            }
            else
            {
                Add(model);
            }
        }

        public void Dispose()
        {
            _baseService.Dispose();
        }
    }
}
