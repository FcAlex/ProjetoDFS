using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Server.Migrations
{
    public partial class AddSeeds : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Products_CompanyId",
                table: "Products");

            migrationBuilder.InsertData(
                table: "Companies",
                columns: new[] { "Id", "Cnpj", "CompanyName", "FantasyName" },
                values: new object[] { 10, "00.000.000/0001-99", "Alex Sousa ME", "FcoAlex" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Cpf", "Email", "Name", "Password" },
                values: new object[] { 101, "000.000.000-00", "alex@example.com", "Alex Sousa", "12345678" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CompanyId", "Description", "Name", "Observation", "Value" },
                values: new object[] { 2, 10, "Salgadinho", "Cheetos", "n.a", 5f });

            migrationBuilder.InsertData(
                table: "Purchases",
                columns: new[] { "Id", "Address", "Cep", "Date", "Observation", "Payment Method", "ProductId", "Purchase Status", "UserId", "Value" },
                values: new object[] { 101, "Rua dos Bobos", "63.640-000", new DateTime(2021, 3, 19, 10, 46, 32, 553, DateTimeKind.Local).AddTicks(6773), "n.a", (byte)1, 2, (byte)5, 101, 500f });

            migrationBuilder.CreateIndex(
                name: "IX_Products_CompanyId",
                table: "Products",
                column: "CompanyId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Products_CompanyId",
                table: "Products");

            migrationBuilder.DeleteData(
                table: "Purchases",
                keyColumn: "Id",
                keyValue: 101);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 101);

            migrationBuilder.DeleteData(
                table: "Companies",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.CreateIndex(
                name: "IX_Products_CompanyId",
                table: "Products",
                column: "CompanyId");
        }
    }
}
