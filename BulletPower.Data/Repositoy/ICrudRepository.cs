using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;


namespace BulletPower.Data.Repositoy
{
    public interface ICrudRepository<T> where T : class
    {
        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);
        T GetById(int id);
        IEnumerable<T> GetAll();
        IQueryable<T> GetQueryable();
        T Get(Expression<Func<T, bool>> where);
        void SaveChanges();
    }
}
