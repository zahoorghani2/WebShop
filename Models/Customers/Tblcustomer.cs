using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace WebShop.Models
{
    public partial class Tblcustomer
    {
        public string CustomerId { get; set; }
        public string CustomerName { get; set; }
        public string CustomerFathername { get; set; }
        public string CustomerCnic { get; set; }
        public string CustomerMobileno { get; set; }
        public string CustomerAddress { get; set; }
        public string CustomerReference { get; set; }
        public DateTime? CustomerCreationdate { get; set; }
    }


    public class CustomerWithMobileData
    {
        public string CustomerName  { get; set; }
        public string CustomerAddress { get; set; }
        public string CustomerFatherName { get; set; }
        public string CustomerCNIC { get; set; }
        public string CustomerMobileNumber { get; set; }
        public string CustomerRefferrence { get; set; }
        public string ProductName { get; set; }
        public string ProductId { get; set; }
        public string SaleStatus { get; set; }
        public DateTime SaleDate { get; set; }
        public string SaleId { get; set; }
    }


    public class ViewRecord
    {
        public string SaleId { get; set; }
        public DateTime PaymentDate { get; set; }
        [DisplayFormat(DataFormatString = "{0:0.##}")]
        public Decimal Amount { get; set; }
        public string Status { get; set; }
        public string PayId { get; set; }
    }
}
