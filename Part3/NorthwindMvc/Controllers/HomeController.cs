using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using NorthwindMvc.Models;
using NorthwindContextLib;
using Microsoft.EntityFrameworkCore;
using NorthwindEntitiesLib;

namespace NorthwindMvc.Controllers
{
    public class HomeController : Controller
    {
        private Northwind _db;

        public HomeController(Northwind db)
        {
            this._db = db;
        }
        public IActionResult Index()
        {
            
            var model = new HomeIndexViewModel
            {
                VisitorCount = 30,
                Categories = _db.Categories.ToList(),
            };
            return View(model);
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

    }
}
