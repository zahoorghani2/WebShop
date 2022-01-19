using Microsoft.AspNetCore.Mvc;
using WebShop.Models;
using System.Linq;
using System.Collections.Generic;

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

        public IActionResult Profile(string CustomerId)
        {
            Tblcustomer custdata = dBContext.Tblcustomers.Where(x => x.CustomerId == CustomerId).FirstOrDefault();

            var CustomerDetails = (from cus in dBContext.Tblcustomers
                                        join sale in dBContext.Tblsales on cus.CustomerId equals sale.CustomerId
                                        join pro in dBContext.Tblproducts on sale.ProductId equals pro.ProductId
                                        where cus.CustomerId ==  CustomerId
                                        orderby sale.SaleDate descending
                                        select new 
                                        {
                                            pro.ProductName,
                                            pro.ProductId,
                                            sale.SaleId,
                                            sale.Status,
                                            sale.SaleDate
                                        }).ToList();
            

            List<CustomerWithMobileData> customerList = new List<CustomerWithMobileData>();
            for(int i=0; i<CustomerDetails.Count(); i++)
            {
                CustomerWithMobileData cusObj = new CustomerWithMobileData();
                cusObj.ProductName  = CustomerDetails[i].ProductName;
                cusObj.ProductId    = CustomerDetails[i].ProductId;
                cusObj.SaleStatus   = CustomerDetails[i].Status;
                cusObj.SaleDate     = CustomerDetails[i].SaleDate;
                cusObj.SaleId       = CustomerDetails[i].SaleId;

                customerList.Add(cusObj);
            }
            ViewBag.CutomerName         = custdata.CustomerName;
            ViewBag.CustomerAddress     = custdata.CustomerAddress;
            ViewBag.CustomerCnic        = custdata.CustomerCnic;
            ViewBag.CustomerFathername  = custdata.CustomerFathername;
            ViewBag.CustomerMobileno    = custdata.CustomerMobileno;
            ViewBag.CustomerReference   = custdata.CustomerReference;

            return View(customerList);
        }

        public IActionResult ViewRecord(string saleId)
        {
            var PaymentRecord = (from sale in dBContext.Tblsales
                                        join pay in dBContext.Tblpayments on sale.SaleId equals pay.SaleId
                                        where sale.SaleId == saleId
                                        orderby pay.PayDate descending
                                        select new 
                                        {
                                            sale.SaleId,
                                            pay.PayDate,
                                            pay.PayAmount,
                                            pay.Status
                                        }).ToList();

            List<ViewRecord> recList = new List<ViewRecord>();
            for(int i=0; i< PaymentRecord.Count(); i++)
            {
                ViewRecord obj = new ViewRecord();

                obj.SaleId = PaymentRecord[i].SaleId;
                obj.PaymentDate = PaymentRecord[i].PayDate;
                obj.Amount = PaymentRecord[i].PayAmount;
                obj.Status = PaymentRecord[i].Status;

                recList.Add(obj);
            }
            return View(recList);
        }
    }
}