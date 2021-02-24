using AutoMapper;
using RestaurantTRPZ.BLL.Config;
using RestaurantTRPZ.BLL.DTO_s;
using RestaurantTRPZ.BLL.Services;
using RestaurantTRPZ.BLL.Services.Interfaces;
using RestaurantTRPZ.DAL.EF;
using RestaurantTRPZ.DAL.Entities;
using RestaurantTRPZ.DAL.Repositories;
using RestaurantTRPZ.DAL.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantTRPZ.BLL
{
    public class Test
    {
       
        public void Testing()
        {
            RestaurantContext context = new RestaurantContext();
            ICookRepository cookRepository = new CookRepository(context);
            IDishRepository dishRepository = new DishRepository(context);
            IOrderRepository orderRepository = new OrderRepository(context);
            IEquipmentRepository equipmentRepository = new EquipmentRepository(context);

            IUnitOfWork unitOfWork = new UnitOfWork(context, cookRepository, dishRepository, orderRepository, equipmentRepository);
            IMapper mapper = new Mapper(AutoMapperConfiguration.ConfigureAutoMapper());

            IDishService dishService = new DishService(unitOfWork, mapper);
            IOrderService orderService = new OrderService(unitOfWork, mapper);

            Dish dish1 = dishRepository.Read(1);

            DishDTO dishDTO1 = mapper.Map<DishDTO>(dish1);
            dishDTO1.Name = "Soup13";

            dish1 = mapper.Map<DishDTO, Dish>(dishDTO1, dish1);

            Console.WriteLine(dish1.Id);
            Console.WriteLine(dish1.Name);
            Console.WriteLine(dish1.Price);
            Console.WriteLine(dish1.Weight);
            Console.WriteLine(dish1.CookingTime);
            Console.WriteLine(dish1.DishType.Name);
            Console.WriteLine(dish1.EquipmentId);
            Console.WriteLine(dish1.Equipment.Name);
            foreach (DishIngredient ingredient in dish1.DishIngredients)
            {
                Console.WriteLine(ingredient.Ingredient.Name);
            }

            dishRepository.Update(dish1);
            unitOfWork.Save();
        }
    }
}
