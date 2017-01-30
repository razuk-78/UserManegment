using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UserManegment.Models
{
    public class UserInOrg
    {
        public UserInOrg() {
            LogInRegistrys = new HashSet<LogInRegistry>();
            Roles = new HashSet<Role>();
        }
        public int Id { get; set; }
        public int UserId { get; set; }
        public int OrgId { get; set; }
        
        public virtual ICollection<WorkTitelPointer> WorkTitelPointer { get; set; }
        public virtual ICollection<LogInRegistry> LogInRegistrys { get; set; }
        public virtual ICollection<Role> Roles { get; set; }
    }
}