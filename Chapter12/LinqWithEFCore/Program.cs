using System;
using System.Linq;
using System.Xml.Linq;
using System.Xml;

namespace LinqWithEFCore
{
    public class Program
    {
        static void Main(string[] args)
        {
            using(var db = new Northwind()){
                var querry = db.Products
                .Where(product => product.UnitPrice < 10M)
                .OrderByDescending(product => product.UnitPrice)
                .Select(product => new {
                   product.ProductID,
                   product.ProductName,
                   product.UnitPrice 
                });

                Console.WriteLine("Products that cost less than $10: ");
                foreach(var item in querry){
                    Console.WriteLine($"{item.ProductID}: {item.ProductName} cost {item.UnitPrice:$#,##0.00}");
                
                var categories = db.Categories.Select(c => new{
                    c.CategoryID,
                    c.CategoryName
                }).ToArray();
                
                var products = db.Products.Select(p => new{
                    p.ProductID,
                    p.ProductName,
                    p.CategoryID
                }).ToArray();


                var querryJoin = categories.Join(products
                    ,cat => cat.CategoryID
                    ,pr => pr.CategoryID
                    ,(c, p) => new {
                        c.CategoryName,
                        p.ProductID,
                        p.ProductName
                    }).OrderBy(p => p.ProductID);     
                
                foreach(var i in querryJoin){
                    Console.WriteLine($"{i.ProductID}: {i.ProductName} is in {i.CategoryName}");
                }
                
                var querryGroup = categories.GroupJoin(products
                ,cat => cat.CategoryID
                ,pr => pr.CategoryID
                ,(c, Products) => new{
                    c.CategoryName,
                    Products = Products.OrderBy(p => p.ProductName)
                });

                Console.WriteLine("Group Join:");

                foreach(var x in querryGroup){
                    Console.WriteLine($"{x.CategoryName} has {x.Products.Count()} products.");

                    foreach (var p in x.Products)
                    {
                        Console.WriteLine($" {p.ProductName}");
                    }
                }

                Console.WriteLine("Products:");
                Console.WriteLine($"Count: {db.Products.Count()}");
                Console.WriteLine($"Sum of units in stock: {db.Products.Sum(p => p.UnitsInStock):NO}");
                Console.WriteLine($"SUm of units in order: {db.Products.Sum(p => p.UnitsOnOrder):NO}");
                Console.WriteLine($"Average Unit Price: {db.Products.Average(p => p.UnitPrice):N0}");
                Console.WriteLine($"Value of units in stock: {db.Products.Sum(p => p.UnitPrice * p.UnitsInStock):$#,##0.00}");
                
                var productsForXml = db.Products.ToArray();

                var xml = new XElement("products", from p in productsForXml
                select new XElement("product", 
                                     new XAttribute("id", p.ProductID)
                                    ,new XAttribute("price", p.UnitPrice)
                                    ,new XElement("name", p.ProductName)
                                    ));


                Console.WriteLine(xml.ToString());


                XDocument doc = XDocument.Load("settings.xml");

                var appSetting = doc.Descendants("appSettings").Descendants("add")
                .Where(p => p.Attribute("key").Value == "color")
                .Select(node => new {
                    Key = node.Attribute("key").Value,
                    Value = node.Attribute("value").Value
                }).ToArray();

                foreach(var el in appSetting){
                    Console.WriteLine($"{el.Key}: {el.Value}");
                }
                }
            }
        }
    }
}
