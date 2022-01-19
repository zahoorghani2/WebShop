using System;
using System.Collections.Generic;

#nullable disable

namespace WebShop.Models
{
    public partial class Tblsale
    {
        public string SaleId { get; set; }
        public string ProductId { get; set; }
        public string CustomerId { get; set; }
        public string Imei1 { get; set; }
        public string Imei2 { get; set; }
        public decimal SaleTotalamount { get; set; }
        public decimal SalePaidAmount { get; set; }
        public decimal SaleRemainingamount { get; set; }
        public decimal   SaleMonthlyinstallements { get; set; }
        public string Status { get; set; }
        public DateTime? SaleDate { get; set; }
    }

    public class SaleModel
    {
        public string CustomerName { get; set; }
        public string FatherName { get; set; }
        public string CNIC { get; set; }
        public string MobileNumber { get; set; }
        public string CustomerAddress { get; set; }
        public string CustomerRefference { get; set; }
        public string ProductName { get; set; }
        public string Imei1 { get; set; }
        public string Imei2 { get; set; }
        public string ProductDescription { get; set; }
        public Decimal TotalAmount { get; set; }
        public Decimal MonthlyInstallment { get; set; }
        public Decimal AdvancePayment { get; set; }
    }
}
