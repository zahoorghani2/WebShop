using System;
using System.ComponentModel.DataAnnotations;

namespace WebShop.Models.DashBoard
{
    public class DashBoard
    {
        public string CustomerName { get; set; }
        public string ProductName { get; set; }
        public string Address { get; set; }
        [DisplayFormat(DataFormatString = "{0:0.##}")]
        public Decimal Amount { get; set; }
        
    }
}