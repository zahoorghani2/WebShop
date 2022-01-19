using System;
using System.ComponentModel.DataAnnotations;

namespace WebShop.Models.MonthlyInstallments
{
    public class MonthlyInstallment
    {
        public string SaleId { get; set; }
        public string ProductId { get; set; }
        public string CustomerId { get; set; }
        [DisplayFormat(DataFormatString = "{0:0.##}")]
        public Decimal TotalAmount { get; set; }
        [DisplayFormat(DataFormatString = "{0:0.##}")]
        public Decimal RemainingAmount { get; set; }
        [DisplayFormat(DataFormatString = "{0:0.##}")]
        public Decimal Installment { get; set; }
        [DisplayFormat(DataFormatString = "{0:0.##}")]
        public Decimal TotalPaidAmount { get; set; }
        public string CustomerName { get; set; }
        public string FatherName { get; set; }
        public string MobilleNo { get; set; }
        public string ProductName { get; set; }
        public DateTime PayDate { get; set; }
        [DisplayFormat(DataFormatString = "{0:0.##}")]
        public Decimal PaidAmount { get; set; }

    }
}
