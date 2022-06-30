using ASP.NET_FrontToBack.DAL;
using ASP.NET_FrontToBack.Models;
using ASP.NET_FrontToBack.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASP.NET_FrontToBack.Controllers
{
    public class BasketController : Controller
    {
        private readonly AppDbContext _context;

        public BasketController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }
        public async Task<IActionResult> AddItem(int?id)
        {
            if (id == null) return NotFound();
            
            Product dbProduct = await _context.Products.FindAsync(id);
            if (dbProduct == null) return NotFound();
            List<BasketVM> products;

            if (Request.Cookies["basket"] == null)
            {
               products= new List<BasketVM>();
            }
            else
            {
               products= JsonConvert.DeserializeObject<List<BasketVM>>((Request.Cookies["basket"]));
            }
            BasketVM existProduct = products.Find(x => x.Id == id);
            if (existProduct == null)
            {
                BasketVM basketVM = new BasketVM
                {
                    Id = dbProduct.Id,
                    ProductCount = 1
                };
                products.Add(basketVM);
            }
            else
            {
                existProduct.ProductCount++;
            }

            
            
            

            Response.Cookies.Append("basket", JsonConvert.SerializeObject(products), new CookieOptions { MaxAge = TimeSpan.FromDays(5) });

            return RedirectToAction("index","home");
        }
        public IActionResult ShowItem()
        {
          string basket=  Request.Cookies["basket"];
            List<BasketVM> products;
            if (basket != null)
            {
                products= JsonConvert.DeserializeObject<List<BasketVM>>(basket);
                foreach (var item in products)
                {
                    Product dbProduct = _context.Products.FirstOrDefault(p => p.Id == item.Id);
                    item.Price = dbProduct.Price;
                    item.Name = dbProduct.Name;
                    item.ImageUrl = dbProduct.ImageUrl;
                }

            }
            else
            {
                products = new List<BasketVM>();
            }
            return View(products);
        }

        public IActionResult Remove(int? id)
        {

            List<BasketVM> product;
            string basket = Request.Cookies["basket"];
            product = JsonConvert.DeserializeObject<List<BasketVM>>(basket);

            product.RemoveAll(item => item.Id == id);
            Response.Cookies.Append("basket", JsonConvert.SerializeObject(product), new CookieOptions { MaxAge = TimeSpan.FromDays(14) });
            product = JsonConvert.DeserializeObject<List<BasketVM>>(basket);
            return RedirectToAction("showitem", "basket");
        }
    }
}
