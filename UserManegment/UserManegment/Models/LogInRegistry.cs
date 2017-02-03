namespace UserManegment.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("LogInRegistry")]
    public partial class LogInRegistry
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }
        // should be changed to property
        public int UserInOrgId;
        
        public DateTime LogInTime { get; set; }

        public DateTime? LogOutTime { get; set; }
        
        public virtual UserInOrg UserInOrg { get; set; }
    }
}
