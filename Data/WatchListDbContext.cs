using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Watch_List.Models;

namespace Watch_List.Data
{
    public class WatchListDbContext : IdentityDbContext
    {
        public WatchListDbContext(DbContextOptions<WatchListDbContext> options)
            : base(options)
        { }
        
        public DbSet<PessoaFilme> PessoaFilme { get; set; }
        public DbSet<Pessoa> Pessoa { get; set; }
        public DbSet<Filme> Filme { get; set; }
        public DbSet<Genero> Genero { get; set; }
        public DbSet<Profissao> Profissao { get; set; }
        public DbSet<UtilFilme> UtilFilme { get; set; }




        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            foreach (var relationship in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
            {
                relationship.DeleteBehavior = DeleteBehavior.Restrict;
            }
            /*
            modelBuilder.Remove<PluralizingTableNameConvention>();  // impede a EF de 'pluralizar' os nomes das tabelas
             modelBuilder.Remove<OneToManyCascadeDeleteConvention>();  // força a que a chave forasteira não tenha a propriedade 'on delete cascade'
             modelBuilder.Entity.Remove<ManyToManyCascadeDeleteConvention>();  // força a que a chave forasteira não tenha a propriedade 'on delete cascade'
            */
            base.OnModelCreating(modelBuilder);

        }
    }
}
