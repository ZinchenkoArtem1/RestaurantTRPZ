using RestaurantTRPZ.BLL.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantTRPZ.BLL.DTO_s
{
    public class OrderDTO
    {
        public DateTime BeginOfOrder { get; set; }
        public TimeSpan PreparingTime { get; set; }

        public DishDTO Dish { get; set; }
    }
}
