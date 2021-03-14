using Microsoft.EntityFrameworkCore.Migrations;

namespace Server.Migrations
{
    public partial class AddPurchases : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Product_Purchase_PurchaseId",
                table: "Product");

            migrationBuilder.DropForeignKey(
                name: "FK_Purchase_Users_UserId",
                table: "Purchase");

            migrationBuilder.DropIndex(
                name: "IX_Product_PurchaseId",
                table: "Product");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Purchase",
                table: "Purchase");

            migrationBuilder.DropColumn(
                name: "PurchaseId",
                table: "Product");

            migrationBuilder.RenameTable(
                name: "Purchase",
                newName: "Purchases");

            migrationBuilder.RenameColumn(
                name: "Status",
                table: "Purchases",
                newName: "Purchase Status");

            migrationBuilder.RenameColumn(
                name: "PaymentMethod",
                table: "Purchases",
                newName: "Payment Method");

            migrationBuilder.RenameIndex(
                name: "IX_Purchase_UserId",
                table: "Purchases",
                newName: "IX_Purchases_UserId");

            migrationBuilder.AlterColumn<string>(
                name: "Observation",
                table: "Purchases",
                type: "TEXT",
                maxLength: 100,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Cep",
                table: "Purchases",
                type: "TEXT",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Address",
                table: "Purchases",
                type: "TEXT",
                maxLength: 50,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ProductId",
                table: "Purchases",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Purchases",
                table: "Purchases",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Users_Email",
                table: "Users",
                column: "Email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Purchases_ProductId",
                table: "Purchases",
                column: "ProductId");

            migrationBuilder.AddForeignKey(
                name: "FK_Purchases_Product_ProductId",
                table: "Purchases",
                column: "ProductId",
                principalTable: "Product",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Purchases_Users_UserId",
                table: "Purchases",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Purchases_Product_ProductId",
                table: "Purchases");

            migrationBuilder.DropForeignKey(
                name: "FK_Purchases_Users_UserId",
                table: "Purchases");

            migrationBuilder.DropIndex(
                name: "IX_Users_Email",
                table: "Users");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Purchases",
                table: "Purchases");

            migrationBuilder.DropIndex(
                name: "IX_Purchases_ProductId",
                table: "Purchases");

            migrationBuilder.DropColumn(
                name: "ProductId",
                table: "Purchases");

            migrationBuilder.RenameTable(
                name: "Purchases",
                newName: "Purchase");

            migrationBuilder.RenameColumn(
                name: "Purchase Status",
                table: "Purchase",
                newName: "Status");

            migrationBuilder.RenameColumn(
                name: "Payment Method",
                table: "Purchase",
                newName: "PaymentMethod");

            migrationBuilder.RenameIndex(
                name: "IX_Purchases_UserId",
                table: "Purchase",
                newName: "IX_Purchase_UserId");

            migrationBuilder.AddColumn<int>(
                name: "PurchaseId",
                table: "Product",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<string>(
                name: "Observation",
                table: "Purchase",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<string>(
                name: "Cep",
                table: "Purchase",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT");

            migrationBuilder.AlterColumn<string>(
                name: "Address",
                table: "Purchase",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldMaxLength: 50);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Purchase",
                table: "Purchase",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Product_PurchaseId",
                table: "Product",
                column: "PurchaseId");

            migrationBuilder.AddForeignKey(
                name: "FK_Product_Purchase_PurchaseId",
                table: "Product",
                column: "PurchaseId",
                principalTable: "Purchase",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Purchase_Users_UserId",
                table: "Purchase",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
