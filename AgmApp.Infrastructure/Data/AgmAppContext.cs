using System;
using AgmApp.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace AgmApp.Infrastructure.Data
{
    public partial class AgmAppContext : DbContext
    {
        public AgmAppContext()
        {
        }

        public AgmAppContext(DbContextOptions<AgmAppContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Users> Users { get; set; }

//        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
//        {
//            if (!optionsBuilder.IsConfigured)
//            {
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
//                optionsBuilder.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;DataBase=AgmApp;Integrated Security= true");
//            }
//        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Users>(entity =>
            {
                entity.HasKey(e => e.UsrIdPk)
                    .HasName("PK__Table__9E22697A09DFE15C");

                entity.Property(e => e.UsrIdPk)
                    .HasColumnName("usr_id_pk")
                    .HasMaxLength(64)
                    .IsUnicode(false);

                entity.Property(e => e.UsrNombres)
                    .IsRequired()
                    .HasColumnName("usr_nombres")
                    .HasMaxLength(128)
                    .IsUnicode(false);

                entity.Property(e => e.UsrPassword)
                    .IsRequired()
                    .HasColumnName("usr_password")
                    .HasMaxLength(64)
                    .IsUnicode(false);

                entity.Property(e => e.UsrUsername)
                    .IsRequired()
                    .HasColumnName("usr_username")
                    .HasMaxLength(64)
                    .IsUnicode(false);
            });

            //OnModelCreatingPartial(modelBuilder);
        }

        //partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
