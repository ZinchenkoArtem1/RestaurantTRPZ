using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantTRPZ.Models
{
    public class DishOrderModel
    {
        public int Id { get; set; }
        public TimeSpan PreparingTime { get; set; }

        public DishModel DishModel { get; set; }
    }
}
