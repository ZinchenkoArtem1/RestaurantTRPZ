using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantTRPZ.DTO
{
    public class DishOrderDTO
    {
        public int Id { get; set; }
        public TimeSpan PreparingTime { get; set; }

        public DishDTO DishDTO { get; set; }

    }
}
