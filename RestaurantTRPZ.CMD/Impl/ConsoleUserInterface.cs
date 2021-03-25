using Microsoft.Extensions.DependencyInjection;
using RestarauntTRPZ.DAL.Impl;
using RestarauntTRPZ.DAL.Impl.UOW;
using RestaurantTRPZ.BLL.Abstr.Services;
using RestaurantTRPZ.BLL.Impl;
using RestaurantTRPZ.BLL.Impl.Services;
using RestaurantTRPZ.CMD.Interfaces;
using RestaurantTRPZ.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantTRPZ.CMD.Impl
{
    public class ConsoleUserInterface : IUserInterface
    {
        private readonly IDishService _dishService;
        private readonly IOrderService _orderService;
        private readonly IDataWritter _consoleDataWritter;
        private readonly IDataReader _consoleDataReader;
        private ICollection<DishDTO> dishes;
        private ICollection<DishDTO> selectedDishes;

        public ConsoleUserInterface(IDishService dishService, IOrderService orderService, 
            IDataWritter dataWritter, IDataReader dataReader)
        {
            _dishService = dishService;
            _orderService = orderService;
            _consoleDataWritter = dataWritter;
            _consoleDataReader = dataReader;
            dishes = _dishService.GetAllDishes().ToList();
            selectedDishes = new List<DishDTO>();
        }

        public void Show()
        {
            bool isWork = true;
            int taskNumber;
            int dishId;
            while (isWork)
            {
                _consoleDataWritter.ShowInterfaceInstruction();
                taskNumber = _consoleDataReader.GetTaskNumber();
                switch (taskNumber)
                {
                    case 1:
                        _consoleDataWritter.ShowMenuDishes(dishes);
                        break;
                    case 2:
                        dishId = _consoleDataReader.GetDishId();
                        _consoleDataWritter.ShowDish(dishes.Where(x => x.Id == dishId).First());
                        break;
                    case 3:
                        dishId = _consoleDataReader.GetDishId();
                        AddDishToOrder(dishes.Where(x => x.Id == dishId).First());
                        break;
                    case 4:
                        _consoleDataWritter.ShowOrder(DoOrder());
                        break;
                    case 5:
                        _consoleDataWritter.ShowSelectedDishes(selectedDishes);
                        break;
                    case 6:
                        isWork = false;
                        break;
                }
            }
        }

        private void AddDishToOrder(DishDTO dishDTO)
        {
            selectedDishes.Add(dishDTO);
        }

        private OrderDTO DoOrder()
        {
            OrderDTO orderDTO = _orderService.DoOrder(selectedDishes.ToList());
            selectedDishes.Clear();
            return orderDTO;
        }
    }
}
