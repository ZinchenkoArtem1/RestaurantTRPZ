namespace RestaurantTRPZ.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Cooks",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Efficiency = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
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
                        EquipmentId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.DishTypes", t => t.DishTypeId, cascadeDelete: true)
                .ForeignKey("dbo.Equipments", t => t.EquipmentId, cascadeDelete: true)
                .Index(t => t.DishTypeId)
                .Index(t => t.EquipmentId);
            
            CreateTable(
                "dbo.DishIngredients",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Weight = c.Double(nullable: false),
                        DishId = c.Int(nullable: false),
                        IngredientId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Dishes", t => t.DishId, cascadeDelete: true)
                .ForeignKey("dbo.Ingredients", t => t.IngredientId, cascadeDelete: true)
                .Index(t => t.DishId)
                .Index(t => t.IngredientId);
            
            CreateTable(
                "dbo.Ingredients",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
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
                        OffTime = c.DateTime(nullable: false),
                        PreparingTime = c.Time(nullable: false, precision: 7),
                        SaveStateTime = c.Time(nullable: false, precision: 7),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Orders",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        BeginOfOrder = c.DateTime(nullable: false),
                        EndOfOrder = c.DateTime(nullable: false),
                        DishId = c.Int(nullable: false),
                        CookId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Cooks", t => t.CookId, cascadeDelete: true)
                .ForeignKey("dbo.Dishes", t => t.DishId, cascadeDelete: true)
                .Index(t => t.DishId)
                .Index(t => t.CookId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Orders", "DishId", "dbo.Dishes");
            DropForeignKey("dbo.Orders", "CookId", "dbo.Cooks");
            DropForeignKey("dbo.Dishes", "EquipmentId", "dbo.Equipments");
            DropForeignKey("dbo.Dishes", "DishTypeId", "dbo.DishTypes");
            DropForeignKey("dbo.DishIngredients", "IngredientId", "dbo.Ingredients");
            DropForeignKey("dbo.DishIngredients", "DishId", "dbo.Dishes");
            DropIndex("dbo.Orders", new[] { "CookId" });
            DropIndex("dbo.Orders", new[] { "DishId" });
            DropIndex("dbo.DishIngredients", new[] { "IngredientId" });
            DropIndex("dbo.DishIngredients", new[] { "DishId" });
            DropIndex("dbo.Dishes", new[] { "EquipmentId" });
            DropIndex("dbo.Dishes", new[] { "DishTypeId" });
            DropTable("dbo.Orders");
            DropTable("dbo.Equipments");
            DropTable("dbo.DishTypes");
            DropTable("dbo.Ingredients");
            DropTable("dbo.DishIngredients");
            DropTable("dbo.Dishes");
            DropTable("dbo.Cooks");
        }
    }
}
