using System;
using System.Collections.Generic;

namespace RestaurantTRPZ.DTO
{
    public class OrderDTO
    {
        public int Id { get; set; }
        public DateTime BeginOfOrder { get; set; }

        public ICollection<DishOrderDTO> DishOrderDTOs { get; set; }

        public OrderDTO()
        {
            DishOrderDTOs = new List<DishOrderDTO>();
        }
    }
}
