using Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Infrastructure.Context.ShopAppDbContext;
using Domain.Model;
using Application.Interfaces;

namespace Infrastructure.Context
{

    public class ShopAppDbContext : DbContext, IShopAppDbContext
    {
        public DbSet<Products> Products { get; set; }
        public DbSet<Orders> Orders { get; set; }
        public DbSet<Customers> Customers { get; set; }
        public DbSet<Address> Address { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var builder = new NpgsqlDataSourceBuilder("Server=localhost;Port=5432;Database=ShopApp;Userid=postgres;Password=123456;Include Error Detail=True;");
            builder.EnableDynamicJson();
            var dataSource = builder.Build();
            optionsBuilder.UseNpgsql(dataSource);
            base.OnConfiguring(optionsBuilder);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ProductConfiguration).Assembly);
            base.OnModelCreating(modelBuilder);
        }
    }

}
