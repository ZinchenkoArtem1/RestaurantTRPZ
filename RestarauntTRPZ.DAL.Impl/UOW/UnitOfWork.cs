using RestarauntTRPZ.DAL.Abstr.Repositories;
using RestarauntTRPZ.DAL.Abstr.UOW;
using RestarauntTRPZ.DAL.Impl.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestarauntTRPZ.DAL.Impl.UOW
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly RestaurantContext context;

        public ICookRepository Cooks { get; }
        public IDishRepository Dishes { get; }
        public IOrderRepository Orders { get; }
        public IEquipmentRepository Equipments { get; }

        public UnitOfWork(RestaurantContext context, ICookRepository cookRepository,
            IDishRepository dishRepository, IOrderRepository orderRepository,
            IEquipmentRepository equipmentRepository)
        {
            this.context = context;
            Cooks = cookRepository;
            Dishes = dishRepository;
            Orders = orderRepository;
            Equipments = equipmentRepository;
        }

        public void Save()
        {
            context.SaveChanges();
        }
    }
}
