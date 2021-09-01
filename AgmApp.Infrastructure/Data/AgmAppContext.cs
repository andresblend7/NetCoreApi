using System;
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

        public virtual DbSet<Roles> Roles { get; set; }
        public virtual DbSet<RolesUsuario> RolesUsuario { get; set; }
        public virtual DbSet<Users> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;DataBase=AgmApp;Integrated Security= true");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Roles>(entity =>
            {
                entity.Property(e => e.RolName)
                    .IsRequired()
                    .HasMaxLength(16)
                    .IsUnicode(false);

                entity.Property(e => e.RolRowId)
                    .IsRequired()
                    .HasMaxLength(64)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<RolesUsuario>(entity =>
            {
                entity.Property(e => e.IdRolFk).HasColumnName("idRolFk");

                entity.Property(e => e.IdUsuarioFk).HasColumnName("idUsuarioFk");

                entity.Property(e => e.Status).HasColumnName("status");

                entity.HasOne(d => d.IdRolFkNavigation)
                    .WithMany(p => p.RolesUsuario)
                    .HasForeignKey(d => d.IdRolFk)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_RolesUsuario_ToTable_1");

                entity.HasOne(d => d.IdUsuarioFkNavigation)
                    .WithMany(p => p.RolesUsuario)
                    .HasForeignKey(d => d.IdUsuarioFk)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_RolesUsuario_ToTable");
            });

            modelBuilder.Entity<Users>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.UsrIdPk)
                    .IsRequired()
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

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
