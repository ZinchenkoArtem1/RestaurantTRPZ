using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantTRPZ.Entities
{
    public class Order : BaseEntity<int>
    {
        public DateTime BeginOfOrder { get; set; }

        public virtual ICollection<DishOrder> DishOrders { get; set; }

        public Order()
        {
            DishOrders = new List<DishOrder>();
        }
    }
}
