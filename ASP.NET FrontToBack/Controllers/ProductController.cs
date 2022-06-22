using ASP.NET_FrontToBack.DAL;
using ASP.NET_FrontToBack.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASP.NET_FrontToBack.Controllers
{
    public class ProductController : Controller
    {
        private readonly AppDbContext _context;

        public ProductController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            List<Product> products = _context.Products.Take(2).Include(p=>p.Category).ToList();
            return View(products);
        }
        
        public IActionResult LoadMore()
        {
            List<Product> products = _context.Products.Skip(2).Take(2).ToList();
            return Json(products);
        }

    }
}
