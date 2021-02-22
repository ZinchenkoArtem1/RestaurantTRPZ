using RestaurantTRPZ.DAL.EF;
using RestaurantTRPZ.DAL.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantTRPZ.DAL.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly RestaurantContext _context;

        public ICookRepository Cooks { get; }
        public IDishRepository Dishes { get; }
        public IOrderRepository Orders { get; }

        public UnitOfWork(RestaurantContext context, ICookRepository cookRepository,
            IDishRepository dishRepository, IOrderRepository orderRepository)
        {
            _context = context;
            Cooks = cookRepository;
            Dishes = dishRepository;
            Orders = orderRepository;
        }

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
