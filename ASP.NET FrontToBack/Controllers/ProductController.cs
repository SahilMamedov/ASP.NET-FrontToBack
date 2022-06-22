using ASP.NET_FrontToBack.DAL;
using ASP.NET_FrontToBack.Models;
using ASP.NET_FrontToBack.ViewModels;
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
            ViewBag.ProductCount = _context.Products.Count();
            return View(products);
        }
        
        public IActionResult LoadMore(int skip)
        {
            #region Json
            //List<Product> products = _context.Products.Skip(2).Take(2).ToList();
            //List<ProductReturnVM> products = _context.Products.Select(p => new ProductReturnVM
            //{
            //    Id=p.Id,
            //    Name=p.Name,
            //    Price=p.Price,
            //    Category=p.Category.Name,
            //    ImageUrl=p.ImageUrl
            //}).ToList();
            #endregion
           
            List<Product> products = _context.Products.Include(p=>p.Category).Skip(skip).Take(2).ToList();
            
            return PartialView("_LoadMorePartial",products);
        }

    }
}
