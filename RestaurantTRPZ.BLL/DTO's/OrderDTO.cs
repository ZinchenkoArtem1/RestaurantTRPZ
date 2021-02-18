using RestaurantTRPZ.BLL.DTO_s;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantTRPZ.BLL.DTO_s
{
    public class OrderDTO
    {
        public int Id { get; set; }
        public DateTime BeginOfOrder { get; set; }
        public TimeSpan PreparingTime { get; set; }

        public DishDTO Dish { get; set; }
        public CookDTO Cook { get; set; }
    }
}
