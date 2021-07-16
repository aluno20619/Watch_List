using Microsoft.EntityFrameworkCore.Migrations;

namespace Watch_List.Data.Migrations
{
    public partial class AlterDB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f",
                column: "ConcurrencyStamp",
                value: "e6390f2e-fb2c-4e31-a5c7-a830babcf6fc");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "g",
                column: "ConcurrencyStamp",
                value: "a54fc12b-560c-4244-b50d-a8bbdb9c0846");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "m",
                column: "ConcurrencyStamp",
                value: "ea206633-cb40-4181-a73c-5f634de0996d");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f",
                column: "ConcurrencyStamp",
                value: "989ad646-a184-4080-aceb-4e413b34dac8");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "g",
                column: "ConcurrencyStamp",
                value: "843a3c0c-1ba4-4fcf-af77-1db616736a5e");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "m",
                column: "ConcurrencyStamp",
                value: "9277ed8d-170d-4558-9406-5aa55f761505");
        }
    }
}
