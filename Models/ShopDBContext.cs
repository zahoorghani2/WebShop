using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace WebShop.Models
{
    public partial class ShopDBContext : DbContext
    {

        public ShopDBContext(DbContextOptions<ShopDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Tblcustomer> Tblcustomers { get; set; }
        public virtual DbSet<Tblmenuitem> Tblmenuitems { get; set; }
        public virtual DbSet<Tblpayment> Tblpayments { get; set; }
        public virtual DbSet<Tblproduct> Tblproducts { get; set; }
        public virtual DbSet<Tblrole> Tblroles { get; set; }
        public virtual DbSet<Tblroleright> Tblrolerights { get; set; }
        public virtual DbSet<Tblsale> Tblsales { get; set; }
        public virtual DbSet<Tbluser> Tblusers { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseMySql("server=localhost;port=8889;database=ShopDB;user=root;password=1234567#;persist security info=False;connect timeout=300", Microsoft.EntityFrameworkCore.ServerVersion.Parse("5.7.32-mysql"));
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasCharSet("utf8");

            modelBuilder.Entity<Tblcustomer>(entity =>
            {
                entity.HasKey(e => e.CustomerId)
                    .HasName("PRIMARY");

                entity.ToTable("tblcustomers");

                entity.Property(e => e.CustomerId)
                    .HasMaxLength(32)
                    .HasColumnName("customer_id");

                entity.Property(e => e.CustomerAddress)
                    .HasMaxLength(255)
                    .HasColumnName("customer_address");

                entity.Property(e => e.CustomerCnic)
                    .HasMaxLength(255)
                    .HasColumnName("customer_cnic");

                entity.Property(e => e.CustomerCreationdate)
                    .HasColumnType("date")
                    .HasColumnName("customer_creationdate");

                entity.Property(e => e.CustomerFathername)
                    .HasMaxLength(255)
                    .HasColumnName("customer_fathername");

                entity.Property(e => e.CustomerMobileno)
                    .HasMaxLength(255)
                    .HasColumnName("customer_mobileno");

                entity.Property(e => e.CustomerName)
                    .HasMaxLength(255)
                    .HasColumnName("customer_name");

                entity.Property(e => e.CustomerReference)
                    .HasMaxLength(255)
                    .HasColumnName("customer_reference");
            });

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

            modelBuilder.Entity<Tblpayment>(entity =>
            {
                entity.HasKey(e => e.PayId)
                    .HasName("PRIMARY");

                entity.ToTable("tblpayments");

                entity.Property(e => e.PayId)
                    .HasMaxLength(32)
                    .HasColumnName("pay_id");

                entity.Property(e => e.PayAmount)
                    .HasPrecision(10)
                    .HasColumnName("pay_amount");

                entity.Property(e => e.PayDate)
                    .HasColumnType("date")
                    .HasColumnName("pay_date");

                entity.Property(e => e.SaleId)
                    .HasMaxLength(32)
                    .HasColumnName("sale_id");

                entity.Property(e => e.Status)
                    .HasMaxLength(255)
                    .HasColumnName("status");
            });

            modelBuilder.Entity<Tblproduct>(entity =>
            {
                entity.HasKey(e => e.ProductId)
                    .HasName("PRIMARY");

                entity.ToTable("tblproducts");

                entity.Property(e => e.ProductId)
                    .HasMaxLength(32)
                    .HasColumnName("product_id");

                entity.Property(e => e.ProductCreationdate)
                    .HasColumnType("date")
                    .HasColumnName("product_creationdate");

                entity.Property(e => e.ProductDesc)
                    .HasMaxLength(255)
                    .HasColumnName("product_desc");

                entity.Property(e => e.ProductName)
                    .HasMaxLength(255)
                    .HasColumnName("product_name");
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

            modelBuilder.Entity<Tblsale>(entity =>
            {
                entity.HasKey(e => e.SaleId)
                    .HasName("PRIMARY");

                entity.ToTable("tblsale");

                entity.Property(e => e.SaleId)
                    .HasMaxLength(32)
                    .HasColumnName("sale_id");

                entity.Property(e => e.CustomerId)
                    .HasMaxLength(32)
                    .HasColumnName("customer_id");

                entity.Property(e => e.Imei1)
                    .HasMaxLength(255)
                    .HasColumnName("imei1");

                entity.Property(e => e.Imei2)
                    .HasMaxLength(255)
                    .HasColumnName("imei2");

                entity.Property(e => e.ProductId)
                    .HasMaxLength(32)
                    .HasColumnName("product_id");

                entity.Property(e => e.SaleMonthlyinstallements)
                    .HasPrecision(10)
                    .HasColumnName("sale_monthlyinstallements");

                entity.Property(e => e.SaleRemainingamount)
                    .HasPrecision(10)
                    .HasColumnName("sale_remainingamount");

                entity.Property(e => e.SaleTotalamount)
                    .HasPrecision(10)
                    .HasColumnName("sale_totalamount");

                entity.Property(e => e.SalePaidAmount)
                    .HasPrecision(20)
                    .HasColumnName("sale_paidamount");

                entity.Property(e => e.Status)
                    .HasMaxLength(255)
                    .HasColumnName("status");
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
