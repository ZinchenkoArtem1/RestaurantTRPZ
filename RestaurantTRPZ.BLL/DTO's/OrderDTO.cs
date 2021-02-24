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
        public DateTime EndOfOrder { get; set; }

        public DishDTO DishDTO { get; set; }
    }
}
