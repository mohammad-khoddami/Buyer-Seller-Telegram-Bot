using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using WebApplication1.Models;
using WebApplication1.Services;

namespace WebApplication1
{
    public class ApplicationDbContext:DbContext
    {

        public DbSet<Shop> Shops { get; set; }

        public DbSet<ProvinceModel> Provinces { get; set; }

        public DbSet<CityModel> Cities { get; set; }

        public DbSet<BaseCategory> BaseCategories{ get; set; }

        public DbSet<MinorCategory> MinorCategories { get; set; }

        public DbSet<Field> Fields { get; set; }

        public DbSet<DeleteUserModels> DeleteUsers { get; set; }

        public DbSet<WhoAmI> WhoAmIs { get; set; }

        public DbSet<BuyerModel> Buyers { get; set; }

        public DbSet<Request> Requests { get; set; }

        public DbSet<Models.Message> Messages { get; set; }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<Field>().HasOptional(t=>t.ParentId).WithMany()

            base.OnModelCreating(modelBuilder);
        }
    }
}