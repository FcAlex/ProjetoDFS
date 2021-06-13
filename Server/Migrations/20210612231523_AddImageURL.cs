using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Server.Migrations
{
    public partial class AddImageURL : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "imageURL",
                table: "Companies",
                type: "TEXT",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Companies",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "Cnpj", "CompanyName", "FantasyName", "imageURL" },
                values: new object[] { "47.960.950/0001-21", "MAGAZINE LUIZA S/A", "", "https://www.eletrolar.com/wp-content/uploads/2019/10/0.png" });

            migrationBuilder.UpdateData(
                table: "Purchases",
                keyColumn: "Id",
                keyValue: 101,
                column: "Date",
                value: new DateTime(2021, 6, 12, 20, 15, 22, 705, DateTimeKind.Local).AddTicks(4264));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "imageURL",
                table: "Companies");

            migrationBuilder.UpdateData(
                table: "Companies",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "Cnpj", "CompanyName", "FantasyName" },
                values: new object[] { "00.000.000/0001-99", "Alex Sousa ME", "FcoAlex" });

            migrationBuilder.UpdateData(
                table: "Purchases",
                keyColumn: "Id",
                keyValue: 101,
                column: "Date",
                value: new DateTime(2021, 6, 9, 18, 30, 59, 820, DateTimeKind.Local).AddTicks(1992));
        }
    }
}
