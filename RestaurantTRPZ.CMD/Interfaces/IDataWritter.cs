using RestaurantTRPZ.Models;
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

        void ShowMenuDishes(IEnumerable<DishModel> dishModels);

        void ShowSelectedDishes(IEnumerable<DishModel> dishModels);

        void ShowOrder(OrderModel orderModel);

        void ShowDish(DishModel dishModel);
    }
}
