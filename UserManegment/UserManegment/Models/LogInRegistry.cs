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

        public int UserId { get; set; }

        public int OrgId { get; set; }

        public DateTime LogInTime { get; set; }

        public DateTime? LogOutTime { get; set; }

        public virtual ORG ORG { get; set; }

        public virtual User User { get; set; }
    }
}
