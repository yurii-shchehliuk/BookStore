using Microsoft.EntityFrameworkCore.Migrations;

namespace Domain.Migrations
{
    public partial class asdasl : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BasicDatas1_CartItems_CartItemId",
                table: "BasicDatas1");

            migrationBuilder.DropIndex(
                name: "IX_BasicDatas1_CartItemId",
                table: "BasicDatas1");

            migrationBuilder.AlterColumn<int>(
                name: "CartItemId",
                table: "BasicDatas1",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateIndex(
                name: "IX_BasicDatas1_CartItemId",
                table: "BasicDatas1",
                column: "CartItemId",
                unique: true,
                filter: "[CartItemId] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_BasicDatas1_CartItems_CartItemId",
                table: "BasicDatas1",
                column: "CartItemId",
                principalTable: "CartItems",
                principalColumn: "CartItemId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BasicDatas1_CartItems_CartItemId",
                table: "BasicDatas1");

            migrationBuilder.DropIndex(
                name: "IX_BasicDatas1_CartItemId",
                table: "BasicDatas1");

            migrationBuilder.AlterColumn<int>(
                name: "CartItemId",
                table: "BasicDatas1",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_BasicDatas1_CartItemId",
                table: "BasicDatas1",
                column: "CartItemId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_BasicDatas1_CartItems_CartItemId",
                table: "BasicDatas1",
                column: "CartItemId",
                principalTable: "CartItems",
                principalColumn: "CartItemId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
