using RestaurantTRPZ.CMD.Interfaces;
using RestaurantTRPZ.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantTRPZ.CMD.Impl
{
    public  class ConsoleDataWritter : IDataWritter
    {
        public void ShowInterfaceInstruction()
        {
            Console.WriteLine("Choose task: ");
            Console.WriteLine("1. Get all dishes");
            Console.WriteLine("2. Get info about dish");
            Console.WriteLine("3. Add to order");
            Console.WriteLine("4. Do order");
            Console.WriteLine("5. Get all dishes from order");
            Console.WriteLine("6. Exit application");
        }

        public void ShowMenuDishes(IEnumerable<DishDTO> dishDTOs)
        {
            Console.WriteLine("======Menu==========");
            PrintDishes(dishDTOs);
            Console.WriteLine("====================");
        }

        public void ShowSelectedDishes(IEnumerable<DishDTO> dishDTOs)
        {
            Console.WriteLine("====================");
            Console.WriteLine("Your selected dishes:");
            PrintDishes(dishDTOs);
            Console.WriteLine("====================");
        }

        private void PrintDishes(IEnumerable<DishDTO> dishDTOs)
        {
            Console.WriteLine("Id | Name | Price");
            foreach (DishDTO dishDTO in dishDTOs)
            {
                Console.WriteLine(dishDTO.Id + " | " + dishDTO.Name + " | " + dishDTO.Price);
            }
        }

        public void ShowOrder(OrderDTO orderDTO)
        {
            Console.WriteLine("====================");
            Console.WriteLine("Order start at: " + orderDTO.BeginOfOrder);
            Console.WriteLine("Name | Preparing time");
            PrintDishesInOrder(orderDTO.DishOrderDTOs);
            Console.WriteLine("====================");
        }

        private void PrintDishesInOrder(IEnumerable<DishOrderDTO> dishOrderDTOs)
        {
            foreach (DishOrderDTO dishOrderDTO in dishOrderDTOs)
            {
                Console.WriteLine(dishOrderDTO.DishDTO.Name + " | " + dishOrderDTO.PreparingTime);
            }
        }

        public void ShowDish(DishDTO dishDTO)
        {
            Console.WriteLine("====================");
            Console.WriteLine("Name: " + dishDTO.Name);
            Console.WriteLine("Price: " + dishDTO.Price);
            Console.WriteLine("Dish type: " + dishDTO.DishTypeName);
            Console.WriteLine("Weight: " + dishDTO.Weight);
            Console.Write("Ingredients: ");
            PrintIngredients(dishDTO.IngredientDTOs);
            Console.Write("\n");
            Console.WriteLine("====================");
        }

        private void PrintIngredients(IEnumerable<IngredientDTO> ingredientDTOs)
        {
            foreach (IngredientDTO ingredientDTO in ingredientDTOs)
            {
                Console.Write(ingredientDTO.Name + ", ");
            }
        }
    }
}
