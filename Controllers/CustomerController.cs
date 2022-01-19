using Microsoft.AspNetCore.Mvc;
using WebShop.Models;
using System.Linq;

namespace WebShop.Controllers {
    public class CustomerController : Controller {
        private readonly ShopDBContext dBContext;
        public CustomerController (ShopDBContext dBContext) {
            this.dBContext = dBContext;

        }
        public IActionResult Index () 
        {
            return View(dBContext.Tblcustomers.ToList());
        }
    }
}