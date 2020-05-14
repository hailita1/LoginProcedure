namespace NgonCoVenDuong.Areas.Admin.Data
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class Model1 : DbContext
    {
        public Model1()
            : base("name=Model1")
        {
        }

        public virtual DbSet<tAdmin> tAdmins { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<tAdmin>()
                .Property(e => e.Username)
                .IsUnicode(false);

            modelBuilder.Entity<tAdmin>()
                .Property(e => e.Password)
                .IsUnicode(false);

            modelBuilder.Entity<tAdmin>()
                .Property(e => e.Phone)
                .IsUnicode(false);

            modelBuilder.Entity<tAdmin>()
                .Property(e => e.Email)
                .IsUnicode(false);
        }
    }
}
