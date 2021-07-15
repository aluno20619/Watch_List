using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using Watch_List.Models;

namespace Watch_List.Data
{
    public class ApplicationUser : IdentityUser
    {
        public ApplicationUser()
        {
            ListaDeFilmes = new HashSet<UtilFilme>();
        }
        /// <summary>
        /// recolhe a data de registo de um utilizador
        /// </summary>
        public DateTime DataRegisto { get; set; }

        //***********************************************************************
        /// <summary>
        /// definição do atributo que será utilizado para exprimir o relacionamento com os objetos da classe Filme
        /// </summary>
        //***********************************************************************
        [Display(Name = "Lista de Filmes")]
        public ICollection<UtilFilme> ListaDeFilmes { get; set; }


    }
    public class WatchListDbContext : IdentityDbContext<ApplicationUser>
    {

       
        public WatchListDbContext(DbContextOptions<WatchListDbContext> options)
            : base(options)
        { }
        //private void createUser(ModelBuilder modelBuilder) {

        //    ApplicationUser user = new ApplicationUser()
        //    {
        //        Id = "8e445865-a24d-4543-a6c6-9443d048cdb9", // primary key
        //        UserName = "gestor",
        //        NormalizedUserName = "GESTOR",
        //        Email = "gestor@gestor.com",

        //        DataRegisto = DateTime.Now,
        //        EmailConfirmed = true, // o email está confirmado
        //    };

        //    PasswordHasher<ApplicationUser> passwordHasher = new PasswordHasher<ApplicationUser>();
        //    user.PasswordHash = passwordHasher.HashPassword(user, "Aulas123!");
        //   // passwordHasher.VerifyHashedPassword(user," AQAAAAEAACcQAAAAEP9cJ8GrzjUcaCAp0tMXMieiXnVpDFZUW8 / nu44HjrDOb9 + XhZHRT8RoWncZAjKD1g ==", "Aulas123!");


        //    modelBuilder.Entity<ApplicationUser>().HasData(user);

        //}
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<IdentityRole>().HasData(
               new IdentityRole { Id = "m", Name = "Membro", NormalizedName = "MEMBRO" },
               new IdentityRole { Id = "f", Name = "Funcionario", NormalizedName = "FUNCIONARIO" },
               new IdentityRole { Id = "g", Name = "Gestor", NormalizedName = "GESTOR" }
           );

            /*this.createUser(modelBuilder)*/;




            /// <summary>
            ///  UmParaMuitos e MuitosParaMuitos restirar o Cascade 
            /// Source: https://stackoverflow.com/questions/34768976/specifying-on-delete-no-action-in-entity-framework-7
            /// </summary>
            foreach (var relationship in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
            {
                relationship.DeleteBehavior = DeleteBehavior.Restrict;
            }

            modelBuilder.Entity<Profissao>().HasData(
                new Profissao { Id = 1, Tarefa = "Actor"},
                new Profissao { Id = 2, Tarefa = "Realizador"},
                new Profissao { Id = 3, Tarefa = "Diretor"},
                new Profissao { Id = 4, Tarefa = "Produtor"}
            );

            modelBuilder.Entity<Pessoa>().HasData(
                new Pessoa { Id = 1, Nome = "Emily Kathleen Anne Mortimer", Foto = "emilymortimer.jpg", DataNasc = new DateTime(1971, 10, 6), DataInic = new DateTime(1995, 4, 26), Nacionalidade = "Inglês", ProfissaoFK = 1 },
                new Pessoa { Id = 2, Nome = "Lucrecia Martel", Foto = "lucreciamarte.jpg", DataNasc = new DateTime(1966, 12, 14), DataInic = new DateTime(1995, 5, 19), Nacionalidade = "Argentina", ProfissaoFK = 2 },
                new Pessoa { Id = 3, Nome = "Hayao Miyazaki", Foto = "hayaomiyazaki.jpg", DataNasc = new DateTime(1941, 1, 5), DataInic = new DateTime(1963, 12, 21), Nacionalidade = "Japonês", ProfissaoFK = 3 },
                new Pessoa { Id = 4, Nome = "Toshio Suzuki", Foto = "toshiosuzuki.jpg", DataNasc = new DateTime(1948, 8, 19), DataInic = new DateTime(1968,7,21), Nacionalidade = "Japonês", ProfissaoFK = 4 }
            );

            modelBuilder.Entity<Genero>().HasData(
                new Genero { Id = 1, Nome = "Aventura" },
                new Genero { Id = 2, Nome = "Ação" },
                new Genero { Id = 3, Nome = "Comédia" },
                new Genero { Id = 4, Nome = "Documentário" },
                new Genero { Id = 5, Nome = "Drama" },
                new Genero { Id = 6, Nome = "Fantasia" },
                new Genero { Id = 7, Nome = "Romance" },
                new Genero { Id = 8, Nome = "Suspense" },
                new Genero { Id = 9, Nome = "Terror" },
                new Genero { Id = 10, Nome = "SFI" },
                new Genero { Id = 11, Nome = "Animação" }
            );

            modelBuilder.Entity<Filme>().HasData(
               new Filme {Id = 1, Titulo = "O Castelo Andante", Ano = 2004, Poster = "howlsmovingcastle.jpg", Resumo = "Sophie encontra um feiticeiro chamado Howl a caminho de visitar a sua irmã Lettie. Ao regressar a casa, a Bruxa do Nada aparece e transforma a numa mulher de noventa anos de idade. Em busca de quebrar a maldição, Sophie sai de casa e parte para o campo para encontrar o castelo andante que pertence ao Howl.", Trailer = "https://www.youtube.com/watch?v=iwROgK94zcM" }
           );

          //  modelBuilder.Entity<Utilizador>().HasData(
          //   new Utilizador { Id = 1, Email = "gestor@gestor.com", Nome = "gestor", UtilIdFK = "8e445865-a24d-4543-a6c6-9443d048cdb9" }
          // );

          //  modelBuilder.Entity<UtilFilme>().HasData(
          //  new UtilFilme{ Id = 1, Estado = "Para ver", FilFK=1, UtilFK=1 }
          //);

            modelBuilder.Entity<FilmeGenero>().HasData(
              new FilmeGenero {Id = 1, FilmeFK = 1, GeneroFK = 6},
              new FilmeGenero { Id = 2, FilmeFK = 1, GeneroFK = 11 }
            );

            modelBuilder.Entity<PessoaFilme>().HasData(
             new PessoaFilme {Id = 1, FilmeFK = 1, PessoaFK = 1},
             new PessoaFilme { Id = 2, FilmeFK = 1, PessoaFK = 3 },
             new PessoaFilme { Id = 3, FilmeFK = 1, PessoaFK = 4 }
           );

        }

        /// <summary>
        /// Representa a BD
        /// </summary>

        public DbSet<Profissao> Profissao { get; set; }
        public DbSet<Pessoa> Pessoa { get; set; }  
        public DbSet<Genero> Genero { get; set; }
        public DbSet<Filme> Filme { get; set; }
        public DbSet<Utilizador> Utilizador { get; set; }
        public DbSet<UtilFilme> UtilFilme { get; set; }
        public DbSet<FilmeGenero> FilmeGenero { get; set; }
        public DbSet<PessoaFilme> PessoaFilme { get; set; }

    }
}
