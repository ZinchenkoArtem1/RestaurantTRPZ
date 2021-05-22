namespace RestarauntTRPZ.DAL.Impl.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<RestarauntTRPZ.DAL.Impl.EF.RestaurantContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "RestarauntTRPZ.DAL.Impl.EF.RestaurantContext";
        }

        protected override void Seed(RestarauntTRPZ.DAL.Impl.EF.RestaurantContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method
            //  to avoid creating duplicate seed data.
        }
    }
}
