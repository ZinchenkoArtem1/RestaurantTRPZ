using RestaurantTRPZ.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestarauntTRPZ.DAL.Abstr.Repositories
{
    public interface IGenericRepository<TEntity, Tkey> where TEntity : BaseEntity<Tkey>
    {
        IEnumerable<TEntity> GetAll();
        TEntity Read(Tkey id);
        void Create(TEntity item);
        void Delete(TEntity item);
        void Update(TEntity item);
    }
}
