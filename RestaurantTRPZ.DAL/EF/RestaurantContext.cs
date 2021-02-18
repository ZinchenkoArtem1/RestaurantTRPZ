using RestaurantTRPZ.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantTRPZ.DAL.EF
{
    /*
     ToDo Connect EF 
    */
     
    public class RestaurantContext
    {
        public ICollection<Dish> Dishes { get; set; }
        public ICollection<Order> Orders { get; set; }
        public ICollection<Equipment> Equipments { get; set; }
        public ICollection<Cook> Cooks { get; set; }
        public ICollection<Ingredient> Ingredients { get; set; }

        public RestaurantContext()
        {
            Dishes = new List<Dish>();
            Orders = new List<Order>();
            Equipments = new List<Equipment>();
            Cooks = new List<Cook>();
            Ingredients = new List<Ingredient>();
        }

        //Very bad, when connect db delete this
        public IEnumerable<object> GetSetByType(Type type)
        {
            switch (type.Name)
            {
                case "Dish":
                    return Dishes;
                case "Order":
                    return Orders;
                case "Equipment":
                    return Equipments;
                case "Cook":
                    return Cooks;
                case "Ingredient":
                    return Ingredients;
                default:
                    return null;
            }
        }


        
    }
}
