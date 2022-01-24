using Microsoft.AspNetCore.Mvc;
using WebShop.Models;
using System.Linq;
using WebShop.Models.MonthlyInstallments;
using System.Collections.Generic;
using System;

namespace WebShop.Controllers
{
    public class MonthlyInstallmentController : Controller
    {
        private readonly ShopDBContext dBContext;
        public MonthlyInstallmentController(ShopDBContext dBContext)
        {
            this.dBContext = dBContext;
        }


        public IActionResult Index()
        {
            var getInstallmentData = (from sale in dBContext.Tblsales
                        join cus in dBContext.Tblcustomers on sale.CustomerId equals cus.CustomerId
                        join pro in dBContext.Tblproducts on sale.ProductId equals pro.ProductId
                        orderby sale.SaleDate
                        where sale.Status.ToLower() == "active"
                        orderby sale.SaleDate descending
                        select new 
                        { 

                            sale.SaleId,
                            sale.ProductId,
                            sale.CustomerId,
                            sale.SaleTotalamount,
                            sale.SaleRemainingamount,
                            sale.SaleMonthlyinstallements,
                            sale.SalePaidAmount,
                            cus.CustomerName,
                            cus.CustomerFathername,
                            cus.CustomerMobileno,
                            pro.ProductName
                        }).ToList(); 

            List<MonthlyInstallment> mi = new List<MonthlyInstallment>();

            for(int i=0; i< getInstallmentData.Count(); i++)
            {
                MonthlyInstallment miobj = new MonthlyInstallment();

                miobj.SaleId            = getInstallmentData[i].SaleId;
                miobj.ProductId         = getInstallmentData[i].ProductId;
                miobj.CustomerId        = getInstallmentData[i].CustomerId;
                miobj.TotalAmount       = getInstallmentData[i].SaleTotalamount;
                miobj.RemainingAmount   = getInstallmentData[i].SaleRemainingamount;
                miobj.Installment       = getInstallmentData[i].SaleMonthlyinstallements;
                miobj.TotalPaidAmount   = getInstallmentData[i].SalePaidAmount;
                miobj.CustomerName      = getInstallmentData[i].CustomerName;
                miobj.FatherName        = getInstallmentData[i].CustomerFathername;
                miobj.MobilleNo         = getInstallmentData[i].CustomerMobileno;
                miobj.ProductName       = getInstallmentData[i].ProductName;

                mi.Add(miobj);
            }

            return View(mi);
        }

        public IActionResult PayInstallment(string saleId)
        {
            var getSaleDetails = (from sale in dBContext.Tblsales
                        join cus in dBContext.Tblcustomers on sale.CustomerId equals cus.CustomerId
                        join pro in dBContext.Tblproducts on sale.ProductId equals pro.ProductId
                        orderby sale.SaleDate
                        where sale.Status.ToLower() == "active"
                        where sale.SaleId == saleId
                        select new 
                        {
                            sale.SaleId,
                            sale.ProductId,
                            sale.CustomerId,
                            cus.CustomerName,
                            cus.CustomerFathername,
                            cus.CustomerMobileno,
                            pro.ProductName
                        }).FirstOrDefault(); 

            

           
                MonthlyInstallment miobj = new MonthlyInstallment();
                miobj.SaleId        = getSaleDetails.SaleId;
                miobj.ProductId     = getSaleDetails.ProductId;
                miobj.CustomerId    = getSaleDetails.CustomerId;
                miobj.CustomerName  = getSaleDetails.CustomerName;
                miobj.FatherName    = getSaleDetails.CustomerFathername;
                miobj.MobilleNo     = getSaleDetails.CustomerMobileno;
                miobj.ProductName   = getSaleDetails.ProductName;

            return View(miobj);
        }


        public IActionResult ConfirmInstallment(MonthlyInstallment mimodel)
        {
            Tblsale getSaleData = dBContext.Tblsales.Where(x => x.SaleId == mimodel.SaleId).FirstOrDefault();

            decimal totalPayedAmount = getSaleData.SalePaidAmount += mimodel.PaidAmount;
            decimal totalRemainingAmount = getSaleData.SaleRemainingamount -= mimodel.PaidAmount;

            if(totalPayedAmount == getSaleData.SaleTotalamount)
            {
                getSaleData.Status = "Sold";
            }

            string PaymentID = Guid.NewGuid().ToString();
            Tblpayment payment = new Tblpayment();
            payment.PayId = PaymentID;
            payment.SaleId = mimodel.SaleId;
            payment.PayAmount = mimodel.PaidAmount;
            payment.Status = "mp";
            payment.PayDate = mimodel.PayDate + DateTime.Now.TimeOfDay;


            dBContext.Tblsales.Update(getSaleData);
            // dBContext.SaveChanges();

            dBContext.Add(payment);
            dBContext.SaveChanges();

            return RedirectToAction("Index" , "MonthlyInstallment");
        }

        public IActionResult EditInstallment(ViewRecord item)
        {
            // return Json(item);
            return View(item);
        }

        public IActionResult UpdateInstallment(string payid , DateTime updatedPaydate , Decimal updatedamount)
        {
            Tblpayment getPaymentData = dBContext.Tblpayments.Where(x => x.PayId == payid).FirstOrDefault();


            Tblsale getSaleData = dBContext.Tblsales.Where(x => x.SaleId == getPaymentData.SaleId).FirstOrDefault();

            if(getPaymentData.PayAmount == updatedamount)
            {
                return Json("Same Amount");
            }
            if ((getSaleData.SaleRemainingamount + getPaymentData.PayAmount) < updatedamount )
            {
                return Json("Amount is greater than remaining amount");
            }
            else
            {
                getSaleData.SalePaidAmount = (getSaleData.SalePaidAmount - getPaymentData.PayAmount) + updatedamount;
                getSaleData.SaleRemainingamount = (getSaleData.SaleRemainingamount + getPaymentData.PayAmount) - updatedamount;

                dBContext.Tblsales.Update(getSaleData);

                getPaymentData.PayAmount = updatedamount;
                getPaymentData.PayDate = updatedPaydate;

                dBContext.Tblpayments.Update(getPaymentData);

                dBContext.SaveChanges();
            }

            
            return Json(new {payid , updatedamount , updatedPaydate , getSaleData.SalePaidAmount , getSaleData.SaleRemainingamount});
            
            return RedirectToAction();
        }
    }
}