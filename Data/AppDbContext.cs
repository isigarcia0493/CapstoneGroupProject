﻿using CapstoneGroupProject.Models;
using Microsoft.EntityFrameworkCore;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;
using System.Reflection.Emit;
using System;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using CapstoneGroupProject.ViewModels;
using CapstoneGroupProject.ViewModels.Order;

namespace CapstoneGroupProject.Data
{
    public class AppDbContext : IdentityDbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) 
        { 
        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetails> OrderDetails { get; set; }
        public DbSet<Payment> Payments { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Supplier> Suppliers { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<OrderList> OrderLists { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Product>().HasOne(p => p.Category).WithMany(c => c.Product).IsRequired();
            builder.Entity<Order>().HasOne(e => e.Employee).WithMany(e => e.Orders).IsRequired();
        }

        public DbSet<CapstoneGroupProject.ViewModels.Order.OrderViewModel> OrderViewModel { get; set; }
    }
}
