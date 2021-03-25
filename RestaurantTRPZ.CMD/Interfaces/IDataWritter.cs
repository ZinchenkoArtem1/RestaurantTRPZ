using RestaurantTRPZ.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantTRPZ.CMD.Interfaces
{
    public interface IDataWritter
    {
        void ShowInterfaceInstruction();

        void ShowMenuDishes(IEnumerable<DishDTO> dishDTOs);

        void ShowSelectedDishes(IEnumerable<DishDTO> dishDTOs);

        void ShowOrder(OrderDTO orderDTO);

        void ShowDish(DishDTO dishDTO);
    }
}
