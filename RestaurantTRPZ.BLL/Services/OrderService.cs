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

        public OrderService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public OrderDTO DoOrder(DishDTO dishDTO)
        {
            DateTime startOrder = DateTime.Now;
            Cook cook = _unitOfWork.Cooks.GetFreeCook();
            OrderDTO orderDTO = new OrderDTO
            {
                BeginOfOrder = startOrder,
                Dish = dishDTO,
                Cook = new CookDTO(), // map from cook 
                PreparingTime = dishDTO.CookingTime // Count preparing time for cooking(with time for preparing equipments)
            };
            Order order = new Order(); // Map from OrderDTO
            _unitOfWork.Orders.Create(order);
            //Add save db
            //Update dish equipments OffTime
            return orderDTO;
        }
    }
}
