using System;
using System.Collections.Generic;
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
        private readonly RestaurantContext context;
        private readonly HashSet<TEntity> entities;

        public Repository(RestaurantContext context)
        {
            this.context = context;
            entities = (HashSet<TEntity>)context.GetSetByType(typeof(TEntity));
        }

        public void Create(TEntity item)
        {
            entities.Add(item);
        }

        public void Delete(TEntity entity)
        {
            entities.Remove(entity);
        }

        public IEnumerable<TEntity> GetAll()
        {
            return entities.ToList();
        }

        public TEntity Read(TKey id)
        {
            throw new NotImplementedException();
        }

        public void Update(TEntity item)
        {
            entities.Add(item);
        }
    }
}
