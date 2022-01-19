using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using WebShop.Models;
using WebShop.Models.DashBoard;

namespace WebShop.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ShopDBContext dBContext;

        public HomeController(ILogger<HomeController> logger, ShopDBContext dBContext)
        {
            this.dBContext = dBContext;
            _logger = logger;
        }

        public IActionResult Index()
        {
            DateTime startDateTime = DateTime.Today; //Today at 00:00:00
            DateTime endDateTime = DateTime.Today.AddDays(1).AddTicks(-1);

            int SoldProductCount = dBContext.Tblsales.Count();
            int customerCount = dBContext.Tblcustomers.Count();
            decimal monthlyIncome = dBContext.Tblpayments.Where(x => x.PayDate.Month == DateTime.Now.Month && x.PayDate.Year == DateTime.Now.Year).Sum(x => x.PayAmount);
            decimal TotalIncome = dBContext.Tblpayments.Sum(x => x.PayAmount);
            decimal TodayIncome = dBContext.Tblpayments.Where(x => x.PayDate >= startDateTime && x.PayDate <= endDateTime).Sum(x => x.PayAmount);
            
            var todayPayedCustomersData = (from pay in dBContext.Tblpayments
                                        join sale in dBContext.Tblsales on pay.SaleId equals sale.SaleId
                                        join pro in dBContext.Tblproducts on sale.ProductId equals pro.ProductId
                                        join cus in dBContext.Tblcustomers on sale.CustomerId equals cus.CustomerId
                                        where pay.PayDate >=startDateTime && pay.PayDate <= endDateTime
                                        orderby pay.PayDate descending
                                        select new 
                                        {
                                            pay.PayAmount,
                                            pro.ProductName,
                                            cus.CustomerName,
                                            cus.CustomerAddress
                                        }).ToList();

            List<DashBoard> listDB = new List<DashBoard>();
            
            for(int i=0; i< todayPayedCustomersData.Count(); i++)
            {
                DashBoard dbObj = new DashBoard();
                dbObj.Amount = todayPayedCustomersData[i].PayAmount;
                dbObj.ProductName = todayPayedCustomersData[i].ProductName;
                dbObj.CustomerName = todayPayedCustomersData[i].CustomerName;
                dbObj.Address = todayPayedCustomersData[i].CustomerAddress;

                listDB.Add(dbObj);
            }

            ViewBag.SoldProductCount = SoldProductCount;
            ViewBag.customerCount = customerCount;
            ViewBag.monthlyIncome = monthlyIncome;
            ViewBag.TotalIncome = TotalIncome;
            ViewBag.TodayIncome = TodayIncome;
            return View(listDB);
        }

        public IActionResult Privacy()
        {
            return View();
        }


    }
}
