using ASP.NET_FrontToBack.DAL;
using ASP.NET_FrontToBack.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASP.NET_FrontToBack.ViewComponents
{
    public class HeaderViewComponent: ViewComponent
    {
       
            private readonly AppDbContext _context;

            public HeaderViewComponent(AppDbContext context)
            {
                _context = context;
            }
            public async Task<IViewComponentResult> InvokeAsync()
            {
                Bio bio = _context.Bio.FirstOrDefault();
                return View(await Task.FromResult(bio));

            }
        
    }
}
