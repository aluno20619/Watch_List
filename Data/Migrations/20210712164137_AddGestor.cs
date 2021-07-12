using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Watch_List.Data.Migrations
{
    public partial class AddGestor : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f",
                column: "ConcurrencyStamp",
                value: "0694fd01-ad2f-403a-ac7d-315e2dd5ca66");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "g",
                column: "ConcurrencyStamp",
                value: "ff4317ab-3058-43f1-b439-7787a0acf591");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "m",
                column: "ConcurrencyStamp",
                value: "2d36644a-ad00-48ed-a3f1-05a69895091e");

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "DataRegisto", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "8e445865-a24d-4543-a6c6-9443d048cdb9", 0, "2fb4c98b-5353-42a4-9442-7b7ed7119cea", new DateTime(2021, 7, 12, 17, 41, 35, 82, DateTimeKind.Local).AddTicks(5838), "gestor@gestor.com", true, false, null, null, "GESTOR", "AQAAAAEAACcQAAAAEP9cJ8GrzjUcaCAp0tMXMieiXnVpDFZUW8/nu44HjrDOb9+XhZHRT8RoWncZAjKD1g==", null, false, "168a79ef-01e3-4be6-b4d3-ef2e1caea865", false, "gestor" });

            migrationBuilder.InsertData(
                table: "Utilizador",
                columns: new[] { "Id", "Email", "Nome", "UtilIdFK" },
                values: new object[] { 1, "gestor@gestor.com", "gestor", "8e445865-a24d-4543-a6c6-9443d048cdb9" });

            migrationBuilder.InsertData(
                table: "UtilFilme",
                columns: new[] { "Id", "Estado", "FilFK", "UtilFK" },
                values: new object[] { 1, "Para ver", 1, 1 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8e445865-a24d-4543-a6c6-9443d048cdb9");

            migrationBuilder.DeleteData(
                table: "UtilFilme",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Utilizador",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f",
                column: "ConcurrencyStamp",
                value: "351de173-3830-47f5-9acd-ab28c44ccb94");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "g",
                column: "ConcurrencyStamp",
                value: "f7858e50-4bd5-42b1-8ec9-4fc1bd55a668");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "m",
                column: "ConcurrencyStamp",
                value: "68956601-ad9f-4894-a26f-af62938bb259");
        }
    }
}
