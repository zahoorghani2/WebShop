using System;
using System.Collections.Generic;

#nullable disable

namespace WebShop.Models
{
    public partial class Tblpayment
    {
        public string PayId { get; set; }
        public string SaleId { get; set; }
        public decimal? PayAmount { get; set; }
        public DateTime? PayDate { get; set; }
        public string Status { get; set; }
    }
}
