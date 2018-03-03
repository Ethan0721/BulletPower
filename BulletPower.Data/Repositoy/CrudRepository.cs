using BulletPower.Models.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Expressions;
using System.Data.Entity;

namespace BulletPower.Data.Repositoy
{
    public class CrudRepository<T> : ICrudRepository<T> where T : Entity
    {
        private BulletPowerContext _context;
        private readonly DbSet<T> _dbSet;
        public CrudRepository(BulletPowerContext context)
        {
            _context = context;
            _dbSet = context.Set<T>();
        }
        public void Add(T entity)
        {
            _dbSet.Add(entity);
        }

        public void Delete(T entity)
        {
            _dbSet.Remove(entity);
        }

        public T Get(Expression<Func<T, bool>> where)
        {
            return _dbSet.Where(where).FirstOrDefault();
        }

        public IEnumerable<T> GetAll()
        {
            return _dbSet.AsNoTracking().ToList();
        }

        public T GetById(int id)
        {
            return _dbSet.Find(id);
        }

        public IQueryable<T> GetQueryable()
        {
            return _dbSet.AsQueryable<T>();
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }

        public void Update(T entity)
        {
            _dbSet.Attach(entity);
            _context.Entry(entity).State = EntityState.Modified;
        }
    }
}
