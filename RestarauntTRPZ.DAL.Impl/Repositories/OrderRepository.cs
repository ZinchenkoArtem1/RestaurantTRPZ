using RestarauntTRPZ.DAL.Abstr.Repositories;
using RestarauntTRPZ.DAL.Impl.EF;
using RestarauntTRPZ.DAL.Impl.UOW;
using RestaurantTRPZ.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestarauntTRPZ.DAL.Impl.Repositories
{
    public class OrderRepository : GenericRepository<Order, int>, IOrderRepository
    {
        public OrderRepository(RestaurantContext context) : base(context)
        {

        }
    }
}
