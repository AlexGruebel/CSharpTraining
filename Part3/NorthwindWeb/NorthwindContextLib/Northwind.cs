using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using NorthwindEntitiesLib;

namespace NorthwindContextLib
{
    public class Northwind : DbContext
    {
        public Northwind(DbContextOptions options) : base(options)
        {

        }

        DbSet<Category> Categories { get; set; }
        DbSet<Customer> Customers { get; set; }
        DbSet<Employee> Employees { get; set; }
        DbSet<Order> Orders { get; set; }
        DbSet<OrderDetail> OrderDetails { get; set; }
        DbSet<Product> Products { get; set; }
        DbSet<Shipper> Shippers { get; set; }
        DbSet<Supplier> Suppliers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //Category Begin

            modelBuilder.Entity<Category>()
                .Property(c => c.CategoryName)
                .IsRequired()
                .HasMaxLength(15);

            modelBuilder.Entity<Category>()
                .HasMany(c => c.Products)
                .WithOne(p => p.Category);

            //Category End

            //Customer Begin

            modelBuilder.Entity<Customer>()
                .Property(c => c.CompanyName)
                .IsRequired()
                .HasMaxLength(40);

            modelBuilder.Entity<Customer>()
                .Property(c => c.ContactName)
                .HasMaxLength(30);

            modelBuilder.Entity<Customer>()
                .Property(c => c.ContactTitle)
                .HasMaxLength(30);

            modelBuilder.Entity<Customer>()
                .Property(c => c.Adress)
                .HasMaxLength(60);

            modelBuilder.Entity<Customer>()
                .Property(c => c.City)
                .HasMaxLength(15);

            modelBuilder.Entity<Customer>()
                .Property(c => c.Region)
                .HasMaxLength(15);

            modelBuilder.Entity<Customer>()
                .Property(c => c.PostalCode)
                .HasMaxLength(10);

            modelBuilder.Entity<Customer>()
                .Property(c => c.Country)
                .HasMaxLength(15);

            modelBuilder.Entity<Customer>()
                .Property(c => c.Phone)
                .HasMaxLength(24);

            modelBuilder.Entity<Customer>()
                .Property(c => c.Fax)
                .HasMaxLength(25);

            modelBuilder.Entity<Customer>()
                .HasMany(c => c.Orders)
                .WithOne(o => o.Customer);

            //Customer End

            //Employee Begin

            modelBuilder.Entity<Employee>()
                .Property(e => e.LastName)
                .IsRequired()
                .HasMaxLength(20);

            modelBuilder.Entity<Employee>()
                .Property(e => e.FirstName)
                .IsRequired()
                .HasMaxLength(10);

            modelBuilder.Entity<Employee>()
                .Property(e => e.Title)
                .HasMaxLength(30);

            modelBuilder.Entity<Employee>()
                .Property(e => e.TitleOfCourtesy)
                .HasMaxLength(25);

            modelBuilder.Entity<Employee>()
                .Property(e => e.Address)
                .HasMaxLength(60);

            modelBuilder.Entity<Employee>()
                .Property(e => e.City)
                .HasMaxLength(15);

            modelBuilder.Entity<Employee>()
                .Property(e => e.Region)
                .HasMaxLength(15);

            modelBuilder.Entity<Employee>()
                .Property(e => e.PostalCode)
                .HasMaxLength(10);

            modelBuilder.Entity<Employee>()
                .Property(e => e.Country)
                .HasMaxLength(15);

            modelBuilder.Entity<Employee>()
                .Property(e => e.HomePhone)
                .HasMaxLength(24);

            modelBuilder.Entity<Employee>()
                .Property(e => e.Extension)
                .HasMaxLength(4);

            modelBuilder.Entity<Employee>()
                .Property(e => e.Notes)
                .HasField("ntext");

            modelBuilder.Entity<Employee>()
                .HasMany(e => e.Orders)
                .WithOne(o => o.Employee);

            //Employee End

            //Order Begin

            modelBuilder.Entity<Order>()
                .HasOne(o => o.Customer)
                .WithMany(c => c.Orders);

            modelBuilder.Entity<Order>()
                .HasOne(o => o.Employee)
                .WithMany(e => e.Orders);

            //Order End

            //Order Details Begin

            modelBuilder.Entity<OrderDetail>()
                .ToTable("Order Details");

            modelBuilder.Entity<OrderDetail>()
                .HasKey(od => new { od.OrderID, od.ProductID });

            //Order Details

            //Products Begin

            modelBuilder.Entity<Product>()
                .Property(p => p.ProductName)
                .IsRequired()
                .HasMaxLength(40);

            modelBuilder.Entity<Product>()
                .Property(p => p.Discontinued)
                .IsRequired();

            modelBuilder.Entity<Product>()
                .HasOne(p => p.Supplier)
                .WithMany(s => s.Products);

            modelBuilder.Entity<Product>()
                .HasOne(p => p.Category)
                .WithMany(c => c.Products);

            //Products End


            //Supplier Begin

            modelBuilder.Entity<Supplier>()
                .HasMany(s => s.Products)
                .WithOne(p => p.Supplier);
        }
    }
}
