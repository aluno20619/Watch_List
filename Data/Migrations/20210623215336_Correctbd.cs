using Microsoft.EntityFrameworkCore.Migrations;

namespace Watch_List.Data.Migrations
{
    public partial class Correctbd : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UtilIdFK",
                table: "UtilFilme");

            migrationBuilder.AddColumn<int>(
                name: "UtilFK",
                table: "UtilFilme",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Utilizador",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UtilIdFK = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Nome = table.Column<string>(type: "nvarchar(32)", maxLength: 32, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Utilizador", x => x.Id);
                });

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f",
                column: "ConcurrencyStamp",
                value: "fb4bc6fc-3199-4006-84e9-cb21419dad33");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "g",
                column: "ConcurrencyStamp",
                value: "bc38b5d5-54af-48a7-be41-32dee7250d02");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "m",
                column: "ConcurrencyStamp",
                value: "87285f01-23b0-4d62-bd37-3c9c9c388cc8");

            migrationBuilder.CreateIndex(
                name: "IX_UtilFilme_UtilFK",
                table: "UtilFilme",
                column: "UtilFK");

            migrationBuilder.AddForeignKey(
                name: "FK_UtilFilme_Utilizador_UtilFK",
                table: "UtilFilme",
                column: "UtilFK",
                principalTable: "Utilizador",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UtilFilme_Utilizador_UtilFK",
                table: "UtilFilme");

            migrationBuilder.DropTable(
                name: "Utilizador");

            migrationBuilder.DropIndex(
                name: "IX_UtilFilme_UtilFK",
                table: "UtilFilme");

            migrationBuilder.DropColumn(
                name: "UtilFK",
                table: "UtilFilme");

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
                value: "acbcd90b-80d4-46cf-bf53-2f5b4d0ac2d0");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "g",
                column: "ConcurrencyStamp",
                value: "9ea4ff35-b575-415f-adc4-bea154d432db");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "m",
                column: "ConcurrencyStamp",
                value: "59f71292-50e8-4528-880f-4048615a531c");
        }
    }
}
