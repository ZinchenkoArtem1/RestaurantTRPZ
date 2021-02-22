using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantTRPZ.DAL.Entities
{
    public class Order : BaseEntity<int>
    {
        public DateTime BeginOfOrder { get; set; }
        public TimeSpan PreparingTime { get; set; }

        public int DishId { get; set; }
        public virtual Dish Dish { get; set; }

        public int CookId { get; set; }
        public virtual Cook Cook { get; set; }

    }
}
