using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using NorthwindEntitiesLib;
using NorthwindContextLib;

namespace NorthwindWeb.Pages
{
    public class CustomersModel : PageModel
    {
        private Northwind db;

        public string[][] Customers;
        public string[] Countrys;

        public CustomersModel(Northwind injectedContext)
        {
            db = injectedContext;
        }

        public void OnGet()
        {
            ViewData["Title"] = "Northwind Web Sitze - Customers";
            Countrys = db.Customers.Select(c => c.Country).ToArray();
            Customers = new string[Countrys.Count()][];
            int i = 0;
            foreach (var country in Countrys)
            {
                var customers = db.Customers.Where(c => c.Country == country).Select(c => c.ContactName);
                Customers[i] = new string[customers.Count()];
                Customers[i++] = customers.ToArray();
            }
        }
        
    }
}