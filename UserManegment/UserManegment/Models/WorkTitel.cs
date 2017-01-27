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

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        public int UserId { get; set; }

        public int OrgId { get; set; }

        public virtual ORG ORG { get; set; }

        public virtual User User { get; set; }
    }
}