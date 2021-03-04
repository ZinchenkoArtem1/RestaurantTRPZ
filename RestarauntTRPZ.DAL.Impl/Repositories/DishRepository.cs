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
    public class DishRepository : GenericRepository<Dish, int>, IDishRepository
    {
        public DishRepository(RestaurantContext context) : base(context)
        {

        }
    }
}
