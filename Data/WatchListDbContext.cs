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
       

        /// <summary>
        /// recolhe a data de registo de um utilizador
        /// </summary>
        public DateTime DataRegisto { get; set; }

       
    }

    public class WatchListDbContext : IdentityDbContext<ApplicationUser>
    {
        public WatchListDbContext(DbContextOptions<WatchListDbContext> options)
            : base(options)
        { }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
           
            modelBuilder.Entity<IdentityRole>().HasData(
               new IdentityRole { Id = "m", Name = "Membro", NormalizedName = "MEMBRO" },
               new IdentityRole { Id = "f", Name = "Funcionario", NormalizedName = "FUNCIONARIO" },
               new IdentityRole { Id = "g", Name = "Gestor", NormalizedName = "GESTOR" }
           );

           
            

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
                new Pessoa { Id = 1, Nome = "Emily Kathleen Anne Mortimer", Foto = "emilymortimer.jpg", DataNasc = new DateTime(1971, 10, 6), DataInic = new DateTime(1995, 4, 26), Nacionalidade = "Reino Unido", ProfissaoFK = 1 }
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
                new Genero { Id = 10, Nome = "SFI" }
            );

            modelBuilder.Entity<Filme>().HasData(
               new Filme {Id = 1, Titulo = "O Castelo Andante", Ano = 2004, Poster = "howlsmovingcastle.jpg", Resumo = "Sophie encontra um feiticeiro chamado Howl a caminho de visitar a sua irmã Lettie. Ao regressar a casa, a Bruxa do Nada aparece e transforma a numa mulher de noventa anos de idade. Em busca de quebrar a maldição, Sophie sai de casa e parte para o campo para encontrar o castelo andante que pertence ao Howl.", Trailer = "https://www.youtube.com/watch?v=iwROgK94zcM" }
           );

            modelBuilder.Entity<FilmeGenero>().HasData(
              new FilmeGenero {Id = 1, FilmeFK = 1, GeneroFK = 6}
            );

            modelBuilder.Entity<PessoaFilme>().HasData(
             new PessoaFilme {Id = 1, FilmeFK = 1, PessoaFK = 1}
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
