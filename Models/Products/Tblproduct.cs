using System;
using System.Collections.Generic;

#nullable disable

namespace WebShop.Models
{
    public partial class Tblproduct
    {
        public string ProductId { get; set; }
        public string ProductName { get; set; }
        public string ProductDesc { get; set; }
        public DateTime? ProductCreationdate { get; set; }
    }
}
