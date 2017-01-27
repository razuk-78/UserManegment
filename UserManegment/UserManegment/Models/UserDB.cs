namespace UserManegment.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class UserDB : DbContext
    {
        public UserDB()
            : base("name=UserConnection")
        {
        }

        public virtual DbSet<LogInRegistry> LogInRegistry { get; set; }
        public virtual DbSet<ORG> ORG { get; set; }
        public virtual DbSet<Role> Role { get; set; }
        public virtual DbSet<User> User { get; set; }
        public virtual DbSet<WorkTitel> WorkTitel { get; set; }
        public virtual DbSet<UserInOrg> UserInOrg { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ORG>()
                .HasMany(e => e.LogInRegistry)
                .WithRequired(e => e.ORG)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<ORG>()
                .HasMany(e => e.WorkTitel)
                .WithRequired(e => e.ORG)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<User>()
                .Property(e => e.Category)
                .IsFixedLength();

            modelBuilder.Entity<User>()
                .HasMany(e => e.LogInRegistry)
                .WithRequired(e => e.User)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<User>()
                .HasMany(e => e.WorkTitel)
                .WithRequired(e => e.User)
                .WillCascadeOnDelete(false);
        }
    }
}
