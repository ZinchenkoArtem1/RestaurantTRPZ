using RestaurantTRPZ.Entities;
using RestaurantTRPZ.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantTRPZ.BLL.Impl.Mappers
{
    public static class IngredientMapper
    {
        public static Ingredient ModelToEntity(this IngredientModel ingredientModel)
        {
            return new Ingredient()
            {
                Id = ingredientModel.Id,
                Name = ingredientModel.Name,

            };
        }

        public static IngredientModel EntityToModel(this Ingredient ingredient)
        {
            return new IngredientModel()
            {
                Id = ingredient.Id,
                Name = ingredient.Name,

            };
        }
    }
}
