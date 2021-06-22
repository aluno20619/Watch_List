using Microsoft.EntityFrameworkCore.Migrations;

namespace Watch_List.Data.Migrations
{
    public partial class Utilizadores : Migration
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
                value: "7333b206-e8a2-468e-b6a7-75de2fd4c157");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "g",
                column: "ConcurrencyStamp",
                value: "a3c9ffe3-787a-4fbe-abd9-c5e087af68a3");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "m",
                column: "ConcurrencyStamp",
                value: "2c51d060-639e-4cba-81b0-1b5d3f1c44fd");

            migrationBuilder.InsertData(
                table: "Utilizador",
                columns: new[] { "Id", "Email", "Nome", "UtilIdFK" },
                values: new object[,]
                {
                    { 1, "manuelbastos1234@gmail.com", "ManuelBastos", "GESTOR" },
                    { 2, "mariaandrade89@sapo.pt", "MariaAndrade", "FUNCIONARIO" },
                    { 3, "Carolinasilva34@gmail.com", "CarolinaSilva", "FUNCIONARIO" },
                    { 4, "granady123@gmail.com", "granady123", "MEMBRO" }
                });

            migrationBuilder.InsertData(
                table: "UtilFilme",
                columns: new[] { "Id", "Estado", "FilFK", "UtilFK" },
                values: new object[] { 1, "Para ver", 1, 4 });

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

            migrationBuilder.DeleteData(
                table: "UtilFilme",
                keyColumn: "Id",
                keyValue: 1);

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
