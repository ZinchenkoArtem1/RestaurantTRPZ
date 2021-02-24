using AutoMapper;
using RestaurantTRPZ.BLL.DTO_s;
using RestaurantTRPZ.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantTRPZ.BLL.Config
{
    public static class AutoMapperConfiguration
    {
        public static MapperConfiguration ConfigureAutoMapper()
        {

            MapperConfiguration configuration = new MapperConfiguration(confg =>
            {
                confg.CreateMap<Dish, DishDTO>()
                .ForMember(m => m.IngredientDTOs, opt => opt.MapFrom(di => di.DishIngredients.Select(i => i.Ingredient)));
                confg.CreateMap<DishDTO, Dish>();
                confg.CreateMap<DishType, DishTypeDTO>();
                confg.CreateMap<DishTypeDTO, DishType> ();
                confg.CreateMap<Ingredient, IngredientDTO>();
                confg.CreateMap<IngredientDTO, Ingredient>();
                confg.CreateMap<Order, OrderDTO>();
                confg.CreateMap<OrderDTO, Order>();
            });
            return configuration;
        }
    }
}
