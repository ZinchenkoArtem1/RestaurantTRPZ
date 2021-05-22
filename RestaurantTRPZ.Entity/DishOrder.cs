using RestaurantTRPZ.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantTRPZ.Entities
{
    public class DishOrder : BaseEntity<int>
    {
        public TimeSpan PreparingTime { get; set; }

        public int DishId { get; set; }
        public virtual Dish Dish { get; set; }

        public int CookId { get; set; }
        public virtual Cook Cook { get; set; }

        public int OrderId { get; set; }
        public virtual Order Order { get; set; }
    }
}
