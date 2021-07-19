using Microsoft.EntityFrameworkCore.Migrations;

namespace Watch_List.Data.Migrations
{
    public partial class SeedDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f",
                column: "ConcurrencyStamp",
                value: "80c9a01c-00fe-4493-a928-eeb80ecf1797");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "g",
                column: "ConcurrencyStamp",
                value: "d402be27-1726-4985-a3e5-03d96e3af125");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "m",
                column: "ConcurrencyStamp",
                value: "656135d5-02e5-4b9c-a6c4-e8dda30234ca");

            migrationBuilder.InsertData(
                table: "Filme",
                columns: new[] { "Id", "Ano", "Poster", "Resumo", "Titulo", "Trailer" },
                values: new object[,]
                {
                    { 2, 2002, "The_cat_returns.jpg", " Haru Yoshioka é uma estudante de 17 anos,  um dia ao voltar a casa com a sua amiga Haru acaba por salvar a vida de um gato que estava prestes a ser atropelado por um caminhão. Porém, ele não é um gato qualquer, pois, ele fala e apresenta-se como Lune, o príncipe do reino dos gatos. Agora o felino tem uma dívida com Haru. Durante a noite, o próprio Rei dos Gatos convida a ir para o seu reino.", "O Reino dos Gatos", "https://www.youtube.com/watch?v=Gp-H_YOcYTM" },
                    { 3, 2016, "deuses_do_egito.jpg", "Num Egipto antigo alternativo onde os deuses vivem entre os mortais, o rei Osíris é morto pelo seu irmão ciumento Set durante a coroação do filho de Osíris, Horus. Set toma o trono e declara que a humanidade deve pagar riquezas para passar para a vida após a morte. Despojado dos seus olhos, Hórus é exilado, enquanto o Egipto é levado aos seus joelhos.", "Deuses do Egito", "https://www.youtube.com/watch?v=ycYiwQiHh4o" },
                    { 4, 2009, "sherlock_holmes.jpg", "Em 1890 Londres, o detective privado Sherlock Holmes e o seu parceiro Dr. John Watson impediram o assassinato ritualístico de uma mulher por Lord Henry Blackwood, que matou cinco outras mulheres jovens de forma semelhante. O inspector Lestrade e a polícia prendem Blackwood. Três meses mais tarde, Watson está noivo de Mary Morstan e muda-se do 221B Baker Street; enquanto ele desfruta das suas aventuras em conjunto, Watson espera não ter de lidar com as excentricidades de Holmes. Entretanto, Blackwood, que afirma ter poderes sobrenaturais, foi condenado à morte e pede para ver Holmes, avisando-o de mais três mortes imparáveis que irão causar grandes mudanças no mundo. Blackwood é subsequentemente enforcado.", "Sherlock Holmes", "https://www.youtube.com/watch?v=J7nJksXDBWc" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Filme",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Filme",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Filme",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f",
                column: "ConcurrencyStamp",
                value: "989ad646-a184-4080-aceb-4e413b34dac8");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "g",
                column: "ConcurrencyStamp",
                value: "843a3c0c-1ba4-4fcf-af77-1db616736a5e");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "m",
                column: "ConcurrencyStamp",
                value: "9277ed8d-170d-4558-9406-5aa55f761505");
        }
    }
}
