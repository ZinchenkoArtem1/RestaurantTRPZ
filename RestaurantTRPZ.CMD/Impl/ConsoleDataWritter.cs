using RestaurantTRPZ.CMD.Interfaces;
using RestaurantTRPZ.Models;
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

        public void ShowMenuDishes(IEnumerable<DishModel> dishModels)
        {
            Console.WriteLine("======Menu==========");
            PrintDishes(dishModels);
            Console.WriteLine("====================");
        }

        public void ShowSelectedDishes(IEnumerable<DishModel> dishModels)
        {
            Console.WriteLine("====================");
            Console.WriteLine("Your selected dishes:");
            PrintDishes(dishModels);
            Console.WriteLine("====================");
        }

        private void PrintDishes(IEnumerable<DishModel> dishModels)
        {
            Console.WriteLine("Id | Name | Price");
            foreach (DishModel dishModel in dishModels)
            {
                Console.WriteLine(dishModel.Id + " | " + dishModel.Name + " | " + dishModel.Price);
            }
        }

        public void ShowOrder(OrderModel orderModel)
        {
            Console.WriteLine("====================");
            Console.WriteLine("Order start at: " + orderModel.BeginOfOrder);
            Console.WriteLine("Name | Preparing time");
            PrintDishesInOrder(orderModel.DishOrderModels);
            Console.WriteLine("====================");
        }

        private void PrintDishesInOrder(IEnumerable<DishOrderModel> dishOrderModels)
        {
            foreach (DishOrderModel dishOrderModel in dishOrderModels)
            {
                Console.WriteLine(dishOrderModel.DishModel.Name + " | " + dishOrderModel.PreparingTime);
            }
        }

        public void ShowDish(DishModel dishModel)
        {
            Console.WriteLine("====================");
            Console.WriteLine("Name: " + dishModel.Name);
            Console.WriteLine("Price: " + dishModel.Price);
            Console.WriteLine("Dish type: " + dishModel.DishTypeModel.Name);
            Console.WriteLine("Weight: " + dishModel.Weight);
            Console.Write("Ingredients: ");
            PrintIngredients(dishModel.IngredientModels);
            Console.Write("\n");
            Console.WriteLine("====================");
        }

        private void PrintIngredients(IEnumerable<IngredientModel> ingredientModels)
        {
            foreach (IngredientModel ingredientModel in ingredientModels)
            {
                Console.Write(ingredientModel.Name + ", ");
            }
        }
    }
}
