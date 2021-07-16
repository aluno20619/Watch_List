using Microsoft.EntityFrameworkCore.Migrations;

namespace Watch_List.Data.Migrations
{
    public partial class AlterUtilFK : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UtilFilme_AspNetUsers_UtilFK",
                table: "UtilFilme");

            migrationBuilder.RenameColumn(
                name: "UtilFK",
                table: "UtilFilme",
                newName: "ApplicationUserId");

            migrationBuilder.RenameIndex(
                name: "IX_UtilFilme_UtilFK",
                table: "UtilFilme",
                newName: "IX_UtilFilme_ApplicationUserId");

            migrationBuilder.AddColumn<string>(
                name: "UtilIdFK",
                table: "UtilFilme",
                type: "nvarchar(max)",
                nullable: true);

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

            migrationBuilder.AddForeignKey(
                name: "FK_UtilFilme_AspNetUsers_ApplicationUserId",
                table: "UtilFilme",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UtilFilme_AspNetUsers_ApplicationUserId",
                table: "UtilFilme");

            migrationBuilder.DropColumn(
                name: "UtilIdFK",
                table: "UtilFilme");

            migrationBuilder.RenameColumn(
                name: "ApplicationUserId",
                table: "UtilFilme",
                newName: "UtilFK");

            migrationBuilder.RenameIndex(
                name: "IX_UtilFilme_ApplicationUserId",
                table: "UtilFilme",
                newName: "IX_UtilFilme_UtilFK");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f",
                column: "ConcurrencyStamp",
                value: "e5e5333f-c7a0-4694-a153-0c2135e8fc32");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "g",
                column: "ConcurrencyStamp",
                value: "b6be4718-4c4e-401b-8a81-43c6177dc08c");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "m",
                column: "ConcurrencyStamp",
                value: "32ecabc0-58f8-4f77-a73d-de80615aa03d");

            migrationBuilder.AddForeignKey(
                name: "FK_UtilFilme_AspNetUsers_UtilFK",
                table: "UtilFilme",
                column: "UtilFK",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
