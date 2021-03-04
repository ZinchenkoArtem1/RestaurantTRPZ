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
    }
}
