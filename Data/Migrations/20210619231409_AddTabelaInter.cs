using Microsoft.EntityFrameworkCore.Migrations;

namespace Watch_List.Data.Migrations
{
    public partial class AddTabelaInter : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FilmeGenero_Filme_ListaDeFilmesId",
                table: "FilmeGenero");

            migrationBuilder.DropForeignKey(
                name: "FK_FilmeGenero_Genero_ListaDeGenerosId",
                table: "FilmeGenero");

            migrationBuilder.DropPrimaryKey(
                name: "PK_FilmeGenero",
                table: "FilmeGenero");

            migrationBuilder.RenameColumn(
                name: "ListaDeGenerosId",
                table: "FilmeGenero",
                newName: "GeneroFK");

            migrationBuilder.RenameColumn(
                name: "ListaDeFilmesId",
                table: "FilmeGenero",
                newName: "FilmeFK");

            migrationBuilder.RenameIndex(
                name: "IX_FilmeGenero_ListaDeGenerosId",
                table: "FilmeGenero",
                newName: "IX_FilmeGenero_GeneroFK");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "FilmeGenero",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_FilmeGenero",
                table: "FilmeGenero",
                column: "Id");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f",
                column: "ConcurrencyStamp",
                value: "ae4dfeb8-4d1a-4b9d-ad6d-9600b8adf755");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "g",
                column: "ConcurrencyStamp",
                value: "0fd1e510-d4b7-423d-8cb8-8d4dc51a6dbf");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "m",
                column: "ConcurrencyStamp",
                value: "32ee2f85-4026-4411-9b1b-2d2112755c1e");

            migrationBuilder.CreateIndex(
                name: "IX_FilmeGenero_FilmeFK",
                table: "FilmeGenero",
                column: "FilmeFK");

            migrationBuilder.AddForeignKey(
                name: "FK_FilmeGenero_Filme_FilmeFK",
                table: "FilmeGenero",
                column: "FilmeFK",
                principalTable: "Filme",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_FilmeGenero_Genero_GeneroFK",
                table: "FilmeGenero",
                column: "GeneroFK",
                principalTable: "Genero",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FilmeGenero_Filme_FilmeFK",
                table: "FilmeGenero");

            migrationBuilder.DropForeignKey(
                name: "FK_FilmeGenero_Genero_GeneroFK",
                table: "FilmeGenero");

            migrationBuilder.DropPrimaryKey(
                name: "PK_FilmeGenero",
                table: "FilmeGenero");

            migrationBuilder.DropIndex(
                name: "IX_FilmeGenero_FilmeFK",
                table: "FilmeGenero");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "FilmeGenero");

            migrationBuilder.RenameColumn(
                name: "GeneroFK",
                table: "FilmeGenero",
                newName: "ListaDeGenerosId");

            migrationBuilder.RenameColumn(
                name: "FilmeFK",
                table: "FilmeGenero",
                newName: "ListaDeFilmesId");

            migrationBuilder.RenameIndex(
                name: "IX_FilmeGenero_GeneroFK",
                table: "FilmeGenero",
                newName: "IX_FilmeGenero_ListaDeGenerosId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_FilmeGenero",
                table: "FilmeGenero",
                columns: new[] { "ListaDeFilmesId", "ListaDeGenerosId" });

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f",
                column: "ConcurrencyStamp",
                value: "9d473508-8ae9-43bc-86fe-7a8380210d50");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "g",
                column: "ConcurrencyStamp",
                value: "5875963b-6f7e-44b3-9443-77a18ffd1527");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "m",
                column: "ConcurrencyStamp",
                value: "656ac837-c164-480e-9579-7e2776dccfd4");

            migrationBuilder.AddForeignKey(
                name: "FK_FilmeGenero_Filme_ListaDeFilmesId",
                table: "FilmeGenero",
                column: "ListaDeFilmesId",
                principalTable: "Filme",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_FilmeGenero_Genero_ListaDeGenerosId",
                table: "FilmeGenero",
                column: "ListaDeGenerosId",
                principalTable: "Genero",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
