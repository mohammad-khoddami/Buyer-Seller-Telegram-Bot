namespace WebApplication1.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using Services;
    using Models;

    internal sealed class Configuration : DbMigrationsConfiguration<WebApplication1.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
           
        }

        protected override void Seed(WebApplication1.ApplicationDbContext context)
        {
             context.Database.ExecuteSqlCommand("delete from Messages");
            //HttpClients clt = new HttpClients();
            //var province = clt.GetProvince();
            //for (int i = 0; i < province.Length; i++)
            //    context.Provinces.AddOrUpdate(province[i]);
            //context.SaveChanges();

            //for (int i = 0; i < province.Length; i++)
            //{
            //    var city = clt.GetCities(province[i].Value);
            //    for (int j = 0; j < city.Length; j++)
            //        context.Cities.AddOrUpdate(city[j]);
            //    context.SaveChanges();
            //}

            //// var category = clt.GetCategory();
            ////     for (int i = 0; i < category.Length; i++)
            ////    context.BaseCategories.AddOrUpdate();

            //CategoriesService categoryservice = new CategoriesService();
            //var basecategory = categoryservice.BaseCategories();
            //for (int i = 0; i < basecategory.Length; i++)
            //    context.BaseCategories.AddOrUpdate(basecategory[i]);
            //context.SaveChanges();

            //for (int i = 0; i < basecategory.Length; i++)
            //{
            //    var minorcategory = categoryservice.MinorCategories(basecategory[i].Id);
            //    for (int j = 0; j < minorcategory.Length; j++)
            //        context.MinorCategories.AddOrUpdate(minorcategory[j]);
            //    context.SaveChanges();
            //}

            ////  This method will be called after migrating to the latest version.

            ////  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            ////  to avoid creating duplicate seed data. E.g.
            ////
            ////    context.People.AddOrUpdate(
            ////      p => p.FullName,
            ////      new Person { FullName = "Andrew Peters" },
            ////      new Person { FullName = "Brice Lambson" },
            ////      new Person { FullName = "Rowan Miller" }
            ////    );
            ////
        }
    }
}
