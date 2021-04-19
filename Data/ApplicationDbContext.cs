using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Watch_List.Models;

namespace Watch_List.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {}
        public DbSet<Util_Fil> Util_Fil { get; set; }
        public DbSet<Detalhe> Detalhe { get; set; }
        public DbSet<Elenco> Elenco { get; set; }
        public DbSet<Filme> Filme { get; set; }
        public DbSet<Genero> Genero { get; set; }



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
