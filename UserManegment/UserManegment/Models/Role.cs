namespace UserManegment.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Role")]
    public partial class Role
    {
        public Role()
        {

            UserInOrg = new HashSet<UserInOrg>();
        }
        public int Id { get; set; }

        public int? Read { get; set; }

        public int? Write { get; set; }

        public int? Create { get; set; }

        public int? Delete { get; set; }
        public virtual ICollection<UserInOrg> UserInOrg { get; set; }
        
    }
}
