using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Server.Migrations
{
    public partial class AddImageURL2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "imageURL",
                table: "Users",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "imageURL",
                table: "Products",
                type: "TEXT",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                column: "imageURL",
                value: "https://a-static.mlcdn.com.br/618x463/cheetos-tubo-elma-chips-sabor-queijo-cheddar-45g/drogariaaraujosa/107646/d56f5c254b621b54d99a402b6cd80ff6.jpg");

            migrationBuilder.UpdateData(
                table: "Purchases",
                keyColumn: "Id",
                keyValue: 101,
                column: "Date",
                value: new DateTime(2021, 6, 12, 22, 55, 57, 92, DateTimeKind.Local).AddTicks(3456));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 101,
                column: "imageURL",
                value: "https://cdn.pixabay.com/photo/2014/07/09/10/04/man-388104_960_720.jpg");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "imageURL",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "imageURL",
                table: "Products");

            migrationBuilder.UpdateData(
                table: "Purchases",
                keyColumn: "Id",
                keyValue: 101,
                column: "Date",
                value: new DateTime(2021, 6, 12, 20, 15, 22, 705, DateTimeKind.Local).AddTicks(4264));
        }
    }
}
