using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

using NorthwindContextLib;
using NorthwindMvc.Models;

namespace NorthwindMvc.Controllers{
    public class ProductController : Controller
    {
        private Northwind _db;
        private ProductsViewModel _model;

        public ProductController(Northwind db){
            _db = db;
        }

        public async Task<IActionResult> Products(){
            _model = new ProductsViewModel();
            _model.Categories = await _db.Categories.Include(c => c.Products).ToListAsync();
            return View(_model);
        }

        public async Task<IActionResult> ProductDetails(int? id)
        {
            if(!id.HasValue){
                return NotFound("You must pass a product ID");
            }

            var Product = await _db.Products.Include(p => p.Category).Include(p => p.Supplier).Where(p => p.ProductID == id).SingleOrDefaultAsync();
            if(Product == null)
            {
                return NotFound($"Product with the id {id} was not found");
            }
            return View(Product);
        }

        public async Task<IActionResult> CategoryDetails(int? id)
        {
            if(!id.HasValue)
            {
                return NotFound("You must pass a Category ID!");
            }

            var Category = await _db.Categories.Include(c => c.Products).Where(c => c.CategoryID == id).FirstOrDefaultAsync();
            if(Category == null)
            {
                return NotFound($"Category with the id {id} was not found");
            }
            return View(Category);
        }
    }
}