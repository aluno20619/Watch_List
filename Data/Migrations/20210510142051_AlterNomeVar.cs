using Microsoft.EntityFrameworkCore.Migrations;

namespace Watch_List.Data.Migrations
{
    public partial class AlterNomeVar : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PessoaFilme_Profissao_TarefaFK",
                table: "PessoaFilme");

            migrationBuilder.RenameColumn(
                name: "TarefaFK",
                table: "PessoaFilme",
                newName: "ProfissaoFK");

            migrationBuilder.RenameIndex(
                name: "IX_PessoaFilme_TarefaFK",
                table: "PessoaFilme",
                newName: "IX_PessoaFilme_ProfissaoFK");

            migrationBuilder.AddForeignKey(
                name: "FK_PessoaFilme_Profissao_ProfissaoFK",
                table: "PessoaFilme",
                column: "ProfissaoFK",
                principalTable: "Profissao",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PessoaFilme_Profissao_ProfissaoFK",
                table: "PessoaFilme");

            migrationBuilder.RenameColumn(
                name: "ProfissaoFK",
                table: "PessoaFilme",
                newName: "TarefaFK");

            migrationBuilder.RenameIndex(
                name: "IX_PessoaFilme_ProfissaoFK",
                table: "PessoaFilme",
                newName: "IX_PessoaFilme_TarefaFK");

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
