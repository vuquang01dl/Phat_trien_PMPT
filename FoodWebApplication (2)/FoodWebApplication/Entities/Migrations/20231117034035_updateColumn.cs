using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Entities.Migrations
{
    public partial class updateColumn : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "UsserName",
                table: "Customer",
                newName: "UserName");

            migrationBuilder.AddColumn<bool>(
                name: "IsSupper",
                table: "User",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AlterColumn<long>(
                name: "CategoryId",
                table: "Restaurant",
                type: "bigint",
                nullable: false,
                defaultValue: 0L,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "FoodId",
                table: "Modifier",
                type: "bigint",
                nullable: false,
                defaultValue: 0L,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: -1L,
                column: "CreatedAt",
                value: new DateTime(2023, 11, 17, 10, 40, 34, 792, DateTimeKind.Local).AddTicks(6819));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsSupper",
                table: "User");

            migrationBuilder.RenameColumn(
                name: "UserName",
                table: "Customer",
                newName: "UsserName");

            migrationBuilder.AlterColumn<string>(
                name: "CategoryId",
                table: "Restaurant",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AlterColumn<string>(
                name: "FoodId",
                table: "Modifier",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: -1L,
                column: "CreatedAt",
                value: new DateTime(2023, 11, 16, 9, 27, 28, 595, DateTimeKind.Local).AddTicks(7210));
        }
    }
}
