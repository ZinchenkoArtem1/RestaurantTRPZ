using RestaurantTRPZ.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestarauntTRPZ.DAL.Abstr.Repositories
{
    public interface IOrderRepository : IGenericRepository<Order, int>
    {
    }
}
