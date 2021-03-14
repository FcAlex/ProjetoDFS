using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Server.Migrations
{
    public partial class AddSeedPurchase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Observation",
                table: "Purchases",
                type: "TEXT",
                maxLength: 100,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldMaxLength: 100);

            migrationBuilder.InsertData(
                table: "Purchases",
                columns: new[] { "Id", "Address", "Cep", "Date", "Observation", "Payment Method", "ProductId", "Purchase Status", "UserId", "Value" },
                values: new object[] { 101, "Rua do Bobos, nr. 0", "63640-000", new DateTime(2021, 3, 12, 16, 51, 6, 875, DateTimeKind.Local).AddTicks(5904), "n.a", (byte)3, 0, (byte)2, 101, 0f });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Purchases",
                keyColumn: "Id",
                keyValue: 101);

            migrationBuilder.AlterColumn<string>(
                name: "Observation",
                table: "Purchases",
                type: "TEXT",
                maxLength: 100,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldMaxLength: 100,
                oldNullable: true);
        }
    }
}
