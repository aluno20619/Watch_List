using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Watch_List.Data.Migrations
{
    public partial class BDCorrect : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                table: "AspNetRoleClaims");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                table: "AspNetUserClaims");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                table: "AspNetUserLogins");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                table: "AspNetUserRoles");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                table: "AspNetUserRoles");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                table: "AspNetUserTokens");

            migrationBuilder.DropForeignKey(
                name: "FK_FilmeGenero_Filme_ListaDeFilmesId",
                table: "FilmeGenero");

            migrationBuilder.DropForeignKey(
                name: "FK_FilmeGenero_Genero_ListaDeGenerosId",
                table: "FilmeGenero");

            migrationBuilder.DropForeignKey(
                name: "FK_Pessoa_Filme_FilmeId",
                table: "Pessoa");

            migrationBuilder.DropForeignKey(
                name: "FK_PessoaFilme_Profissao_TarefaFK",
                table: "PessoaFilme");

            migrationBuilder.DropIndex(
                name: "IX_PessoaFilme_TarefaFK",
                table: "PessoaFilme");

            migrationBuilder.DropPrimaryKey(
                name: "PK_FilmeGenero",
                table: "FilmeGenero");

            migrationBuilder.DropColumn(
                name: "UtilIdFK",
                table: "UtilFilme");

            migrationBuilder.DropColumn(
                name: "TarefaFK",
                table: "PessoaFilme");

            migrationBuilder.RenameColumn(
                name: "FilmeId",
                table: "Pessoa",
                newName: "ProfissoesId");

            migrationBuilder.RenameIndex(
                name: "IX_Pessoa_FilmeId",
                table: "Pessoa",
                newName: "IX_Pessoa_ProfissoesId");

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
                name: "UtilFK",
                table: "UtilFilme",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "PessoaId",
                table: "Profissao",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ProfissaoFK",
                table: "Pessoa",
                type: "int",
                nullable: false,
                defaultValue: 0);

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

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "m", "cc1d8372-7dbf-470c-a159-34155da73ab7", "Membro", "MEMBRO" },
                    { "f", "a23513ab-28da-43cc-acdf-850b98e4634d", "Funcionario", "FUNCIONARIO" },
                    { "g", "908f09c6-ecef-42a2-90ec-0921b9559990", "Gestor", "GESTOR" }
                });

            migrationBuilder.InsertData(
                table: "Filme",
                columns: new[] { "Id", "Ano", "Poster", "Resumo", "Titulo", "Trailer" },
                values: new object[] { 1, 2004, "howlsmovingcastle.jpg", "Sophie encontra um feiticeiro chamado Howl a caminho de visitar a sua irmã Lettie. Ao regressar a casa, a Bruxa do Nada aparece e transforma a numa mulher de noventa anos de idade. Em busca de quebrar a maldição, Sophie sai de casa e parte para o campo para encontrar o castelo andante que pertence ao Howl.", "O Castelo Andante", "https://www.youtube.com/watch?v=iwROgK94zcM" });

            migrationBuilder.InsertData(
                table: "Genero",
                columns: new[] { "Id", "Nome" },
                values: new object[,]
                {
                    { 10, "SFI" },
                    { 9, "Terror" },
                    { 8, "Suspense" },
                    { 7, "Romance" },
                    { 6, "Fantasia" },
                    { 4, "Documentário" },
                    { 3, "Comédia" },
                    { 2, "Ação" },
                    { 1, "Aventura" },
                    { 5, "Drama" }
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
                    { 3, null, "Diretor" },
                    { 1, null, "Actor" },
                    { 2, null, "Realizador" },
                    { 4, null, "Produtor" }
                });

            migrationBuilder.InsertData(
                table: "FilmeGenero",
                columns: new[] { "Id", "FilmeFK", "GeneroFK" },
                values: new object[] { 1, 1, 6 });

            migrationBuilder.InsertData(
                table: "PessoaFilme",
                columns: new[] { "Id", "FilmeFK", "PessoaFK", "Premio" },
                values: new object[] { 1, 1, 1, null });

            migrationBuilder.CreateIndex(
                name: "IX_UtilFilme_UtilFK",
                table: "UtilFilme",
                column: "UtilFK");

            migrationBuilder.CreateIndex(
                name: "IX_Profissao_PessoaId",
                table: "Profissao",
                column: "PessoaId");

            migrationBuilder.CreateIndex(
                name: "IX_FilmeGenero_FilmeFK",
                table: "FilmeGenero",
                column: "FilmeFK");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId",
                principalTable: "AspNetRoles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                table: "AspNetUserClaims",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                table: "AspNetUserLogins",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId",
                principalTable: "AspNetRoles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                table: "AspNetUserRoles",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                table: "AspNetUserTokens",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

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

            migrationBuilder.AddForeignKey(
                name: "FK_Pessoa_Profissao_ProfissoesId",
                table: "Pessoa",
                column: "ProfissoesId",
                principalTable: "Profissao",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Profissao_Pessoa_PessoaId",
                table: "Profissao",
                column: "PessoaId",
                principalTable: "Pessoa",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

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
                name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                table: "AspNetRoleClaims");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                table: "AspNetUserClaims");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                table: "AspNetUserLogins");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                table: "AspNetUserRoles");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                table: "AspNetUserRoles");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                table: "AspNetUserTokens");

            migrationBuilder.DropForeignKey(
                name: "FK_FilmeGenero_Filme_FilmeFK",
                table: "FilmeGenero");

            migrationBuilder.DropForeignKey(
                name: "FK_FilmeGenero_Genero_GeneroFK",
                table: "FilmeGenero");

            migrationBuilder.DropForeignKey(
                name: "FK_Pessoa_Profissao_ProfissoesId",
                table: "Pessoa");

            migrationBuilder.DropForeignKey(
                name: "FK_Profissao_Pessoa_PessoaId",
                table: "Profissao");

            migrationBuilder.DropForeignKey(
                name: "FK_UtilFilme_Utilizador_UtilFK",
                table: "UtilFilme");

            migrationBuilder.DropTable(
                name: "Utilizador");

            migrationBuilder.DropIndex(
                name: "IX_UtilFilme_UtilFK",
                table: "UtilFilme");

            migrationBuilder.DropIndex(
                name: "IX_Profissao_PessoaId",
                table: "Profissao");

            migrationBuilder.DropPrimaryKey(
                name: "PK_FilmeGenero",
                table: "FilmeGenero");

            migrationBuilder.DropIndex(
                name: "IX_FilmeGenero_FilmeFK",
                table: "FilmeGenero");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "g");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "m");

            migrationBuilder.DeleteData(
                table: "FilmeGenero",
                keyColumn: "Id",
                keyColumnType: "int",
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

            migrationBuilder.DropColumn(
                name: "UtilFK",
                table: "UtilFilme");

            migrationBuilder.DropColumn(
                name: "PessoaId",
                table: "Profissao");

            migrationBuilder.DropColumn(
                name: "ProfissaoFK",
                table: "Pessoa");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "FilmeGenero");

            migrationBuilder.RenameColumn(
                name: "ProfissoesId",
                table: "Pessoa",
                newName: "FilmeId");

            migrationBuilder.RenameIndex(
                name: "IX_Pessoa_ProfissoesId",
                table: "Pessoa",
                newName: "IX_Pessoa_FilmeId");

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

            migrationBuilder.AddColumn<string>(
                name: "UtilIdFK",
                table: "UtilFilme",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TarefaFK",
                table: "PessoaFilme",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_FilmeGenero",
                table: "FilmeGenero",
                columns: new[] { "ListaDeFilmesId", "ListaDeGenerosId" });

            migrationBuilder.CreateIndex(
                name: "IX_PessoaFilme_TarefaFK",
                table: "PessoaFilme",
                column: "TarefaFK");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId",
                principalTable: "AspNetRoles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                table: "AspNetUserClaims",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                table: "AspNetUserLogins",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId",
                principalTable: "AspNetRoles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                table: "AspNetUserRoles",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                table: "AspNetUserTokens",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

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

            migrationBuilder.AddForeignKey(
                name: "FK_Pessoa_Filme_FilmeId",
                table: "Pessoa",
                column: "FilmeId",
                principalTable: "Filme",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PessoaFilme_Profissao_TarefaFK",
                table: "PessoaFilme",
                column: "TarefaFK",
                principalTable: "Profissao",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
