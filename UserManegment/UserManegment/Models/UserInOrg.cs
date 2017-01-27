using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UserManegment.Models
{
    public class UserInOrg
    {
        public UserInOrg() {
            LogInRegistry = new HashSet<LogInRegistry>();
        }
        public int Id { get; set; }
        public int UserId { get; set; }
        public int WorkTitelId { get; set; }
        public int OrgId { get; set; }
        public int RoleId { get; set; }

        public virtual WorkTitel WorkTitel { get; set; }
        public virtual Role Role { get; set; }
        public virtual ICollection<LogInRegistry> LogInRegistry { get; set; }
    }
}