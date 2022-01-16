using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace WebShop.Models
{
    public partial class ShopDBContext : DbContext
    {
        public ShopDBContext()
        {
        }

        public ShopDBContext(DbContextOptions<ShopDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Tblmenuitem> Tblmenuitems { get; set; }
        public virtual DbSet<Tblrole> Tblroles { get; set; }
        public virtual DbSet<Tblroleright> Tblrolerights { get; set; }
        public virtual DbSet<Tbluser> Tblusers { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseMySql("server=localhost;port=8889;database=ShopDB;user=root;password=1234567#;persist security info=False;connect timeout=300", Microsoft.EntityFrameworkCore.ServerVersion.Parse("5.7.32-mysql"));
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasCharSet("utf8");

            modelBuilder.Entity<Tblmenuitem>(entity =>
            {
                entity.HasKey(e => e.MenuitemId)
                    .HasName("PRIMARY");

                entity.ToTable("tblmenuitem");

                entity.Property(e => e.MenuitemId)
                    .HasMaxLength(32)
                    .HasColumnName("menuitem_id");

                entity.Property(e => e.MenuitemName)
                    .HasMaxLength(255)
                    .HasColumnName("menuitem_name");

                entity.Property(e => e.MenuitemNo)
                    .HasColumnType("int(11)")
                    .HasColumnName("menuitem_no");
            });

            modelBuilder.Entity<Tblrole>(entity =>
            {
                entity.HasKey(e => e.RoleId)
                    .HasName("PRIMARY");

                entity.ToTable("tblrole");

                entity.Property(e => e.RoleId)
                    .HasMaxLength(32)
                    .HasColumnName("role_id");

                entity.Property(e => e.RoleName)
                    .HasMaxLength(255)
                    .HasColumnName("role_name");
            });

            modelBuilder.Entity<Tblroleright>(entity =>
            {
                entity.HasKey(e => e.RolerightsId)
                    .HasName("PRIMARY");

                entity.ToTable("tblrolerights");

                entity.HasIndex(e => e.MenuitemIdFk, "menuitem_id_fk");

                entity.HasIndex(e => e.RoleIdFk, "role_id_fk");

                entity.Property(e => e.RolerightsId)
                    .HasMaxLength(32)
                    .HasColumnName("rolerights_id");

                entity.Property(e => e.MenuitemIdFk)
                    .HasMaxLength(32)
                    .HasColumnName("menuitem_id_fk");

                entity.Property(e => e.RoleIdFk)
                    .HasMaxLength(32)
                    .HasColumnName("role_id_fk");

                entity.Property(e => e.RolerightsDeletion).HasColumnName("rolerights_deletion");

                entity.Property(e => e.RolerightsDisplay).HasColumnName("rolerights_display");

                entity.Property(e => e.RolerightsExport).HasColumnName("rolerights_export");

                entity.Property(e => e.RolerightsImport).HasColumnName("rolerights_import");

                entity.Property(e => e.RolerightsInsertion).HasColumnName("rolerights_insertion");

                entity.Property(e => e.RolerightsUpdation).HasColumnName("rolerights_updation");

                entity.HasOne(d => d.MenuitemIdFkNavigation)
                    .WithMany(p => p.Tblrolerights)
                    .HasForeignKey(d => d.MenuitemIdFk)
                    .HasConstraintName("tblrolerights_ibfk_1");

                entity.HasOne(d => d.RoleIdFkNavigation)
                    .WithMany(p => p.Tblrolerights)
                    .HasForeignKey(d => d.RoleIdFk)
                    .HasConstraintName("tblrolerights_ibfk_2");
            });

            modelBuilder.Entity<Tbluser>(entity =>
            {
                entity.HasKey(e => e.UsersId)
                    .HasName("PRIMARY");

                entity.ToTable("tbluser");

                entity.HasIndex(e => e.RoleIdFk, "role_id_fk");

                entity.Property(e => e.UsersId)
                    .HasMaxLength(32)
                    .HasColumnName("users_id");

                entity.Property(e => e.RoleIdFk)
                    .HasMaxLength(32)
                    .HasColumnName("role_id_fk");

                entity.Property(e => e.UserEmail)
                    .HasMaxLength(255)
                    .HasColumnName("user_email");

                entity.Property(e => e.UserFirstname)
                    .HasMaxLength(255)
                    .HasColumnName("user_firstname");

                entity.Property(e => e.UserLastname)
                    .HasMaxLength(255)
                    .HasColumnName("user_lastname");

                entity.Property(e => e.UserPassword)
                    .HasMaxLength(255)
                    .HasColumnName("user_password");

                entity.Property(e => e.UserPhoto)
                    .HasMaxLength(255)
                    .HasColumnName("user_photo");

                entity.Property(e => e.UserUsername)
                    .HasMaxLength(255)
                    .HasColumnName("user_username");

                entity.HasOne(d => d.RoleIdFkNavigation)
                    .WithMany(p => p.Tblusers)
                    .HasForeignKey(d => d.RoleIdFk)
                    .HasConstraintName("tbluser_ibfk_1");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
