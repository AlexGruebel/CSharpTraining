using Microsoft.EntityFrameworkCore;


namespace Exercies02
{
    public class Northwind : DbContext
    {
        public DbSet<Customer> Customers { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(
             @"Data Source=192.168.178.28,1401;"
            + "Initial Catalog=Northwind;"
            + "Integrated Security=False; "
            + "User ID = enityService;"
            + "Password=340$Uuxwp7Mcxo7Khy;"
            );
        }
    }
}
