using RestaurantTRPZ.BLL.DTO_s;
using RestaurantTRPZ.BLL.Services.Interfaces;
using RestaurantTRPZ.DAL.Entities;
using RestaurantTRPZ.DAL.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantTRPZ.BLL.Services
{
    class OrderService : IOrderService
    {
        private readonly IUnitOfWork _unitOfWork;

        //ToDo add mapper
        public OrderService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public OrderDTO DoOrder(DishDTO dishDTO)
        {
            DateTime startOrder = DateTime.Now;
            Dish dishOrder = new Dish(); //Map from dishDTO
            Equipment equipmentOrder = dishOrder.Equipment;

            Cook cookOrder = GetSuitableCook(); //maybe add in later, get cook by him speciality and busyness
            DateTime endOrder = GetOrderTime(startOrder, dishOrder.CookingTime, cookOrder.Efficiency, equipmentOrder);
            equipmentOrder.OffTime = endOrder;

            Order order = new Order()
            {
                BeginOfOrder = startOrder,
                EndOfOrder = endOrder,
                Cook = cookOrder,
                Dish = dishOrder
            };

            OrderDTO orderDTO = new OrderDTO(); // Map from Order
            _unitOfWork.Equipments.Update(equipmentOrder);
            _unitOfWork.Orders.Create(order);
            _unitOfWork.Save();

            return orderDTO;
        }

        private DateTime GetOrderTime(DateTime startOrder, TimeSpan cookingTime, double cookEfficiency, Equipment equipment)
        {
            DateTime orderTime = new DateTime((long)(cookingTime.Ticks * cookEfficiency));
            DateTime offEquipmentTime = equipment.OffTime;
            if((startOrder - offEquipmentTime) > equipment.SaveStateTime) // equipment is free, but not ready for working
            {
                orderTime += equipment.PreparingTime;  
            } else if (offEquipmentTime > orderTime) {  //equipment is busy 
                orderTime += offEquipmentTime - orderTime; 
            } //else equipment is free and ready for working
            return orderTime;
        }

        private Cook GetSuitableCook() 
        {
            return _unitOfWork.Cooks.GetAll().FirstOrDefault(); //change logic of getting cook
        }
    }
}
