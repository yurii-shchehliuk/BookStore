using Microsoft.EntityFrameworkCore.Migrations;

namespace Domain.Migrations
{
    public partial class as31 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BasicDatas2_BasicDatas1_BasicData1Id",
                table: "BasicDatas2");

            migrationBuilder.DropIndex(
                name: "IX_BasicDatas2_BasicData1Id",
                table: "BasicDatas2");

            migrationBuilder.AlterColumn<int>(
                name: "BasicData1Id",
                table: "BasicDatas2",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateIndex(
                name: "IX_BasicDatas2_BasicData1Id",
                table: "BasicDatas2",
                column: "BasicData1Id",
                unique: true,
                filter: "[BasicData1Id] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_BasicDatas2_BasicDatas1_BasicData1Id",
                table: "BasicDatas2",
                column: "BasicData1Id",
                principalTable: "BasicDatas1",
                principalColumn: "BasicData1Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BasicDatas2_BasicDatas1_BasicData1Id",
                table: "BasicDatas2");

            migrationBuilder.DropIndex(
                name: "IX_BasicDatas2_BasicData1Id",
                table: "BasicDatas2");

            migrationBuilder.AlterColumn<int>(
                name: "BasicData1Id",
                table: "BasicDatas2",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_BasicDatas2_BasicData1Id",
                table: "BasicDatas2",
                column: "BasicData1Id",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_BasicDatas2_BasicDatas1_BasicData1Id",
                table: "BasicDatas2",
                column: "BasicData1Id",
                principalTable: "BasicDatas1",
                principalColumn: "BasicData1Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
