using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestaurantTRPZ.DAL.EF;
using RestaurantTRPZ.DAL.Repositories.Interfaces;

namespace RestaurantTRPZ.DAL.Repositories
{
    public class Repository<TEntity, TKey> : IRepository<TEntity, TKey> where TEntity : class
    {
        /* 
         Change when add EF and real database
        */
        private readonly RestaurantContext _context;
        private readonly DbSet<TEntity> entities;

        public Repository(RestaurantContext context)
        {
            _context = context;
            entities = context.Set<TEntity>();
        }

        public void Create(TEntity item)
        {
            entities.Add(item);
        }

        public void Delete(TEntity entity)
        {
            entities.Remove(entity);
        }

        public virtual IEnumerable<TEntity> GetAll()
        {
            return entities.AsNoTracking().ToList();
        }

        public TEntity Read(TKey id)
        {
            return entities.Find(id);
        }

        public void Update(TEntity item)
        {
            _context.Entry<TEntity>(item).State = EntityState.Modified;
        }
    }
}
