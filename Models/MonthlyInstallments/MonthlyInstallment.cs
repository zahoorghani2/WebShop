using System;

namespace WebShop.Models.MonthlyInstallments
{
    public class MonthlyInstallment
    {
        public string SaleId { get; set; }
        public string ProductId { get; set; }
        public string CustomerId { get; set; }
        public Decimal TotalAmount { get; set; }
        public Decimal RemainingAmount { get; set; }
        public Decimal Installment { get; set; }
        public Decimal PaidAmount { get; set; }
        public string CustomerName { get; set; }
        public string FatherName { get; set; }
        public string MobilleNo { get; set; }
        public string ProductName { get; set; }

    }
}
