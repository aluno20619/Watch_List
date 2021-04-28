using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Watch_List.Data.Migrations
{
    public partial class bdInicial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Filme",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Titulo = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Ano = table.Column<int>(type: "int", maxLength: 4, nullable: false),
                    Resumo = table.Column<string>(type: "nvarchar(max)", maxLength: 10000, nullable: true),
                    Poster = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Trailer = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Filme", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Genero",
                columns: table => new
                {
                    Nome = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Genero", x => x.Nome);
                });

            migrationBuilder.CreateTable(
                name: "Pessoa",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Foto = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    DataNasc = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DataObi = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DataInic = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Nacionalidade = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    FilmeId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pessoa", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Pessoa_Filme_FilmeId",
                        column: x => x.FilmeId,
                        principalTable: "Filme",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "UtilFilme",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Estado = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    UtilIdFK = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FilFK = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UtilFilme", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UtilFilme_Filme_FilFK",
                        column: x => x.FilFK,
                        principalTable: "Filme",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "FilmeGenero",
                columns: table => new
                {
                    ListaDeFilmesId = table.Column<int>(type: "int", nullable: false),
                    ListaDeGenerosNome = table.Column<string>(type: "nvarchar(20)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FilmeGenero", x => new { x.ListaDeFilmesId, x.ListaDeGenerosNome });
                    table.ForeignKey(
                        name: "FK_FilmeGenero_Filme_ListaDeFilmesId",
                        column: x => x.ListaDeFilmesId,
                        principalTable: "Filme",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_FilmeGenero_Genero_ListaDeGenerosNome",
                        column: x => x.ListaDeGenerosNome,
                        principalTable: "Genero",
                        principalColumn: "Nome",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PessoaFilme",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Premio = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Profissao = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    MelhorFilmeFK = table.Column<int>(type: "int", nullable: false),
                    PessoaFK = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PessoaFilme", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PessoaFilme_Filme_MelhorFilmeFK",
                        column: x => x.MelhorFilmeFK,
                        principalTable: "Filme",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PessoaFilme_Pessoa_PessoaFK",
                        column: x => x.PessoaFK,
                        principalTable: "Pessoa",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Profissao",
                columns: table => new
                {
                    TarefaFK = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Profissao", x => x.TarefaFK);
                    table.ForeignKey(
                        name: "FK_Profissao_PessoaFilme_TarefaFK",
                        column: x => x.TarefaFK,
                        principalTable: "PessoaFilme",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_FilmeGenero_ListaDeGenerosNome",
                table: "FilmeGenero",
                column: "ListaDeGenerosNome");

            migrationBuilder.CreateIndex(
                name: "IX_Pessoa_FilmeId",
                table: "Pessoa",
                column: "FilmeId");

            migrationBuilder.CreateIndex(
                name: "IX_PessoaFilme_MelhorFilmeFK",
                table: "PessoaFilme",
                column: "MelhorFilmeFK");

            migrationBuilder.CreateIndex(
                name: "IX_PessoaFilme_PessoaFK",
                table: "PessoaFilme",
                column: "PessoaFK");

            migrationBuilder.CreateIndex(
                name: "IX_UtilFilme_FilFK",
                table: "UtilFilme",
                column: "FilFK");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FilmeGenero");

            migrationBuilder.DropTable(
                name: "Profissao");

            migrationBuilder.DropTable(
                name: "UtilFilme");

            migrationBuilder.DropTable(
                name: "Genero");

            migrationBuilder.DropTable(
                name: "PessoaFilme");

            migrationBuilder.DropTable(
                name: "Pessoa");

            migrationBuilder.DropTable(
                name: "Filme");
        }
    }
}
