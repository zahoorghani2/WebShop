using System;
using System.Collections.Generic;

#nullable disable

namespace WebShop.Models
{
    public partial class Tblrole
    {
        public Tblrole()
        {
            Tblrolerights = new HashSet<Tblroleright>();
            Tblusers = new HashSet<Tbluser>();
        }

        public string RoleId { get; set; }
        public string RoleName { get; set; }

        public virtual ICollection<Tblroleright> Tblrolerights { get; set; }
        public virtual ICollection<Tbluser> Tblusers { get; set; }
    }
}
