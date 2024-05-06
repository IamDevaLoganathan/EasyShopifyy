using EasyShopify.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace EasyShopify.DataAccess.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {

        private readonly ApplicationDbContext dbContext;

        internal DbSet<T> dbSet;
        public Repository(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
            this.dbSet = dbContext.Set<T>();
        }
        public void Add(T Entity)
        {
           dbSet.Add(Entity);
        }

        public T Get(Expression<Func<T, bool>> filter)
        {
            IQueryable<T> query = dbSet.Where(filter);

            return query.FirstOrDefault();
        }

        public IEnumerable<T> GetAll(Expression<Func<T, bool>>? filter, string? includeProperties=null)
        {

            IQueryable<T> query = dbSet;

            if (filter != null)
            {
                query = dbSet.Where(filter);
            }
            if (!string.IsNullOrEmpty(includeProperties))
            {
                foreach(var includeProp in includeProperties.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries)) 
                { 
                    query = query.Include(includeProp);
                }
                
            }

            return query.ToList();
        }

        public void Remove(T Entity)
        {
            dbSet.Remove(Entity);
        }

        public void RemoveRange(IEnumerable<T> Entities)
        {
            dbSet.RemoveRange(Entities);
        }
    }
}
