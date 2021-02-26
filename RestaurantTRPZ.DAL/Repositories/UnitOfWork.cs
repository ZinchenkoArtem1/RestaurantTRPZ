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
        public readonly RestaurantContext _context;

        public ICookRepository Cooks { get; }
        public IDishRepository Dishes { get; }
        public IOrderRepository Orders { get; }
        public IEquipmentRepository Equipments { get; }

        public UnitOfWork(RestaurantContext context, ICookRepository cookRepository,
            IDishRepository dishRepository, IOrderRepository orderRepository, IEquipmentRepository equipmentRepository)
        {
            _context = context;
            Cooks = cookRepository;
            Dishes = dishRepository;
            
            Orders = orderRepository;
            Equipments = equipmentRepository;
        }

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
