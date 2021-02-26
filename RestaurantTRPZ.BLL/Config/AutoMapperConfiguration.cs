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
    public class AutoMapperConfig : Profile
    {
        public AutoMapperConfig()
        {
            CreateMap<Dish, DishDTO>()
                .ForMember(m => m.IngredientDTOs, opt => opt.MapFrom(di => di.DishIngredients.Select(i => i.Ingredient)));
            CreateMap<DishDTO, Dish>();
            CreateMap<DishType, DishTypeDTO>();
            CreateMap<DishTypeDTO, DishType>();
            CreateMap<Ingredient, IngredientDTO>();
            CreateMap<IngredientDTO, Ingredient>();
            CreateMap<Order, OrderDTO>();
            CreateMap<OrderDTO, Order>();
        }
    }
}
