using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace WebShop.Models
{
    public partial class Tblpayment
    {
        public string PayId { get; set; }
        public string SaleId { get; set; }
        [DisplayFormat(DataFormatString = "{0:0.##}")]
        public Decimal PayAmount { get; set; }
        public DateTime PayDate { get; set; }
        public string Status { get; set; }
    }
}
