﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WebShop.Models;

namespace WebShop.Migrations
{
    [DbContext(typeof(ShopDBContext))]
    partial class ShopDBContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasCharSet("utf8")
                .HasAnnotation("Relational:MaxIdentifierLength", 64)
                .HasAnnotation("ProductVersion", "5.0.5");

            modelBuilder.Entity("WebShop.Models.Tblcustomer", b =>
                {
                    b.Property<string>("CustomerId")
                        .HasMaxLength(32)
                        .HasColumnType("varchar(32)")
                        .HasColumnName("customer_id");

                    b.Property<string>("CustomerAddress")
                        .HasMaxLength(255)
                        .HasColumnType("varchar(255)")
                        .HasColumnName("customer_address");

                    b.Property<string>("CustomerCnic")
                        .HasMaxLength(255)
                        .HasColumnType("varchar(255)")
                        .HasColumnName("customer_cnic");

                    b.Property<DateTime?>("CustomerCreationdate")
                        .HasColumnType("date")
                        .HasColumnName("customer_creationdate");

                    b.Property<string>("CustomerFathername")
                        .HasMaxLength(255)
                        .HasColumnType("varchar(255)")
                        .HasColumnName("customer_fathername");

                    b.Property<string>("CustomerMobileno")
                        .HasMaxLength(255)
                        .HasColumnType("varchar(255)")
                        .HasColumnName("customer_mobileno");

                    b.Property<string>("CustomerName")
                        .HasMaxLength(255)
                        .HasColumnType("varchar(255)")
                        .HasColumnName("customer_name");

                    b.Property<string>("CustomerReference")
                        .HasMaxLength(255)
                        .HasColumnType("varchar(255)")
                        .HasColumnName("customer_reference");

                    b.HasKey("CustomerId")
                        .HasName("PRIMARY");

                    b.ToTable("tblcustomers");
                });

            modelBuilder.Entity("WebShop.Models.Tblmenuitem", b =>
                {
                    b.Property<string>("MenuitemId")
                        .HasMaxLength(32)
                        .HasColumnType("varchar(32)")
                        .HasColumnName("menuitem_id");

                    b.Property<string>("MenuitemName")
                        .HasMaxLength(255)
                        .HasColumnType("varchar(255)")
                        .HasColumnName("menuitem_name");

                    b.Property<int?>("MenuitemNo")
                        .HasColumnType("int(11)")
                        .HasColumnName("menuitem_no");

                    b.HasKey("MenuitemId")
                        .HasName("PRIMARY");

                    b.ToTable("tblmenuitem");
                });

            modelBuilder.Entity("WebShop.Models.Tblpayment", b =>
                {
                    b.Property<string>("PayId")
                        .HasMaxLength(32)
                        .HasColumnType("varchar(32)")
                        .HasColumnName("pay_id");

                    b.Property<decimal?>("PayAmount")
                        .HasPrecision(10)
                        .HasColumnType("decimal(10)")
                        .HasColumnName("pay_amount");

                    b.Property<DateTime?>("PayDate")
                        .HasColumnType("date")
                        .HasColumnName("pay_date");

                    b.Property<string>("SaleId")
                        .HasMaxLength(32)
                        .HasColumnType("varchar(32)")
                        .HasColumnName("sale_id");

                    b.Property<string>("Status")
                        .HasMaxLength(255)
                        .HasColumnType("varchar(255)")
                        .HasColumnName("status");

                    b.HasKey("PayId")
                        .HasName("PRIMARY");

                    b.ToTable("tblpayments");
                });

