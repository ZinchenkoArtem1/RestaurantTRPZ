using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantTRPZ.DAL.Repositories.Interfaces
{
    public interface IRepository<TEntity, TKey> where TEntity : class
    {
        void Create(TEntity item);
        TEntity Read(TKey id);
        void Update(TEntity item);
        void Delete(TEntity entity);
        IEnumerable<TEntity> GetAll();
    }
}
