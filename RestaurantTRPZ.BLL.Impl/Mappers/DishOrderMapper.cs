using RestaurantTRPZ.Entities;
using RestaurantTRPZ.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantTRPZ.BLL.Impl.Mappers
{
    public static class DishOrderMapper
    {
        public static DishOrder ModelToEntity(this DishOrderModel dishOrderModel)
        {
            return new DishOrder()
            {
                Id = dishOrderModel.Id,
                PreparingTime = dishOrderModel.PreparingTime,
                Dish = dishOrderModel.DishModel.ModelToEntity()
            };
        }

        public static DishOrderModel EntityToModel(this DishOrder dishOrder)
        {
            return new DishOrderModel()
            {
                Id = dishOrder.Id,
                PreparingTime = dishOrder.PreparingTime,
                DishModel = dishOrder.Dish.EntityToModel()
            };
        }
    }
}
