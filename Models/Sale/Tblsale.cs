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
        public decimal? SaleTotalamount { get; set; }
        public decimal? SaleRemainingamount { get; set; }
        public decimal? SaleMonthlyinstallements { get; set; }
        public string Status { get; set; }
    }
}
