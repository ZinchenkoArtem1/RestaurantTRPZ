using RestaurantTRPZ.DAL.EF;
using RestaurantTRPZ.DAL.Entities;
using RestaurantTRPZ.DAL.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantTRPZ.DAL.Repositories
{
    public class DishRepository : Repository<Dish, int>, IDishRepository
    {
        private readonly RestaurantContext _context;

        public DishRepository(RestaurantContext context) : base(context)
        {
            _context = context;
        }
    }
}
