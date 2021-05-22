using RestaurantTRPZ.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantTRPZ.BLL.Abstr.Services
{
    public interface IOrderService
    {
        OrderModel DoOrder(ICollection<DishModel> dishes);
    }
}
