using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Server.Migrations
{
    public partial class AddNamePurchase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Purchases",
                type: "TEXT",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Purchases",
                keyColumn: "Id",
                keyValue: 101,
                columns: new[] { "Date", "Name" },
                values: new object[] { new DateTime(2021, 6, 9, 18, 30, 59, 820, DateTimeKind.Local).AddTicks(1992), "Compra Semanal" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Name",
                table: "Purchases");

            migrationBuilder.UpdateData(
                table: "Purchases",
                keyColumn: "Id",
                keyValue: 101,
                column: "Date",
                value: new DateTime(2021, 4, 28, 20, 49, 20, 486, DateTimeKind.Local).AddTicks(363));
        }
    }
}
