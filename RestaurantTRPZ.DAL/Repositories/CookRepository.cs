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
    public class CookRepository : Repository<Cook, int>, ICookRepository
    {
        private readonly RestaurantContext _context;

        public CookRepository(RestaurantContext context) : base(context)
        {
            _context = context;
        }

        public Cook GetFreeCook()
        {
            return _context.Cooks.First(); //need change logic of getting free cook
        }
    }
}
