using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantTRPZ.DAL.Repositories.Interfaces
{
    public interface IUnitOfWork
    {
        ICookRepository Cooks { get; }
        IDishRepository Dishes { get; }
        IOrderRepository Orders { get; }
        IEquipmentRepository Equipments { get; }

        void Save();
    }
}
