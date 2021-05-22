namespace RestarauntTRPZ.DAL.Impl.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Cooks",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Surname = c.String(),
                        Efficiency = c.Double(nullable: false),
                        WhenIsFree = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.DishOrders",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        PreparingTime = c.Time(nullable: false, precision: 7),
                        DishId = c.Int(nullable: false),
                        CookId = c.Int(nullable: false),
                        OrderId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Cooks", t => t.CookId, cascadeDelete: true)
                .ForeignKey("dbo.Dishes", t => t.DishId, cascadeDelete: true)
                .ForeignKey("dbo.Orders", t => t.OrderId, cascadeDelete: true)
                .Index(t => t.DishId)
                .Index(t => t.CookId)
                .Index(t => t.OrderId);
            
            CreateTable(
                "dbo.Dishes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Price = c.Int(nullable: false),
                        Weight = c.Double(nullable: false),
                        CookingTime = c.Time(nullable: false, precision: 7),
                        DishTypeId = c.Int(nullable: false),
                        EquipmentId = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.DishTypes", t => t.DishTypeId, cascadeDelete: true)
                .ForeignKey("dbo.Equipments", t => t.EquipmentId)
                .Index(t => t.DishTypeId)
                .Index(t => t.EquipmentId);
            
            CreateTable(
                "dbo.DishTypes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Equipments",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        OffTime = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        PreparingTime = c.Time(nullable: false, precision: 7),
                        SaveStateTime = c.Time(nullable: false, precision: 7),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Ingredients",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Orders",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        BeginOfOrder = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.IngredientDishes",
                c => new
                    {
                        Ingredient_Id = c.Int(nullable: false),
                        Dish_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Ingredient_Id, t.Dish_Id })
                .ForeignKey("dbo.Ingredients", t => t.Ingredient_Id, cascadeDelete: true)
                .ForeignKey("dbo.Dishes", t => t.Dish_Id, cascadeDelete: true)
                .Index(t => t.Ingredient_Id)
                .Index(t => t.Dish_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.DishOrders", "OrderId", "dbo.Orders");
            DropForeignKey("dbo.IngredientDishes", "Dish_Id", "dbo.Dishes");
            DropForeignKey("dbo.IngredientDishes", "Ingredient_Id", "dbo.Ingredients");
            DropForeignKey("dbo.Dishes", "EquipmentId", "dbo.Equipments");
            DropForeignKey("dbo.Dishes", "DishTypeId", "dbo.DishTypes");
            DropForeignKey("dbo.DishOrders", "DishId", "dbo.Dishes");
            DropForeignKey("dbo.DishOrders", "CookId", "dbo.Cooks");
            DropIndex("dbo.IngredientDishes", new[] { "Dish_Id" });
            DropIndex("dbo.IngredientDishes", new[] { "Ingredient_Id" });
            DropIndex("dbo.Dishes", new[] { "EquipmentId" });
            DropIndex("dbo.Dishes", new[] { "DishTypeId" });
            DropIndex("dbo.DishOrders", new[] { "OrderId" });
            DropIndex("dbo.DishOrders", new[] { "CookId" });
            DropIndex("dbo.DishOrders", new[] { "DishId" });
            DropTable("dbo.IngredientDishes");
            DropTable("dbo.Orders");
            DropTable("dbo.Ingredients");
            DropTable("dbo.Equipments");
            DropTable("dbo.DishTypes");
            DropTable("dbo.Dishes");
            DropTable("dbo.DishOrders");
            DropTable("dbo.Cooks");
        }
    }
}
