using Microsoft.EntityFrameworkCore.Migrations;

namespace Watch_List.Data.Migrations
{
    public partial class CorrecaoBD : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pessoa_Filme_FilmeId",
                table: "Pessoa");

            migrationBuilder.DropForeignKey(
                name: "FK_PessoaFilme_Profissao_TarefaFK",
                table: "PessoaFilme");

            migrationBuilder.DropIndex(
                name: "IX_PessoaFilme_TarefaFK",
                table: "PessoaFilme");

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

            migrationBuilder.AddColumn<int>(
                name: "PessoaId",
                table: "Profissao",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ProfissaoId",
                table: "PessoaFilme",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ProfissaoFK",
                table: "Pessoa",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Profissao_PessoaId",
                table: "Profissao",
                column: "PessoaId");

            migrationBuilder.CreateIndex(
                name: "IX_PessoaFilme_ProfissaoId",
                table: "PessoaFilme",
                column: "ProfissaoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Pessoa_Profissao_ProfissoesId",
                table: "Pessoa",
                column: "ProfissoesId",
                principalTable: "Profissao",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PessoaFilme_Profissao_ProfissaoId",
                table: "PessoaFilme",
                column: "ProfissaoId",
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
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pessoa_Profissao_ProfissoesId",
                table: "Pessoa");

            migrationBuilder.DropForeignKey(
                name: "FK_PessoaFilme_Profissao_ProfissaoId",
                table: "PessoaFilme");

            migrationBuilder.DropForeignKey(
                name: "FK_Profissao_Pessoa_PessoaId",
                table: "Profissao");

            migrationBuilder.DropIndex(
                name: "IX_Profissao_PessoaId",
                table: "Profissao");

            migrationBuilder.DropIndex(
                name: "IX_PessoaFilme_ProfissaoId",
                table: "PessoaFilme");

            migrationBuilder.DropColumn(
                name: "PessoaId",
                table: "Profissao");

            migrationBuilder.DropColumn(
                name: "ProfissaoId",
                table: "PessoaFilme");

            migrationBuilder.DropColumn(
                name: "ProfissaoFK",
                table: "Pessoa");

            migrationBuilder.RenameColumn(
                name: "ProfissoesId",
                table: "Pessoa",
                newName: "FilmeId");

            migrationBuilder.RenameIndex(
                name: "IX_Pessoa_ProfissoesId",
                table: "Pessoa",
                newName: "IX_Pessoa_FilmeId");

            migrationBuilder.AddColumn<int>(
                name: "TarefaFK",
                table: "PessoaFilme",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_PessoaFilme_TarefaFK",
                table: "PessoaFilme",
                column: "TarefaFK");

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
