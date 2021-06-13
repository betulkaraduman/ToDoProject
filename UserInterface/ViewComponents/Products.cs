using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UserInterface.Models;

namespace UserInterface.ViewComponents
{
    public class Products:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View(new List<CustomerViewModel>()
            {
                new CustomerViewModel(){Name="Ali"},
                new CustomerViewModel(){Name="Elif"},
                new CustomerViewModel(){Name="Burak"},
                new CustomerViewModel(){Name="Deniz"}
            });
        }
    }
}
