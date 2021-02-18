using RestaurantTRPZ.DAL.Entities;
using RestaurantTRPZ.DAL.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantTRPZ.DAL.Repositories
{
    public class CookRepository : Repository<Cook, int>, ICookRepository
    {
        public CookRepository()
        {
            //need db context for realization method's
        }

        public Cook GetFreeCook()
        {
            throw new NotImplementedException();
        }
    }
}
