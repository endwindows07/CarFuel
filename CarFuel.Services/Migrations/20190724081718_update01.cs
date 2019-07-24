using Microsoft.EntityFrameworkCore.Migrations;

namespace CarFuel.Services.Migrations
{
    public partial class update01 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FillUp_Cars_CarId",
                table: "FillUp");

            migrationBuilder.DropForeignKey(
                name: "FK_FillUp_FillUp_NextId",
                table: "FillUp");

            migrationBuilder.DropPrimaryKey(
                name: "PK_FillUp",
                table: "FillUp");

            migrationBuilder.RenameTable(
                name: "FillUp",
                newName: "FillUps");

            migrationBuilder.RenameIndex(
                name: "IX_FillUp_NextId",
                table: "FillUps",
                newName: "IX_FillUps_NextId");

            migrationBuilder.RenameIndex(
                name: "IX_FillUp_CarId",
                table: "FillUps",
                newName: "IX_FillUps_CarId");

            migrationBuilder.AlterColumn<string>(
                name: "Lavel",
                table: "Members",
                nullable: false,
                oldClrType: typeof(int));

            migrationBuilder.AddPrimaryKey(
                name: "PK_FillUps",
                table: "FillUps",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_FillUps_Cars_CarId",
                table: "FillUps",
                column: "CarId",
                principalTable: "Cars",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_FillUps_FillUps_NextId",
                table: "FillUps",
                column: "NextId",
                principalTable: "FillUps",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FillUps_Cars_CarId",
                table: "FillUps");

            migrationBuilder.DropForeignKey(
                name: "FK_FillUps_FillUps_NextId",
                table: "FillUps");

            migrationBuilder.DropPrimaryKey(
                name: "PK_FillUps",
                table: "FillUps");

            migrationBuilder.RenameTable(
                name: "FillUps",
                newName: "FillUp");

            migrationBuilder.RenameIndex(
                name: "IX_FillUps_NextId",
                table: "FillUp",
                newName: "IX_FillUp_NextId");

            migrationBuilder.RenameIndex(
                name: "IX_FillUps_CarId",
                table: "FillUp",
                newName: "IX_FillUp_CarId");

            migrationBuilder.AlterColumn<int>(
                name: "Lavel",
                table: "Members",
                nullable: false,
                oldClrType: typeof(string));

            migrationBuilder.AddPrimaryKey(
                name: "PK_FillUp",
                table: "FillUp",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_FillUp_Cars_CarId",
                table: "FillUp",
                column: "CarId",
                principalTable: "Cars",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_FillUp_FillUp_NextId",
                table: "FillUp",
                column: "NextId",
                principalTable: "FillUp",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
