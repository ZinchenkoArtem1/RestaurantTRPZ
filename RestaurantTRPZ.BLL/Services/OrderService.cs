using AutoMapper;
using RestaurantTRPZ.BLL.DTO_s;
using RestaurantTRPZ.BLL.Services.Interfaces;
using RestaurantTRPZ.DAL.Entities;
using RestaurantTRPZ.DAL.Repositories.Interfaces;
using System;


namespace RestaurantTRPZ.BLL.Services
{
    public class OrderService : IOrderService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IOrderTimeCalculationService _orderTimeCalculationService;
        private readonly ICookQueueService _cookQueueService;

        public OrderService(IUnitOfWork unitOfWork, IMapper mapper, 
            IOrderTimeCalculationService orderTimeCalculationService, 
            ICookQueueService cookQueueService)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _orderTimeCalculationService = orderTimeCalculationService;
            _cookQueueService = cookQueueService;
        }

        public OrderDTO DoOrder(int dishId)
        {
            DateTime startOrder = DateTime.Now;
            Dish dishInOrder = _unitOfWork.Dishes.Read(dishId);
            Equipment equipment = dishInOrder.Equipment;
            Cook cookOrder = _cookQueueService.GetSuitableCook();
            DateTime endOrder = _orderTimeCalculationService.countOrderTime(startOrder, dishInOrder, equipment, cookOrder);
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
    }
}
