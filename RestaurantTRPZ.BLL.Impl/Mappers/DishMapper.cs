using RestaurantTRPZ.Entities;
using RestaurantTRPZ.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantTRPZ.BLL.Impl.Mappers
{
    public static class DishMapper
    {
        public static Dish ModelToEntity(this DishModel dishModel)
        {
            return new Dish()
            {
                Id = dishModel.Id,
                Name = dishModel.Name,
                Price = dishModel.Price,
                Weight = dishModel.Weight,
                CookingTime = dishModel.CookingTime,
                DishTypeId = dishModel.DishTypeModel.Id,
                DishType = DishTypeMapper.ModelToEntity(dishModel.DishTypeModel),
                Ingredients = dishModel.IngredientModels.Select(i => i.ModelToEntity()).ToList(),
                
            };
        }

        public static DishModel EntityToModel(this Dish dish)
        {
            return new DishModel()
            {
                Id = dish.Id,
                Name = dish.Name,
                Price = dish.Price,
                Weight = dish.Weight,
                CookingTime = dish.CookingTime,
                DishTypeModel = DishTypeMapper.EntityToModel(dish.DishType),
                IngredientModels = dish.Ingredients.Select(i =>i.EntityToModel()).ToList(), 

            };
        }
    }
}
