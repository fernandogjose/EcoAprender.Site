using System;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using Data.Contexts;
using Domain.Interfaces.Repositories;


namespace Data.Repositories
{
    public class BaseRepository<T> : IDisposable, IBaseRepository<T> where T : class
    {
        public readonly GenericoDbContext Context;

        #region --- Construtor ---
        public BaseRepository()
        {
            Context = new GenericoDbContext();
        }
        #endregion

        public T Get(int id)
        {
            return Context.Set<T>().Find(id);
        }

        public T GetLast()
        {
            return Context.Set<T>().FirstOrDefault();
        }

        public IQueryable<T> GetAll()
        {
            return Context.Set<T>();
        }

        public IQueryable<T> GetAll(Expression<Func<T, bool>> expression)
        {
            return Context.Set<T>().Where(expression);
        }

        public void Add(T model)
        {
            Context.Set<T>().Add(model);
            Context.SaveChanges();
        }

        public void Remove(T model)
        {
            Context.Set<T>().Remove(model);
            Context.SaveChanges();
        }

        public void Remove(Expression<Func<T, bool>> expression)
        {
            var model = Context.Set<T>().Where(expression);

            foreach (var item in model)
            {
                Context.Set<T>().Remove(item);
            }

            Context.SaveChanges();
        }

        public virtual void Update(T model)
        {
            Context.Entry(model).State = EntityState.Modified;
            Context.SaveChanges();
        }

        public void Dispose()
        {
            Context.Dispose();
        }
    }
}