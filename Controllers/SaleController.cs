using System;
using Microsoft.AspNetCore.Mvc;
using WebShop.Models;

namespace WebShop.Controllers
{
    public class SaleController : Controller
    {
        private readonly ShopDBContext dBContext;
        public SaleController(ShopDBContext dBContext)
        {
            this.dBContext = dBContext;

        }
        public IActionResult Sale()
        {
            return View();
        }

        public IActionResult CreateSale(SaleModel saleModel)
        {
            if (ModelState.IsValid)
            {
                string getDate = DateTime.Now.ToString("yyyy/MM/dd");
                string customerID = Guid.NewGuid().ToString();
                Tblcustomer customer = new Tblcustomer();
                customer.CustomerId = customerID;
                customer.CustomerName = saleModel.CustomerName;
                customer.CustomerFathername = saleModel.FatherName;
                customer.CustomerCnic = saleModel.CNIC;
                customer.CustomerMobileno = saleModel.MobileNumber;
                customer.CustomerAddress = saleModel.CustomerAddress;
                customer.CustomerReference = saleModel.CustomerRefference;
                customer.CustomerCreationdate = Convert.ToDateTime(getDate);

                string productID = Guid.NewGuid().ToString();
                Tblproduct product = new Tblproduct();
                product.ProductId = productID;
                product.ProductName = saleModel.ProductName;
                product.ProductDesc = saleModel.ProductDescription;
                product.ProductCreationdate = Convert.ToDateTime(getDate);

                string saleID = Guid.NewGuid().ToString();
                Tblsale sale = new Tblsale();
                sale.SaleId = saleID;
                sale.CustomerId = customerID;
                sale.Imei1 = saleModel.Imei1;
                sale.Imei2 = saleModel.Imei2;
                sale.ProductId = productID;
                sale.SaleTotalamount = saleModel.TotalAmount;
                sale.SalePaidAmount = saleModel.AdvancePayment;
                sale.SaleRemainingamount = saleModel.TotalAmount - saleModel.AdvancePayment;
                sale.Status = "Active";
                sale.SaleMonthlyinstallements = saleModel.MonthlyInstallment;
                sale.SaleDate = Convert.ToDateTime(getDate);
                

                string PaymentID = Guid.NewGuid().ToString();
                Tblpayment payment = new Tblpayment();
                payment.PayId = PaymentID;
                payment.SaleId = saleID;
                payment.PayAmount = saleModel.AdvancePayment;
                payment.Status = "ap";
                payment.PayDate = Convert.ToDateTime(getDate);

                dBContext.Add(customer);
                dBContext.SaveChanges();
                

                dBContext.Add(product);
                dBContext.SaveChanges();

                dBContext.Add(sale);
                dBContext.SaveChanges();

                dBContext.Add(payment);
                dBContext.SaveChanges();

            }
            return RedirectToAction("Index" , "MonthlyInstallment");
        }
    }
}