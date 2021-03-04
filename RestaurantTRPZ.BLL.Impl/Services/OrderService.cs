using AutoMapper;
using RestarauntTRPZ.DAL.Abstr.UOW;
using RestaurantTRPZ.BLL.Abstr.Services;
using RestaurantTRPZ.DTO;
using RestaurantTRPZ.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantTRPZ.BLL.Impl.Services
{
    public class OrderService : IOrderService
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;
        private readonly ICookService cookService;

        public OrderService(IUnitOfWork unitOfWork, IMapper mapper,
            ICookService cookService)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
            this.cookService = cookService;
        }

        public OrderDTO DoOrder(ICollection<DishDTO> dishes)
        {
            DateTime startOrder = DateTime.Now;

            Order order = new Order
            {
                BeginOfOrder = startOrder,
            };

            foreach (DishDTO dishDTO in dishes)
            {
                Dish dish = unitOfWork.Dishes.Read(dishDTO.Id);
                Cook cook = cookService.GetSuitableCook(startOrder);
                TimeSpan dishCookTime = CountCookTimeOfDish(startOrder, dish, cook);
                DishOrder dishOrder = new DishOrder
                {
                    PreparingTime = dishCookTime,
                    Dish = dish,
                    Cook = cook,
                };
                DateTime endOrder = startOrder + dishCookTime;
                cook.WhenIsFree = endOrder;
                unitOfWork.Cooks.Update(cook);
                dish.Equipment.OffTime = endOrder;
                unitOfWork.Equipments.Update(dish.Equipment);
                order.DishOrders.Add(dishOrder);
            }

            unitOfWork.Orders.Create(order);
            unitOfWork.Save();
            return mapper.Map<OrderDTO>(order);
        }

        private TimeSpan CountCookTimeOfDish(DateTime startOrder, Dish dish, Cook cook)
        {
            TimeSpan dishCookTime = new TimeSpan((long)(dish.CookingTime.Ticks * cook.Efficiency));
            Equipment equipment = dish.Equipment;
            DateTime offEquipmentTime = equipment.OffTime;
            if (equipment == null)
            {
                return dishCookTime;
            }
            if ((startOrder - offEquipmentTime) > equipment.SaveStateTime) // equipment is free, but not ready for working
            {
                dishCookTime += equipment.PreparingTime;
            }
            else if (offEquipmentTime > startOrder)
            {  //equipment is busy 
                dishCookTime += offEquipmentTime - startOrder;
            } //else equipment is free and ready for working
            return dishCookTime;
        }
    }
}
