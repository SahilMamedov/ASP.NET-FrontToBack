using ASP.NET_FrontToBack.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASP.NET_FrontToBack.ViewModels
{
    public class HomeVM
    {
      public  List<Slider> Sliders{ get; set; }
        public SliderContent SliderContent { get; set; }
    }
}
