using AutoMapper;
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
    public class OrderTimeCalculationService : IOrderTimeCalculationService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public OrderTimeCalculationService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public DateTime countOrderTime(DateTime startOrder, Dish dish, Equipment equipment, Cook cook)
        {
            TimeSpan orderTime = new TimeSpan((long)(dish.CookingTime.Ticks * cook.Efficiency));
            DateTime offEquipmentTime = equipment.OffTime;
            if ((startOrder - offEquipmentTime) > equipment.SaveStateTime) // equipment is free, but not ready for working
            {
                orderTime += equipment.PreparingTime;
            }
            else if (offEquipmentTime > startOrder)
            {  //equipment is busy 
                orderTime += offEquipmentTime - startOrder;
            } //else equipment is free and ready for working
            return startOrder + orderTime;
        }
    }
}
