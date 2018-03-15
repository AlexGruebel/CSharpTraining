using System;
using Packt.CS7;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore.Storage;

namespace WorkingWithEFCore
{
    class Program
    {
        static void Main(string[] args)
        {
            //QueryingProducts();
            //QueryingWithLike();
            //QuerryCategories();
            
            Product product = new Product{
                CategoryID = 1,
                ProductName = "Tuxedo Laptop",
                Cost = 900
            };
            
            AddProduct(product);
            ListProducts();
            product.Cost = 950;
            Console.WriteLine($"\nUpdate Product {product.ProductID} {product.ProductName}\n");
            UpdateProduct(product);
            ListProducts();
            Console.WriteLine($"\nDelete Product {product.ProductID} {product.ProductName}\n");
            DeleteProduct(product.ProductName);
            ListProducts();
        }

        static void QuerryCategories()
        {
            using(var db = new Northwind()){
                Console.WriteLine("Categoires and how many products they have:");
                
                var loggerFactory = db.GetService<ILoggerFactory>();
                loggerFactory.AddProvider(new ConsoleLoggerProvider());

                IQueryable<Category> cats;// = db.Categories.Include(c => c.Products);

                Console.Write("(1) eager loading, (2) explecit loading: ");
                bool eagerLoading = (Console.ReadKey().KeyChar == '1');
                Console.WriteLine();
                if(eagerLoading){
                    cats = db.Categories.Include(c => c.Products);

                    foreach(var c in cats){
                        Console.WriteLine($"{c.CategoryName} has {c.Products.Count} products");
                    }
                }else{
                    cats = db.Categories;
                    foreach(var c in cats){
                        Console.WriteLine($"Explecit load products for {c.CategoryName}? (Y/N)");
                        if(Console.ReadKey().Key == ConsoleKey.Y){
                            var products = db.Entry(c).Collection(c2 => c2.Products);
                            if(!products.IsLoaded) products.Load();
                            Console.WriteLine();
                        }
                        Console.WriteLine($"{c.CategoryName} has {c.Products.Count} products");
                    }
                }
            }
        }

        static void QueryingProducts(){
            using(var db = new Northwind()){
                Console.Write("Products thats cost mehr as that price sorted: ");
                var loggerFactory = db.GetService<ILoggerFactory>();
                loggerFactory.AddProvider(new ConsoleLoggerProvider());
                decimal price = Convert.ToDecimal(Console.Read());
                IQueryable<Product> products = db.Products.Where(product => product.Cost > price).OrderByDescending(product => product.Cost);
                foreach(var p in products){
                    Console.WriteLine($"{p.ProductID, -3} {p.ProductName, -35} {p.Cost:# €,##0.00}");
                }
            }
        }

        static void QueryingWithLike(){
            using(var db = new Northwind()){
                var loggerFactory = db.GetService<ILoggerFactory>();
                loggerFactory.AddProvider(new ConsoleLoggerProvider());
                Console.Write("Enter a part of the productname: ");
                string productName = Console.ReadLine();
                IQueryable<Product> products = db.Products.Where(p => EF.Functions.Like(p.ProductName, $"%{productName}%"));
            
                foreach(var p in products){
                    Console.WriteLine($"{p.ProductID, -3} {p.ProductName, -35}");
                }
            }
        }

        static bool AddProduct(Product product){
            using(var db = new Northwind()){
                db.Add(product);
                return (db.SaveChanges() == 1);
            }
        }

        static void ListProducts(){
            using(var db = new Northwind()){
                IQueryable<Product> products = db.Products.OrderByDescending(p => p.Cost).Take(10);
                Console.WriteLine("ID | Name                               | Cost ");
                Console.WriteLine("-----------------------------------------------");
                foreach(var p in products){
                    Console.WriteLine($"{p.ProductID,-3}| {p.ProductName, -35}| {p.Cost:C}");
                }
            }
        }

        static bool UpdateProduct(Product product){
            using(var db = new Northwind()){
                db.Update(product);
                return (db.SaveChanges() == 1);
            }
        }

        static bool DeleteProduct(Product product){
            using(var db = new Northwind()){
                db.Remove(product);
                return (db.SaveChanges() == 1);
            }
        }


        //Delete Range
        static bool DeleteProduct(string name){
            using(var db = new Northwind()){
                using(IDbContextTransaction t = db.Database.BeginTransaction()){
                    Console.WriteLine($"Transaktion startet with level {t.GetDbTransaction().IsolationLevel}");
                    IQueryable<Product> products = db.Products.Where(p => p.ProductName == name);
                    db.RemoveRange(products);
                    int i = db.SaveChanges();
                    Console.Write("Do you want to Commit the Changes (y/n): ");
                    if(Console.ReadKey().Key == ConsoleKey.Y){
                        t.Commit();
                    }else{
                        t.Rollback();
                    }
                    Console.WriteLine();
                    return (i == 1);
                }
            }
        }
    }
}