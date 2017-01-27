namespace UserManegment.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("WorkTitel")]
    public partial class WorkTitel
    {
        public int Id { get; set; }
        public WorkTitel()
        {
            UserInOrg = new HashSet<UserInOrg>();
        }
        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        public int UserInOrgId { get; set; }

        public virtual ICollection<UserInOrg> UserInOrg { get; set; }


    }
}
