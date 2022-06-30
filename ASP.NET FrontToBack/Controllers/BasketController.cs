using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASP.NET_FrontToBack.Controllers
{
    public class BasketController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult AddItem()
        {
            HttpContext.Session.SetString("name", "Sahil");
            return Content("");
        }
        public IActionResult ShowItem()
        {
           string name= HttpContext.Session.GetString("name");
            return Content(name);
        }
    }
}
