using AutoMapper;
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
        private readonly IMapper _mapper;

        public OrderService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public OrderDTO DoOrder(int dishId)
        {
            DateTime startOrder = DateTime.Now;
            Dish dishInOrder = _unitOfWork.Dishes.Read(dishId);
            Equipment equipment = dishInOrder.Equipment;
            Cook cookOrder = GetSuitableCook(); //maybe add in later, get cook by him speciality and busyness
            DateTime endOrder = GetOrderTime(startOrder, dishInOrder.CookingTime, cookOrder.Efficiency, equipment);
            equipment.OffTime = endOrder;
            _unitOfWork.Equipments.Update(equipment);
            Order order = new Order()
            {
                BeginOfOrder = startOrder,
                EndOfOrder = endOrder,
                Cook = cookOrder,
                Dish = dishInOrder
            };
            _unitOfWork.Orders.Create(order);
            OrderDTO orderDTO = _mapper.Map<OrderDTO>(order);     
            _unitOfWork.Save();
            return orderDTO;
        }


        // dont now where place this method
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

        // dont now where place this method
        private Cook GetSuitableCook() 
        {
            return _unitOfWork.Cooks.GetAll().FirstOrDefault(); //change logic of getting cook
        }
    }
}
