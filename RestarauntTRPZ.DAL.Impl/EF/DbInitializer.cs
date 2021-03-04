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
            ingredients.Add(new Ingredient { Name = "Pork " });
            ingredients.Add(new Ingredient { Name = "Potato" });
            ingredients.Add(new Ingredient { Name = "Onion" });
            ingredients.Add(new Ingredient { Name = "Carrots" });
            ingredients.Add(new Ingredient { Name = "Salt" });
            ingredients.Add(new Ingredient { Name = "Sugar" });
            ingredients.Add(new Ingredient { Name = "Dried fruits" });
            ingredients.Add(new Ingredient { Name = "Shrimp" });
            ingredients.Add(new Ingredient { Name = "Squid" });
            ingredients.Add(new Ingredient { Name = "Salmon" });
            ingredients.Add(new Ingredient { Name = "Mushrooms" });
            ingredients.Add(new Ingredient { Name = "Lamb" });
            ingredients.Add(new Ingredient { Name = "Beef" });
            ingredients.Add(new Ingredient { Name = "Cheese" });
            ingredients.Add(new Ingredient { Name = "Cucumber" });

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
            dishes.Add(new Dish
            {
                Name = "Soup",
                CookingTime = new TimeSpan(0, 25, 0),
                DishTypeId = 1,
                EquipmentId = 2,
                Price = 100,
                Weight = 350
            });

            dishes.Add(new Dish
            {
                Name = "Pork in bake",
                CookingTime = new TimeSpan(0, 30, 0),
                DishTypeId = 1,
                EquipmentId = 1,
                Price = 200,
                Weight = 300
            });
            dishes.Add(new Dish
            {
                Name = "Vegetable salad",
                CookingTime = new TimeSpan(0, 10, 0),
                DishTypeId = 2,
                Price = 50,
                Weight = 200
            });
            dishes.Add(new Dish
            {
                Name = "Sea salad",
                CookingTime = new TimeSpan(0, 15, 0),
                DishTypeId = 2,
                Price = 80,
                Weight = 150
            });
            dishes.Add(new Dish
            {
                Name = "Cheese slizer",
                CookingTime = new TimeSpan(0, 5, 0),
                DishTypeId = 3,
                Price = 40,
                Weight = 130
            });
            dishes.Add(new Dish
            {
                Name = "Meat slizer",
                CookingTime = new TimeSpan(0, 5, 0),
                DishTypeId = 3,
                Price = 50,
                Weight = 100
            });
            dishes.Add(new Dish
            {
                Name = "Compot",
                CookingTime = new TimeSpan(0, 5, 0),
                DishTypeId = 5,
                Price = 30,
                Weight = 100
            });
            foreach (Dish dish in dishes)
                context.Dishes.Add(dish);
            context.SaveChanges();

            ICollection<DishIngredient> dishIngredients = new List<DishIngredient>();
            dishIngredients.Add(new DishIngredient
            {
                DishId = 1,
                IngredientId = 1
            });
            dishIngredients.Add(new DishIngredient
            {
                DishId = 1,
                IngredientId = 2
            });
            dishIngredients.Add(new DishIngredient
            {
                DishId = 1,
                IngredientId = 3
            });
            dishIngredients.Add(new DishIngredient
            {
                DishId = 1,
                IngredientId = 4
            });
            dishIngredients.Add(new DishIngredient
            {
                DishId = 1,
                IngredientId = 5
            });
            dishIngredients.Add(new DishIngredient
            {
                DishId = 1,
                IngredientId = 11
            });
            dishIngredients.Add(new DishIngredient
            {
                DishId = 2,
                IngredientId = 1
            });
            dishIngredients.Add(new DishIngredient
            {
                DishId = 2,
                IngredientId = 2
            });
            dishIngredients.Add(new DishIngredient
            {
                DishId = 3,
                IngredientId = 2
            });
            dishIngredients.Add(new DishIngredient
            {
                DishId = 3,
                IngredientId = 3
            });
            dishIngredients.Add(new DishIngredient
            {
                DishId = 3,
                IngredientId = 4
            });
            dishIngredients.Add(new DishIngredient
            {
                DishId = 3,
                IngredientId = 5
            });
            dishIngredients.Add(new DishIngredient
            {
                DishId = 3,
                IngredientId = 15
            });
            dishIngredients.Add(new DishIngredient
            {
                DishId = 4,
                IngredientId = 8
            });
            dishIngredients.Add(new DishIngredient
            {
                DishId = 4,
                IngredientId = 9
            });
            dishIngredients.Add(new DishIngredient
            {
                DishId = 4,
                IngredientId = 10
            });
            dishIngredients.Add(new DishIngredient
            {
                DishId = 4,
                IngredientId = 3
            });
            dishIngredients.Add(new DishIngredient
            {
                DishId = 4,
                IngredientId = 2
            });
            dishIngredients.Add(new DishIngredient
            {
                DishId = 5,
                IngredientId = 14
            });
            dishIngredients.Add(new DishIngredient
            {
                DishId = 6,
                IngredientId = 1
            });
            dishIngredients.Add(new DishIngredient
            {
                DishId = 6,
                IngredientId = 12
            });
            dishIngredients.Add(new DishIngredient
            {
                DishId = 6,
                IngredientId = 13
            });
            dishIngredients.Add(new DishIngredient
            {
                DishId = 7,
                IngredientId = 6
            });
            dishIngredients.Add(new DishIngredient
            {
                DishId = 7,
                IngredientId = 7
            });
            foreach (DishIngredient dishIngredient in dishIngredients)
                context.DishIngredients.Add(dishIngredient);
            context.SaveChanges();
            base.Seed(context);
        }
    }
}
