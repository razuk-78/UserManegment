namespace UserManegment.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using UserManegment.Security;
    [Table("Role")]
    public partial class Role
    {
       
        public int Id { get; set; }
        public int UserInOrgId { get; set; }
        [Column(TypeName="varchar(50)")]
        public String Type { get; set; }
        public virtual UserInOrg UserInOrg { get; set; }



    }
}
