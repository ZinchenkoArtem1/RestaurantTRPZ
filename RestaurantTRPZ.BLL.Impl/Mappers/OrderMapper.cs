using RestaurantTRPZ.Entities;
using RestaurantTRPZ.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantTRPZ.BLL.Impl.Mappers
{
    public static class OrderMapper
    {
        public static Order ModelToEntity(this OrderModel orderModel)
        {
            return new Order()
            {
                Id = orderModel.Id,
                BeginOfOrder = orderModel.BeginOfOrder,
                DishOrders = orderModel.DishOrderModels.Select(d => d.ModelToEntity()).ToList()

            };
        }

        public static OrderModel EntityToModel(this Order order)
        {
            return new OrderModel()
            {
                Id = order.Id,
                BeginOfOrder = order.BeginOfOrder,
                DishOrderModels = order.DishOrders.Select(d => d.EntityToModel()).ToList(),

            };
        }
    }
}
