using Microsoft.EntityFrameworkCore.Migrations;

namespace Watch_List.Data.Migrations
{
    public partial class bdCorrectProfissao : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Profissao_PessoaFilme_TarefaFK",
                table: "Profissao");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Profissao",
                table: "Profissao");

            migrationBuilder.DropColumn(
                name: "TarefaFK",
                table: "Profissao");

            migrationBuilder.DropColumn(
                name: "Profissao",
                table: "PessoaFilme");

            migrationBuilder.AddColumn<string>(
                name: "Tarefa",
                table: "Profissao",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "TarefaFK",
                table: "PessoaFilme",
                type: "nvarchar(100)",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Profissao",
                table: "Profissao",
                column: "Tarefa");

            migrationBuilder.CreateIndex(
                name: "IX_PessoaFilme_TarefaFK",
                table: "PessoaFilme",
                column: "TarefaFK");

            migrationBuilder.AddForeignKey(
                name: "FK_PessoaFilme_Profissao_TarefaFK",
                table: "PessoaFilme",
                column: "TarefaFK",
                principalTable: "Profissao",
                principalColumn: "Tarefa",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PessoaFilme_Profissao_TarefaFK",
                table: "PessoaFilme");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Profissao",
                table: "Profissao");

            migrationBuilder.DropIndex(
                name: "IX_PessoaFilme_TarefaFK",
                table: "PessoaFilme");

            migrationBuilder.DropColumn(
                name: "Tarefa",
                table: "Profissao");

            migrationBuilder.DropColumn(
                name: "TarefaFK",
                table: "PessoaFilme");

            migrationBuilder.AddColumn<int>(
                name: "TarefaFK",
                table: "Profissao",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Profissao",
                table: "PessoaFilme",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Profissao",
                table: "Profissao",
                column: "TarefaFK");

            migrationBuilder.AddForeignKey(
                name: "FK_Profissao_PessoaFilme_TarefaFK",
                table: "Profissao",
                column: "TarefaFK",
                principalTable: "PessoaFilme",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