            modelBuilder.Entity("WebShop.Models.Tblproduct", b =>
                {
                    b.Property<string>("ProductId")
                        .HasMaxLength(32)
                        .HasColumnType("varchar(32)")
                        .HasColumnName("product_id");

                    b.Property<DateTime?>("ProductCreationdate")
                        .HasColumnType("date")
                        .HasColumnName("product_creationdate");

                    b.Property<string>("ProductDesc")
                        .HasMaxLength(255)
                        .HasColumnType("varchar(255)")
                        .HasColumnName("product_desc");

                    b.Property<string>("ProductName")
                        .HasMaxLength(255)
                        .HasColumnType("varchar(255)")
                        .HasColumnName("product_name");

                    b.HasKey("ProductId")
                        .HasName("PRIMARY");

                    b.ToTable("tblproducts");
                });

            modelBuilder.Entity("WebShop.Models.Tblrole", b =>
                {
                    b.Property<string>("RoleId")
                        .HasMaxLength(32)
                        .HasColumnType("varchar(32)")
                        .HasColumnName("role_id");

                    b.Property<string>("RoleName")
                        .HasMaxLength(255)
                        .HasColumnType("varchar(255)")
                        .HasColumnName("role_name");

                    b.HasKey("RoleId")
                        .HasName("PRIMARY");

                    b.ToTable("tblrole");
                });

            modelBuilder.Entity("WebShop.Models.Tblroleright", b =>
                {
                    b.Property<string>("RolerightsId")
                        .HasMaxLength(32)
                        .HasColumnType("varchar(32)")
                        .HasColumnName("rolerights_id");

                    b.Property<string>("MenuitemIdFk")
                        .HasMaxLength(32)
                        .HasColumnType("varchar(32)")
                        .HasColumnName("menuitem_id_fk");

                    b.Property<string>("RoleIdFk")
                        .HasMaxLength(32)
                        .HasColumnType("varchar(32)")
                        .HasColumnName("role_id_fk");

                    b.Property<bool?>("RolerightsDeletion")
                        .HasColumnType("tinyint(1)")
                        .HasColumnName("rolerights_deletion");

                    b.Property<bool?>("RolerightsDisplay")
                        .HasColumnType("tinyint(1)")
                        .HasColumnName("rolerights_display");

                    b.Property<bool?>("RolerightsExport")
                        .HasColumnType("tinyint(1)")
                        .HasColumnName("rolerights_export");

                    b.Property<bool?>("RolerightsImport")
                        .HasColumnType("tinyint(1)")
                        .HasColumnName("rolerights_import");

                    b.Property<bool?>("RolerightsInsertion")
                        .HasColumnType("tinyint(1)")
                        .HasColumnName("rolerights_insertion");

                    b.Property<bool?>("RolerightsUpdation")
                        .HasColumnType("tinyint(1)")
                        .HasColumnName("rolerights_updation");

                    b.HasKey("RolerightsId")
                        .HasName("PRIMARY");

                    b.HasIndex(new[] { "MenuitemIdFk" }, "menuitem_id_fk");

                    b.HasIndex(new[] { "RoleIdFk" }, "role_id_fk");

                    b.ToTable("tblrolerights");
                });

            modelBuilder.Entity("WebShop.Models.Tblsale", b =>
                {
                    b.Property<string>("SaleId")
                        .HasMaxLength(32)
                        .HasColumnType("varchar(32)")
                        .HasColumnName("sale_id");

                    b.Property<string>("CustomerId")
                        .HasMaxLength(32)
                        .HasColumnType("varchar(32)")
                        .HasColumnName("customer_id");

                    b.Property<string>("Imei1")
                        .HasMaxLength(255)
                        .HasColumnType("varchar(255)")
                        .HasColumnName("imei1");

                    b.Property<string>("Imei2")
                        .HasMaxLength(255)
                        .HasColumnType("varchar(255)")
                        .HasColumnName("imei2");

                    b.Property<string>("ProductId")
                        .HasMaxLength(32)
                        .HasColumnType("varchar(32)")
                        .HasColumnName("product_id");

                    b.Property<decimal?>("SaleMonthlyinstallements")
                        .HasPrecision(10)
                        .HasColumnType("decimal(10)")
                        .HasColumnName("sale_monthlyinstallements");

                    b.Property<decimal?>("SaleRemainingamount")
                        .HasPrecision(10)
                        .HasColumnType("decimal(10)")
                        .HasColumnName("sale_remainingamount");

                    b.Property<decimal?>("SaleTotalamount")
                        .HasPrecision(10)
                        .HasColumnType("decimal(10)")
                        .HasColumnName("sale_totalamount");

                    b.Property<string>("Status")
                        .HasMaxLength(255)
                        .HasColumnType("varchar(255)")
                        .HasColumnName("status");

                    b.HasKey("SaleId")
                        .HasName("PRIMARY");

                    b.ToTable("tblsale");
                });

