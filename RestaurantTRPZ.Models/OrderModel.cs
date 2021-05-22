using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantTRPZ.Models
{
    public class OrderModel
    {
        public int Id { get; set; }
        public DateTime BeginOfOrder { get; set; }

        public ICollection<DishOrderModel> DishOrderModels { get; set; }

        public OrderModel()
        {
            DishOrderModels = new List<DishOrderModel>();
        }
    }
}
