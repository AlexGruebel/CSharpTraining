using Microsoft.EntityFrameworkCore;
namespace LinqWithEFCore{
    public class Northwind : DbContext{
        public DbSet<Category> Categories {get;set;}
        public DbSet<Product> Products {get;set;}

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(
             @"Data Source=127.0.0.1,1401;"
            + "Initial Catalog=Northwind;"
            + "Integrated Security=False; "
            + "User ID = enityService;"
            + "Password=340$Uuxwp7Mcxo7Khy;"
            );
        }
    }
}