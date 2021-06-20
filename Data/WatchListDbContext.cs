using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Watch_List.Models;

namespace Watch_List.Data
{
    //public class ApplicationUser : IdentityUser
    //{

    //    /// <summary>
    //    /// recolhe a data de registo de um utilizador
    //    /// </summary>
    //    public DateTime DataRegisto { get; set; }
    //}

    public class WatchListDbContext : IdentityDbContext
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
        }

        /// <summary>
        /// Representa a BD
        /// </summary>
        
        public DbSet<Pessoa> Pessoa { get; set; }
        public DbSet<Filme> Filme { get; set; }
        public DbSet<Genero> Genero { get; set; }
        public DbSet<Profissao> Profissao { get; set; }
        public DbSet<UtilFilme> UtilFilme { get; set; }
        public DbSet<FilmeGenero> FilmeGenero { get; set; }
        public DbSet<PessoaFilme> PessoaFilme { get; set; }

    }
}