            modelBuilder.Entity("WebShop.Models.Tbluser", b =>
                {
                    b.Property<string>("UsersId")
                        .HasMaxLength(32)
                        .HasColumnType("varchar(32)")
                        .HasColumnName("users_id");

                    b.Property<string>("RoleIdFk")
                        .HasMaxLength(32)
                        .HasColumnType("varchar(32)")
                        .HasColumnName("role_id_fk");

                    b.Property<string>("UserEmail")
                        .HasMaxLength(255)
                        .HasColumnType("varchar(255)")
                        .HasColumnName("user_email");

                    b.Property<string>("UserFirstname")
                        .HasMaxLength(255)
                        .HasColumnType("varchar(255)")
                        .HasColumnName("user_firstname");

                    b.Property<string>("UserLastname")
                        .HasMaxLength(255)
                        .HasColumnType("varchar(255)")
                        .HasColumnName("user_lastname");

                    b.Property<string>("UserPassword")
                        .HasMaxLength(255)
                        .HasColumnType("varchar(255)")
                        .HasColumnName("user_password");

                    b.Property<string>("UserPhoto")
                        .HasMaxLength(255)
                        .HasColumnType("varchar(255)")
                        .HasColumnName("user_photo");

                    b.Property<string>("UserUsername")
                        .HasMaxLength(255)
                        .HasColumnType("varchar(255)")
                        .HasColumnName("user_username");

                    b.HasKey("UsersId")
                        .HasName("PRIMARY");

                    b.HasIndex(new[] { "RoleIdFk" }, "role_id_fk")
                        .HasDatabaseName("role_id_fk1");

                    b.ToTable("tbluser");
                });

            modelBuilder.Entity("WebShop.Models.Tblroleright", b =>
                {
                    b.HasOne("WebShop.Models.Tblmenuitem", "MenuitemIdFkNavigation")
                        .WithMany("Tblrolerights")
                        .HasForeignKey("MenuitemIdFk")
                        .HasConstraintName("tblrolerights_ibfk_1");

                    b.HasOne("WebShop.Models.Tblrole", "RoleIdFkNavigation")
                        .WithMany("Tblrolerights")
                        .HasForeignKey("RoleIdFk")
                        .HasConstraintName("tblrolerights_ibfk_2");

                    b.Navigation("MenuitemIdFkNavigation");

                    b.Navigation("RoleIdFkNavigation");
                });

            modelBuilder.Entity("WebShop.Models.Tbluser", b =>
                {
                    b.HasOne("WebShop.Models.Tblrole", "RoleIdFkNavigation")
                        .WithMany("Tblusers")
                        .HasForeignKey("RoleIdFk")
                        .HasConstraintName("tbluser_ibfk_1");

                    b.Navigation("RoleIdFkNavigation");
                });

            modelBuilder.Entity("WebShop.Models.Tblmenuitem", b =>
                {
                    b.Navigation("Tblrolerights");
                });

            modelBuilder.Entity("WebShop.Models.Tblrole", b =>
                {
                    b.Navigation("Tblrolerights");

                    b.Navigation("Tblusers");
                });
#pragma warning restore 612, 618
        }
    }
}
