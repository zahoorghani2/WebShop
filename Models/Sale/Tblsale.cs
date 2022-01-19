using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

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
        [DisplayFormat(DataFormatString = "{0:0.##}")]
        public Decimal SaleTotalamount { get; set; }
        [DisplayFormat(DataFormatString = "{0:0.##}")]
        public Decimal SalePaidAmount { get; set; }
        [DisplayFormat(DataFormatString = "{0:0.##}")]
        public Decimal SaleRemainingamount { get; set; }
        [DisplayFormat(DataFormatString = "{0:0.##}")]
        public Decimal SaleMonthlyinstallements { get; set; }
        public string Status { get; set; }
        public DateTime SaleDate { get; set; }
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
        [DisplayFormat(DataFormatString = "{0:0.##}")]
        public Decimal TotalAmount { get; set; }
        [DisplayFormat(DataFormatString = "{0:0.##}")]
        public Decimal MonthlyInstallment { get; set; }
        [DisplayFormat(DataFormatString = "{0:0.##}")]
        public Decimal AdvancePayment { get; set; }
    }
}
