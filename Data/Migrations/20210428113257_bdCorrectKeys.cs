using Microsoft.EntityFrameworkCore.Migrations;

namespace Watch_List.Data.Migrations
{
    public partial class bdCorrectKeys : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FilmeGenero_Genero_ListaDeGenerosNome",
                table: "FilmeGenero");

            migrationBuilder.DropForeignKey(
                name: "FK_PessoaFilme_Profissao_TarefaFK",
                table: "PessoaFilme");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Profissao",
                table: "Profissao");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Genero",
                table: "Genero");

            migrationBuilder.DropPrimaryKey(
                name: "PK_FilmeGenero",
                table: "FilmeGenero");

            migrationBuilder.DropIndex(
                name: "IX_FilmeGenero_ListaDeGenerosNome",
                table: "FilmeGenero");

            migrationBuilder.DropColumn(
                name: "ListaDeGenerosNome",
                table: "FilmeGenero");

            migrationBuilder.AlterColumn<string>(
                name: "Tarefa",
                table: "Profissao",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100);

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "Profissao",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AlterColumn<int>(
                name: "TarefaFK",
                table: "PessoaFilme",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "Genero",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<int>(
                name: "ListaDeGenerosId",
                table: "FilmeGenero",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Profissao",
                table: "Profissao",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Genero",
                table: "Genero",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_FilmeGenero",
                table: "FilmeGenero",
                columns: new[] { "ListaDeFilmesId", "ListaDeGenerosId" });

            migrationBuilder.CreateIndex(
                name: "IX_FilmeGenero_ListaDeGenerosId",
                table: "FilmeGenero",
                column: "ListaDeGenerosId");

            migrationBuilder.AddForeignKey(
                name: "FK_FilmeGenero_Genero_ListaDeGenerosId",
                table: "FilmeGenero",
                column: "ListaDeGenerosId",
                principalTable: "Genero",
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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FilmeGenero_Genero_ListaDeGenerosId",
                table: "FilmeGenero");

            migrationBuilder.DropForeignKey(
                name: "FK_PessoaFilme_Profissao_TarefaFK",
                table: "PessoaFilme");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Profissao",
                table: "Profissao");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Genero",
                table: "Genero");

            migrationBuilder.DropPrimaryKey(
                name: "PK_FilmeGenero",
                table: "FilmeGenero");

            migrationBuilder.DropIndex(
                name: "IX_FilmeGenero_ListaDeGenerosId",
                table: "FilmeGenero");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "Profissao");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "Genero");

            migrationBuilder.DropColumn(
                name: "ListaDeGenerosId",
                table: "FilmeGenero");

            migrationBuilder.AlterColumn<string>(
                name: "Tarefa",
                table: "Profissao",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "TarefaFK",
                table: "PessoaFilme",
                type: "nvarchar(100)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<string>(
                name: "ListaDeGenerosNome",
                table: "FilmeGenero",
                type: "nvarchar(20)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Profissao",
                table: "Profissao",
                column: "Tarefa");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Genero",
                table: "Genero",
                column: "Nome");

            migrationBuilder.AddPrimaryKey(
                name: "PK_FilmeGenero",
                table: "FilmeGenero",
                columns: new[] { "ListaDeFilmesId", "ListaDeGenerosNome" });

            migrationBuilder.CreateIndex(
                name: "IX_FilmeGenero_ListaDeGenerosNome",
                table: "FilmeGenero",
                column: "ListaDeGenerosNome");

            migrationBuilder.AddForeignKey(
                name: "FK_FilmeGenero_Genero_ListaDeGenerosNome",
                table: "FilmeGenero",
                column: "ListaDeGenerosNome",
                principalTable: "Genero",
                principalColumn: "Nome",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PessoaFilme_Profissao_TarefaFK",
                table: "PessoaFilme",
                column: "TarefaFK",
                principalTable: "Profissao",
                principalColumn: "Tarefa",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
