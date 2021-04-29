using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Server.Migrations
{
    public partial class AddUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Purchases",
                keyColumn: "Id",
                keyValue: 101,
                column: "Date",
                value: new DateTime(2021, 4, 28, 20, 49, 20, 486, DateTimeKind.Local).AddTicks(363));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Purchases",
                keyColumn: "Id",
                keyValue: 101,
                column: "Date",
                value: new DateTime(2021, 3, 19, 10, 46, 32, 553, DateTimeKind.Local).AddTicks(6773));
        }
    }
}
