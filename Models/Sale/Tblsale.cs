using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;

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

    public class ImportSaleModel
    {
        public IFormFile file { get; set; } 
    }

    public class CustomerImportModel 
    {
        public string CustomerName { get; set; }
        public string FathName { get; set; }
        public string CNIC { get; set; }
        public string MobileNumber { get; set; }
        public string CustomerAddress { get; set; }
        public string CustomerReference { get; set; }
    }

    public class ProductImportModel 
    {
        public string ProductName { get; set; }
        public string IMEI1 { get; set; }
        public string IMEI2 { get; set; }
        public string Description { get; set; }
    }

    public class SaleImportModel    
    {
        public decimal ProductPrice { get; set; }
        public decimal MonthlyInstallments { get; set; }
        public decimal AdvancePayment { get; set; }
    }
}
