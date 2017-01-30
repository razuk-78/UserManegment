using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UserManegment.Models
{
    public class WorkTitelPointer
    {
        public int Id { get; set; }
        public int userInOrgId { get; set; }
        public int WorkTitelId { get; set; }
        public virtual WorkTitel WorkTitel{ get; set; }
        public virtual UserInOrg UserInOrg { get; set; }
    }
}