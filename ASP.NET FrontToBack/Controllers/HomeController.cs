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
    public class HomeController : Controller
    {
        private readonly AppDbContext _context;
        public HomeController(AppDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        { 
            HomeVM homeVM = new HomeVM();
            homeVM.Sliders= _context.Sliders.ToList();
            homeVM.SliderContent = _context.SliderContents.FirstOrDefault();
            homeVM.Categories = _context.Categories.ToList();
            homeVM.Products = _context.Products.ToList();
            return View(homeVM);
        }

        public IActionResult SearchProduct(string search)
        {
            List<Product> products = _context.Products.Include(p => p.Category)
                .OrderBy(p => p.Id)
                .Where(p => p.Name.ToLower()
                .Contains(search.ToLower()))
                .ToList();
            return PartialView("_SearchPartial", products);
        }
    }
}
