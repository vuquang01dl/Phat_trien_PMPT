using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Entities.Migrations
{
    public partial class UpdateColumnRestaurantID : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<long>(
                name: "RestaurantId",
                table: "Food",
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
                value: new DateTime(2023, 11, 17, 15, 24, 5, 98, DateTimeKind.Local).AddTicks(6332));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "RestaurantId",
                table: "Food",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: -1L,
                column: "CreatedAt",
                value: new DateTime(2023, 11, 17, 10, 40, 34, 792, DateTimeKind.Local).AddTicks(6819));
        }
    }
}
