using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Watch_List.Data.Migrations
{
    public partial class SeedBD : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.InsertData(
                table: "Filme",
                columns: new[] { "Id", "Ano", "Poster", "Resumo", "Titulo", "Trailer" },
                values: new object[] { 1, 2004, "howlsmovingcastle.jpg", "Sophie encontra um feiticeiro chamado Howl a caminho de visitar a sua irmã Lettie. Ao regressar a casa, a Bruxa do Nada aparece e transforma a numa mulher de noventa anos de idade. Em busca de quebrar a maldição, Sophie sai de casa e parte para o campo para encontrar o castelo andante que pertence ao Howl.", "O Castelo Andante", "https://www.youtube.com/watch?v=iwROgK94zcM" });

            migrationBuilder.InsertData(
                table: "Genero",
                columns: new[] { "Id", "Nome" },
                values: new object[,]
                {
                    { 4, "Documentário" },
                    { 5, "Drama" },
                    { 6, "Fantasia" },
                    { 7, "Romance" },
                    { 8, "Suspense" },
                    { 2, "Ação" },
                    { 10, "SFI" },
                    { 1, "Aventura" },
                    { 3, "Comédia" },
                    { 9, "Terror" }
                });

            migrationBuilder.InsertData(
                table: "Pessoa",
                columns: new[] { "Id", "DataInic", "DataNasc", "DataObi", "Foto", "Nacionalidade", "Nome", "ProfissaoFK", "ProfissoesId" },
                values: new object[] { 1, new DateTime(1995, 4, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1971, 10, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "emilymortimer.jpg", "Reino Unido", "Emily Kathleen Anne Mortimer", 1, null });

            migrationBuilder.InsertData(
                table: "Profissao",
                columns: new[] { "Id", "PessoaId", "Tarefa" },
                values: new object[,]
                {
                    { 1, null, "Actor" },
                    { 2, null, "Realizador" },
                    { 3, null, "Diretor" },
                    { 4, null, "Produtor" }
                });

            migrationBuilder.InsertData(
                table: "FilmeGenero",
                columns: new[] { "Id", "FilmeFK", "GeneroFK" },
                values: new object[] { 1, 1, 6 });

            migrationBuilder.InsertData(
                table: "PessoaFilme",
                columns: new[] { "Id", "FilmeFK", "PessoaFK", "Premio", "ProfissaoId" },
                values: new object[] { 1, 1, 1, null, null });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "FilmeGenero",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Genero",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Genero",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Genero",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Genero",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Genero",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Genero",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Genero",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Genero",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Genero",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "PessoaFilme",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Profissao",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Profissao",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Profissao",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Profissao",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Filme",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Genero",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Pessoa",
                keyColumn: "Id",
                keyValue: 1);

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
        }
    }
}
