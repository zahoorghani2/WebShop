using System;
using System.Collections.Generic;

#nullable disable

namespace WebShop.Models
{
    public partial class Tblmenuitem
    {
        public Tblmenuitem()
        {
            Tblrolerights = new HashSet<Tblroleright>();
        }

        public string MenuitemId { get; set; }
        public string MenuitemName { get; set; }
        public int? MenuitemNo { get; set; }

        public virtual ICollection<Tblroleright> Tblrolerights { get; set; }
    }
}
