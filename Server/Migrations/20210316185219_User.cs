using Microsoft.EntityFrameworkCore.Migrations;

namespace Server.Migrations
{
    public partial class User : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Product_Company_CompanyId",
                table: "Product");

            migrationBuilder.DropForeignKey(
                name: "FK_Purchases_Product_ProductId",
                table: "Purchases");

            migrationBuilder.DropIndex(
                name: "IX_Users_Email",
                table: "Users");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Product",
                table: "Product");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Company",
                table: "Company");

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 100);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 101);

            migrationBuilder.RenameTable(
                name: "Product",
                newName: "Products");

            migrationBuilder.RenameTable(
                name: "Company",
                newName: "Companies");

            migrationBuilder.RenameIndex(
                name: "IX_Product_CompanyId",
                table: "Products",
                newName: "IX_Products_CompanyId");

            migrationBuilder.AlterColumn<string>(
                name: "Observation",
                table: "Purchases",
                type: "TEXT",
                maxLength: 100,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldMaxLength: 100);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Products",
                table: "Products",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Companies",
                table: "Companies",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Companies_CompanyId",
                table: "Products",
                column: "CompanyId",
                principalTable: "Companies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Purchases_Products_ProductId",
                table: "Purchases",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_Companies_CompanyId",
                table: "Products");

            migrationBuilder.DropForeignKey(
                name: "FK_Purchases_Products_ProductId",
                table: "Purchases");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Products",
                table: "Products");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Companies",
                table: "Companies");

            migrationBuilder.RenameTable(
                name: "Products",
                newName: "Product");

            migrationBuilder.RenameTable(
                name: "Companies",
                newName: "Company");

            migrationBuilder.RenameIndex(
                name: "IX_Products_CompanyId",
                table: "Product",
                newName: "IX_Product_CompanyId");

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

            migrationBuilder.AddPrimaryKey(
                name: "PK_Product",
                table: "Product",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Company",
                table: "Company",
                column: "Id");

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Cpf", "Email", "Name", "Password" },
                values: new object[] { 100, "00000000000", "alexsousa@gmail.com", "Alex Sousa", "123456789" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Cpf", "Email", "Name", "Password" },
                values: new object[] { 101, "11111111111", "joaolucas@gmail.com", "João Lucas", "123456789" });

            migrationBuilder.CreateIndex(
                name: "IX_Users_Email",
                table: "Users",
                column: "Email",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Product_Company_CompanyId",
                table: "Product",
                column: "CompanyId",
                principalTable: "Company",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Purchases_Product_ProductId",
                table: "Purchases",
                column: "ProductId",
                principalTable: "Product",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
