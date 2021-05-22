using RestarauntTRPZ.DAL.Abstr.Repositories;
using RestarauntTRPZ.DAL.Impl.EF;
using RestaurantTRPZ.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestarauntTRPZ.DAL.Impl.Repositories
{
    public class CookRepository : GenericRepository<Cook, int>, ICookRepository
    {
        public CookRepository(RestaurantContext context) : base(context)
        {

        }

        public IEnumerable<Cook> GetAllOrderedByWhenIsFreeTime()
        {
            return dbSet.OrderBy(c => c.WhenIsFree)
                .ToList();
        }

        public IEnumerable<Cook> GetFreeCooksByWhenIsFreeTime(DateTime startOrder)
        {
            return dbSet.Where(dt => startOrder > dt.WhenIsFree)
                .ToList();
        }
    }
}
