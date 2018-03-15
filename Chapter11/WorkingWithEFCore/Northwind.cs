using Microsoft.EntityFrameworkCore;

namespace Packt.CS7{
    public class Northwind : DbContext{
        //Diese Propertys mappen die Tabellen in die Datenbank
        public DbSet<Category> Categories {get;set;}
        public DbSet<Product> Products {get;set;}

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(
                @"Data Source=127.0.0.1,1401;" +
                "Initial Catalog=Northwind;" +
                "Integrated Security=false;" +
                "User ID=enityService;" +
                "Password=340$Uuxwp7Mcxo7Khy;" 
            );
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Beispeil Fluent API
            //To Do Fluent API genauer anschauen!
            modelBuilder.Entity<Category>()
            .Property(category => category.CategoryName)
            .IsRequired()
            .HasMaxLength(40);

            //globaler Filter 
            modelBuilder.Entity<Product>().HasQueryFilter(p => !p.Discontinued);
        }
    }
}