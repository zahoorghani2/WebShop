using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WebShop.Migrations
{
    public partial class MyFirstMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8");

            migrationBuilder.CreateTable(
                name: "tblcustomers",
                columns: table => new
                {
                    customer_id = table.Column<string>(type: "varchar(32)", maxLength: 32, nullable: false)
                        .Annotation("MySql:CharSet", "utf8"),
                    customer_name = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: true)
                        .Annotation("MySql:CharSet", "utf8"),
                    customer_fathername = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: true)
                        .Annotation("MySql:CharSet", "utf8"),
                    customer_cnic = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: true)
                        .Annotation("MySql:CharSet", "utf8"),
                    customer_mobileno = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: true)
                        .Annotation("MySql:CharSet", "utf8"),
                    customer_address = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: true)
                        .Annotation("MySql:CharSet", "utf8"),
                    customer_reference = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: true)
                        .Annotation("MySql:CharSet", "utf8"),
                    customer_creationdate = table.Column<DateTime>(type: "date", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.customer_id);
                })
                .Annotation("MySql:CharSet", "utf8");

            migrationBuilder.CreateTable(
                name: "tblmenuitem",
                columns: table => new
                {
                    menuitem_id = table.Column<string>(type: "varchar(32)", maxLength: 32, nullable: false)
                        .Annotation("MySql:CharSet", "utf8"),
                    menuitem_name = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: true)
                        .Annotation("MySql:CharSet", "utf8"),
                    menuitem_no = table.Column<int>(type: "int(11)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.menuitem_id);
                })
                .Annotation("MySql:CharSet", "utf8");

            migrationBuilder.CreateTable(
                name: "tblpayments",
                columns: table => new
                {
                    pay_id = table.Column<string>(type: "varchar(32)", maxLength: 32, nullable: false)
                        .Annotation("MySql:CharSet", "utf8"),
                    sale_id = table.Column<string>(type: "varchar(32)", maxLength: 32, nullable: true)
                        .Annotation("MySql:CharSet", "utf8"),
                    pay_amount = table.Column<decimal>(type: "decimal(10)", precision: 10, nullable: true),
                    pay_date = table.Column<DateTime>(type: "date", nullable: true),
                    status = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: true)
                        .Annotation("MySql:CharSet", "utf8")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.pay_id);
                })
                .Annotation("MySql:CharSet", "utf8");

            migrationBuilder.CreateTable(
                name: "tblproducts",
                columns: table => new
                {
                    product_id = table.Column<string>(type: "varchar(32)", maxLength: 32, nullable: false)
                        .Annotation("MySql:CharSet", "utf8"),
                    product_name = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: true)
                        .Annotation("MySql:CharSet", "utf8"),
                    product_desc = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: true)
                        .Annotation("MySql:CharSet", "utf8"),
                    product_creationdate = table.Column<DateTime>(type: "date", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.product_id);
                })
                .Annotation("MySql:CharSet", "utf8");

            migrationBuilder.CreateTable(
                name: "tblrole",
                columns: table => new
                {
                    role_id = table.Column<string>(type: "varchar(32)", maxLength: 32, nullable: false)
                        .Annotation("MySql:CharSet", "utf8"),
                    role_name = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: true)
                        .Annotation("MySql:CharSet", "utf8")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.role_id);
                })
                .Annotation("MySql:CharSet", "utf8");

            migrationBuilder.CreateTable(
                name: "tblsale",
                columns: table => new
                {
                    sale_id = table.Column<string>(type: "varchar(32)", maxLength: 32, nullable: false)
                        .Annotation("MySql:CharSet", "utf8"),
                    product_id = table.Column<string>(type: "varchar(32)", maxLength: 32, nullable: true)
                        .Annotation("MySql:CharSet", "utf8"),
                    customer_id = table.Column<string>(type: "varchar(32)", maxLength: 32, nullable: true)
                        .Annotation("MySql:CharSet", "utf8"),
                    imei1 = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: true)
                        .Annotation("MySql:CharSet", "utf8"),
                    imei2 = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: true)
                        .Annotation("MySql:CharSet", "utf8"),
                    sale_totalamount = table.Column<decimal>(type: "decimal(10)", precision: 10, nullable: true),
                    sale_remainingamount = table.Column<decimal>(type: "decimal(10)", precision: 10, nullable: true),
                    sale_monthlyinstallements = table.Column<decimal>(type: "decimal(10)", precision: 10, nullable: true),
                    status = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: true)
                        .Annotation("MySql:CharSet", "utf8")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.sale_id);
                })
                .Annotation("MySql:CharSet", "utf8");

            migrationBuilder.CreateTable(
                name: "tblrolerights",
                columns: table => new
                {
                    rolerights_id = table.Column<string>(type: "varchar(32)", maxLength: 32, nullable: false)
                        .Annotation("MySql:CharSet", "utf8"),
                    menuitem_id_fk = table.Column<string>(type: "varchar(32)", maxLength: 32, nullable: true)
                        .Annotation("MySql:CharSet", "utf8"),
                    role_id_fk = table.Column<string>(type: "varchar(32)", maxLength: 32, nullable: true)
                        .Annotation("MySql:CharSet", "utf8"),
                    rolerights_insertion = table.Column<bool>(type: "tinyint(1)", nullable: true),
                    rolerights_updation = table.Column<bool>(type: "tinyint(1)", nullable: true),
                    rolerights_deletion = table.Column<bool>(type: "tinyint(1)", nullable: true),
                    rolerights_display = table.Column<bool>(type: "tinyint(1)", nullable: true),
                    rolerights_import = table.Column<bool>(type: "tinyint(1)", nullable: true),
                    rolerights_export = table.Column<bool>(type: "tinyint(1)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.rolerights_id);
                    table.ForeignKey(
                        name: "tblrolerights_ibfk_1",
                        column: x => x.menuitem_id_fk,
                        principalTable: "tblmenuitem",
                        principalColumn: "menuitem_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "tblrolerights_ibfk_2",
                        column: x => x.role_id_fk,
                        principalTable: "tblrole",
                        principalColumn: "role_id",
                        onDelete: ReferentialAction.Restrict);
                })
                .Annotation("MySql:CharSet", "utf8");

            migrationBuilder.CreateTable(
                name: "tbluser",
                columns: table => new
                {
                    users_id = table.Column<string>(type: "varchar(32)", maxLength: 32, nullable: false)
                        .Annotation("MySql:CharSet", "utf8"),
                    role_id_fk = table.Column<string>(type: "varchar(32)", maxLength: 32, nullable: true)
                        .Annotation("MySql:CharSet", "utf8"),
                    user_firstname = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: true)
                        .Annotation("MySql:CharSet", "utf8"),
                    user_lastname = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: true)
                        .Annotation("MySql:CharSet", "utf8"),
                    user_username = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: true)
                        .Annotation("MySql:CharSet", "utf8"),
                    user_email = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: true)
                        .Annotation("MySql:CharSet", "utf8"),
                    user_password = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: true)
                        .Annotation("MySql:CharSet", "utf8"),
                    user_photo = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: true)
                        .Annotation("MySql:CharSet", "utf8")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.users_id);
                    table.ForeignKey(
                        name: "tbluser_ibfk_1",
                        column: x => x.role_id_fk,
                        principalTable: "tblrole",
                        principalColumn: "role_id",
                        onDelete: ReferentialAction.Restrict);
                })
                .Annotation("MySql:CharSet", "utf8");

            migrationBuilder.CreateIndex(
                name: "menuitem_id_fk",
                table: "tblrolerights",
                column: "menuitem_id_fk");

            migrationBuilder.CreateIndex(
                name: "role_id_fk",
                table: "tblrolerights",
                column: "role_id_fk");

            migrationBuilder.CreateIndex(
                name: "role_id_fk1",
                table: "tbluser",
                column: "role_id_fk");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tblcustomers");

            migrationBuilder.DropTable(
                name: "tblpayments");

            migrationBuilder.DropTable(
                name: "tblproducts");

            migrationBuilder.DropTable(
                name: "tblrolerights");

            migrationBuilder.DropTable(
                name: "tblsale");

            migrationBuilder.DropTable(
                name: "tbluser");

            migrationBuilder.DropTable(
                name: "tblmenuitem");

            migrationBuilder.DropTable(
                name: "tblrole");
        }
    }
}
