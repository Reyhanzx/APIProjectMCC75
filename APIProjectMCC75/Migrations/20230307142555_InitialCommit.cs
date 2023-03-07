using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace APIProjectMCC75.Migrations
{
    /// <inheritdoc />
    public partial class InitialCommit : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "tb_m_rey_office",
                columns: table => new
                {
                    code = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    city = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    phonenumber = table.Column<string>(name: "phone number", type: "nvarchar(255)", maxLength: 255, nullable: false),
                    address1 = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    address2 = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    state = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    country = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    postal_code = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    territory = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_m_rey_office", x => x.code);
                });

            migrationBuilder.CreateTable(
                name: "tb_m_rey_productline",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    ProductLineId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_m_rey_productline", x => x.id);
                    table.ForeignKey(
                        name: "FK_tb_m_rey_productline_tb_m_rey_productline_ProductLineId",
                        column: x => x.ProductLineId,
                        principalTable: "tb_m_rey_productline",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "tb_m_rey_roles",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_m_rey_roles", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "tb_m_rey_employee",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    office_code = table.Column<int>(type: "int", nullable: false),
                    reports_to = table.Column<int>(type: "int", nullable: true),
                    first_name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    last_name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    email = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    job_title = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_m_rey_employee", x => x.id);
                    table.ForeignKey(
                        name: "FK_tb_m_rey_employee_tb_m_rey_employee_reports_to",
                        column: x => x.reports_to,
                        principalTable: "tb_m_rey_employee",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_tb_m_rey_employee_tb_m_rey_office_office_code",
                        column: x => x.office_code,
                        principalTable: "tb_m_rey_office",
                        principalColumn: "code",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tb_m_rey_accounts",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false),
                    password = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_m_rey_accounts", x => x.id);
                    table.ForeignKey(
                        name: "FK_tb_m_rey_accounts_tb_m_rey_employee_id",
                        column: x => x.id,
                        principalTable: "tb_m_rey_employee",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tb_m_rey_customer",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    employee_id = table.Column<int>(type: "int", nullable: false),
                    firstname = table.Column<string>(name: "first name", type: "nvarchar(255)", maxLength: 255, nullable: false),
                    lastname = table.Column<string>(name: "last name", type: "nvarchar(255)", maxLength: 255, nullable: true),
                    phonenumber = table.Column<string>(name: "phone number", type: "nvarchar(255)", maxLength: 255, nullable: false),
                    address1 = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    address2 = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    city = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    state = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    postalcode = table.Column<int>(name: "postal code", type: "int", maxLength: 255, nullable: false),
                    country = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    creditlimit = table.Column<int>(name: "credit limit", type: "int", maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_m_rey_customer", x => x.id);
                    table.ForeignKey(
                        name: "FK_tb_m_rey_customer_tb_m_rey_employee_employee_id",
                        column: x => x.employee_id,
                        principalTable: "tb_m_rey_employee",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tb_tr_rey_account_roles",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    account_id = table.Column<int>(type: "int", nullable: false),
                    role_id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_tr_rey_account_roles", x => x.id);
                    table.ForeignKey(
                        name: "FK_tb_tr_rey_account_roles_tb_m_rey_accounts_account_id",
                        column: x => x.account_id,
                        principalTable: "tb_m_rey_accounts",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_tb_tr_rey_account_roles_tb_m_rey_roles_role_id",
                        column: x => x.role_id,
                        principalTable: "tb_m_rey_roles",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tb_m_rey_order",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    customer_id = table.Column<int>(type: "int", nullable: false),
                    order_date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    required_date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    shipped_date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    status = table.Column<int>(type: "int", nullable: false),
                    comment = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_m_rey_order", x => x.id);
                    table.ForeignKey(
                        name: "FK_tb_m_rey_order_tb_m_rey_customer_customer_id",
                        column: x => x.customer_id,
                        principalTable: "tb_m_rey_customer",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tb_m_rey_payment",
                columns: table => new
                {
                    check_num = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    customer_id = table.Column<int>(type: "int", nullable: false),
                    payment_date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    amount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_m_rey_payment", x => x.check_num);
                    table.ForeignKey(
                        name: "FK_tb_m_rey_payment_tb_m_rey_customer_customer_id",
                        column: x => x.customer_id,
                        principalTable: "tb_m_rey_customer",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tb_tr_rey_order_product",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    order_id = table.Column<int>(type: "int", nullable: false),
                    product_id = table.Column<int>(type: "int", nullable: false),
                    quantity = table.Column<int>(type: "int", nullable: false),
                    price_each = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_tr_rey_order_product", x => x.id);
                    table.ForeignKey(
                        name: "FK_tb_tr_rey_order_product_tb_m_rey_order_order_id",
                        column: x => x.order_id,
                        principalTable: "tb_m_rey_order",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_tb_tr_rey_order_product_tb_m_rey_productline_product_id",
                        column: x => x.product_id,
                        principalTable: "tb_m_rey_productline",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "tb_m_rey_roles",
                columns: new[] { "id", "name" },
                values: new object[,]
                {
                    { 1, "Admin" },
                    { 2, "User" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_tb_m_rey_customer_employee_id",
                table: "tb_m_rey_customer",
                column: "employee_id");

            migrationBuilder.CreateIndex(
                name: "IX_tb_m_rey_customer_phone number",
                table: "tb_m_rey_customer",
                column: "phone number",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_tb_m_rey_employee_email",
                table: "tb_m_rey_employee",
                column: "email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_tb_m_rey_employee_office_code",
                table: "tb_m_rey_employee",
                column: "office_code");

            migrationBuilder.CreateIndex(
                name: "IX_tb_m_rey_employee_reports_to",
                table: "tb_m_rey_employee",
                column: "reports_to");

            migrationBuilder.CreateIndex(
                name: "IX_tb_m_rey_office_phone number",
                table: "tb_m_rey_office",
                column: "phone number",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_tb_m_rey_order_customer_id",
                table: "tb_m_rey_order",
                column: "customer_id");

            migrationBuilder.CreateIndex(
                name: "IX_tb_m_rey_payment_customer_id",
                table: "tb_m_rey_payment",
                column: "customer_id");

            migrationBuilder.CreateIndex(
                name: "IX_tb_m_rey_productline_ProductLineId",
                table: "tb_m_rey_productline",
                column: "ProductLineId");

            migrationBuilder.CreateIndex(
                name: "IX_tb_tr_rey_account_roles_account_id",
                table: "tb_tr_rey_account_roles",
                column: "account_id");

            migrationBuilder.CreateIndex(
                name: "IX_tb_tr_rey_account_roles_role_id",
                table: "tb_tr_rey_account_roles",
                column: "role_id");

            migrationBuilder.CreateIndex(
                name: "IX_tb_tr_rey_order_product_order_id",
                table: "tb_tr_rey_order_product",
                column: "order_id");

            migrationBuilder.CreateIndex(
                name: "IX_tb_tr_rey_order_product_product_id",
                table: "tb_tr_rey_order_product",
                column: "product_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tb_m_rey_payment");

            migrationBuilder.DropTable(
                name: "tb_tr_rey_account_roles");

            migrationBuilder.DropTable(
                name: "tb_tr_rey_order_product");

            migrationBuilder.DropTable(
                name: "tb_m_rey_accounts");

            migrationBuilder.DropTable(
                name: "tb_m_rey_roles");

            migrationBuilder.DropTable(
                name: "tb_m_rey_order");

            migrationBuilder.DropTable(
                name: "tb_m_rey_productline");

            migrationBuilder.DropTable(
                name: "tb_m_rey_customer");

            migrationBuilder.DropTable(
                name: "tb_m_rey_employee");

            migrationBuilder.DropTable(
                name: "tb_m_rey_office");
        }
    }
}
