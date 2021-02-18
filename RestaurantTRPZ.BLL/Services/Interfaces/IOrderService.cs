using RestaurantTRPZ.BLL.DTO_s;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantTRPZ.BLL.Services.Interfaces
{
    public interface IOrderService
    {
        OrderDTO DoOrder(int dishDTOId);
    }
}
