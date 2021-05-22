using RestaurantTRPZ.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestarauntTRPZ.DAL.Impl.EF
{
    public class DbInitializer
        : DropCreateDatabaseIfModelChanges<RestaurantContext>
    {
        protected override void Seed(RestaurantContext context)
        {
            ICollection<DishType> dishTypes = new List<DishType>();
            dishTypes.Add(new DishType { Name = "Main course" });
            dishTypes.Add(new DishType { Name = "Garnish" });
            dishTypes.Add(new DishType { Name = "Appetizer" });
            dishTypes.Add(new DishType { Name = "Dessert" });
            dishTypes.Add(new DishType { Name = "Drink" });

            foreach (DishType dishType in dishTypes)
                context.DishTypes.Add(dishType);

            ICollection<Ingredient> ingredients = new List<Ingredient>();
            Ingredient ingredient1 = new Ingredient { Name = "Pork " };
            Ingredient ingredient2 = new Ingredient { Name = "Potato" };
            Ingredient ingredient3 = new Ingredient { Name = "Onion" };
            Ingredient ingredient4 = new Ingredient { Name = "Carrots" };
            Ingredient ingredient5 = new Ingredient { Name = "Salt" };
            Ingredient ingredient6 = new Ingredient { Name = "Sugar" };
            Ingredient ingredient7 = new Ingredient { Name = "Dried fruits" };
            Ingredient ingredient8 = new Ingredient { Name = "Shrimp" };
            Ingredient ingredient9 = new Ingredient { Name = "Squid" };
            Ingredient ingredient10 = new Ingredient { Name = "Salmon" };
            Ingredient ingredient11 = new Ingredient { Name = "Mushrooms" };
            Ingredient ingredient12 = new Ingredient { Name = "Lamb" };
            Ingredient ingredient13 = new Ingredient { Name = "Beef" };
            Ingredient ingredient14 = new Ingredient { Name = "Cheese" };
            Ingredient ingredient15 = new Ingredient { Name = "Cucumber" };

            ingredients.Add(ingredient1);
            ingredients.Add(ingredient2);
            ingredients.Add(ingredient3);
            ingredients.Add(ingredient4);
            ingredients.Add(ingredient5);
            ingredients.Add(ingredient6);
            ingredients.Add(ingredient7);
            ingredients.Add(ingredient8);
            ingredients.Add(ingredient9);
            ingredients.Add(ingredient10);
            ingredients.Add(ingredient11);
            ingredients.Add(ingredient12);
            ingredients.Add(ingredient13);
            ingredients.Add(ingredient14);
            ingredients.Add(ingredient15);

            foreach (Ingredient ingredient in ingredients)
                context.Ingredients.Add(ingredient);

            ICollection<Equipment> equipments = new List<Equipment>();
            equipments.Add(new Equipment
            {
                Name = "Bake",
                PreparingTime = new TimeSpan(0, 15, 0),
                SaveStateTime = new TimeSpan(0, 30, 0)
            });
            equipments.Add(new Equipment
            {
                Name = "Plate",
                PreparingTime = new TimeSpan(0, 5, 0),
                SaveStateTime = new TimeSpan(0, 5, 0)
            });

            foreach (Equipment equipment in equipments)
                context.Equipments.Add(equipment);

            ICollection<Cook> cooks = new List<Cook>();
            cooks.Add(new Cook
            {
                Name = "Oleg",
                Surname = "Olegov",
                Efficiency = 0.7
            });
            cooks.Add(new Cook
            {
                Name = "Ivan",
                Surname = "Ivanov",
                Efficiency = 1
            });
            cooks.Add(new Cook
            {
                Name = "Vasia",
                Surname = "Vasin",
                Efficiency = 1.2
            });
            cooks.Add(new Cook
            {
                Name = "Mark",
                Surname = "Markov",
                Efficiency = 0.5
            });

            foreach (Cook cook in cooks)
                context.Cooks.Add(cook);
            context.SaveChanges();


            ICollection<Dish> dishes = new List<Dish>();

            Dish dish1 = new Dish
            {
                Name = "Soup",
                CookingTime = new TimeSpan(0, 25, 0),
                DishTypeId = 1,
                EquipmentId = 2,
                Price = 100,
                Weight = 350
            };

            Dish dish2 = new Dish
            {
                Name = "Pork in bake",
                CookingTime = new TimeSpan(0, 30, 0),
                DishTypeId = 1,
                EquipmentId = 1,
                Price = 200,
                Weight = 300
            };
            Dish dish3 = new Dish
            {
                Name = "Vegetable salad",
                CookingTime = new TimeSpan(0, 10, 0),
                DishTypeId = 2,
                Price = 50,
                Weight = 200
            };
            Dish dish4 = new Dish
            {
                Name = "Sea salad",
                CookingTime = new TimeSpan(0, 15, 0),
                DishTypeId = 2,
                Price = 80,
                Weight = 150
            };
            Dish dish5 = new Dish
            {
                Name = "Cheese slizer",
                CookingTime = new TimeSpan(0, 5, 0),
                DishTypeId = 3,
                Price = 40,
                Weight = 130
            };
            Dish dish6 = new Dish
            {
                Name = "Meat slizer",
                CookingTime = new TimeSpan(0, 5, 0),
                DishTypeId = 3,
                Price = 50,
                Weight = 100
            };
            Dish dish7 = new Dish
            {
                Name = "Compot",
                CookingTime = new TimeSpan(0, 5, 0),
                DishTypeId = 5,
                Price = 30,
                Weight = 100
            };

            dish1.Ingredients.Add(ingredient1);
            dish1.Ingredients.Add(ingredient2);
            dish1.Ingredients.Add(ingredient3);
            dish1.Ingredients.Add(ingredient4);
            dish1.Ingredients.Add(ingredient5);
            dish1.Ingredients.Add(ingredient11);
            dish2.Ingredients.Add(ingredient1);
            dish2.Ingredients.Add(ingredient2);
            dish3.Ingredients.Add(ingredient2);
            dish3.Ingredients.Add(ingredient3);
            dish3.Ingredients.Add(ingredient4);
            dish3.Ingredients.Add(ingredient5);
            dish3.Ingredients.Add(ingredient15);
            dish4.Ingredients.Add(ingredient8);
            dish4.Ingredients.Add(ingredient9);
            dish4.Ingredients.Add(ingredient10);
            dish4.Ingredients.Add(ingredient3);
            dish4.Ingredients.Add(ingredient2);
            dish5.Ingredients.Add(ingredient14);
            dish6.Ingredients.Add(ingredient1);
            dish6.Ingredients.Add(ingredient12);
            dish6.Ingredients.Add(ingredient13);
            dish7.Ingredients.Add(ingredient6);
            dish7.Ingredients.Add(ingredient7);

            dishes.Add(dish1);
            dishes.Add(dish2);
            dishes.Add(dish3);
            dishes.Add(dish4);
            dishes.Add(dish5);
            dishes.Add(dish6);
            dishes.Add(dish7);

            foreach (Dish dish in dishes)
                context.Dishes.Add(dish);
            context.SaveChanges();

            base.Seed(context);
        }
    }
}
