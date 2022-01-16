using System;
using System.Collections.Generic;

#nullable disable

namespace WebShop.Models
{
    public partial class Tblroleright
    {
        public string RolerightsId { get; set; }
        public string MenuitemIdFk { get; set; }
        public string RoleIdFk { get; set; }
        public bool? RolerightsInsertion { get; set; }
        public bool? RolerightsUpdation { get; set; }
        public bool? RolerightsDeletion { get; set; }
        public bool? RolerightsDisplay { get; set; }
        public bool? RolerightsImport { get; set; }
        public bool? RolerightsExport { get; set; }

        public virtual Tblmenuitem MenuitemIdFkNavigation { get; set; }
        public virtual Tblrole RoleIdFkNavigation { get; set; }
    }
}
