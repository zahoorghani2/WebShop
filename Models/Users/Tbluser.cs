using System;
using System.Collections.Generic;

#nullable disable

namespace WebShop.Models
{
    public partial class Tbluser
    {
        public string UsersId { get; set; }
        public string RoleIdFk { get; set; }
        public string UserFirstname { get; set; }
        public string UserLastname { get; set; }
        public string UserUsername { get; set; }
        public string UserEmail { get; set; }
        public string UserPassword { get; set; }
        public string UserPhoto { get; set; }

        public virtual Tblrole RoleIdFkNavigation { get; set; }
    }
}
