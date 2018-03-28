using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using NorthwindContextLib;
using NorthwindEntitiesLib;
using System.Linq;

namespace NorthwindWeb.Pages
{
    public class SuppliersModel : PageModel
    {

        private Northwind db;

        [BindProperty]
        public Supplier Supplier { get; set; }

        public SuppliersModel(Northwind injectedContext)
        {
            db = injectedContext;
        }

        public IEnumerable<string> Suppliers { get; set; }

        public void OnGet()
        {
            ViewData["Title"] = "Northwind Web Site - Suppliers";
            Suppliers = db.Suppliers.Select(s => s.CompanyName).ToArray();
        }

        public IActionResult OnPost()
        {
            if(ModelState.IsValid)
            {
                db.Suppliers.Add(Supplier);
                db.SaveChanges();
                return RedirectToPage("/Suppliers");
            }
            return Page();
        }
    }
}