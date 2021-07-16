﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Watch_List.Data;

namespace Watch_List.Data.Migrations
{
    [DbContext(typeof(WatchListDbContext))]
    [Migration("20210715201211_AlterUtilFK")]
    partial class AlterUtilFK
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.8")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles");

                    b.HasData(
                        new
                        {
                            Id = "m",
                            ConcurrencyStamp = "9277ed8d-170d-4558-9406-5aa55f761505",
                            Name = "Membro",
                            NormalizedName = "MEMBRO"
                        },
                        new
                        {
                            Id = "f",
                            ConcurrencyStamp = "989ad646-a184-4080-aceb-4e413b34dac8",
                            Name = "Funcionario",
                            NormalizedName = "FUNCIONARIO"
                        },
                        new
                        {
                            Id = "g",
                            ConcurrencyStamp = "843a3c0c-1ba4-4fcf-af77-1db616736a5e",
                            Name = "Gestor",
                            NormalizedName = "GESTOR"
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("ProviderKey")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("Name")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("Watch_List.Data.ApplicationUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("DataRegisto")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers");
                });

            modelBuilder.Entity("Watch_List.Models.Filme", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Ano")
                        .HasMaxLength(4)
                        .HasColumnType("int");

                    b.Property<string>("Poster")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Resumo")
                        .HasMaxLength(10000)
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Titulo")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Trailer")
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.HasKey("Id");

                    b.ToTable("Filme");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Ano = 2004,
                            Poster = "howlsmovingcastle.jpg",
                            Resumo = "Sophie encontra um feiticeiro chamado Howl a caminho de visitar a sua irmã Lettie. Ao regressar a casa, a Bruxa do Nada aparece e transforma a numa mulher de noventa anos de idade. Em busca de quebrar a maldição, Sophie sai de casa e parte para o campo para encontrar o castelo andante que pertence ao Howl.",
                            Titulo = "O Castelo Andante",
                            Trailer = "https://www.youtube.com/watch?v=iwROgK94zcM"
                        });
                });

            modelBuilder.Entity("Watch_List.Models.FilmeGenero", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("FilmeFK")
                        .HasColumnType("int");

                    b.Property<int>("GeneroFK")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("FilmeFK");

                    b.HasIndex("GeneroFK");

                    b.ToTable("FilmeGenero");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            FilmeFK = 1,
                            GeneroFK = 6
                        },
                        new
                        {
                            Id = 2,
                            FilmeFK = 1,
                            GeneroFK = 11
                        });
                });

            modelBuilder.Entity("Watch_List.Models.Genero", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.HasKey("Id");

                    b.ToTable("Genero");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Nome = "Aventura"
                        },
                        new
                        {
                            Id = 2,
                            Nome = "Ação"
                        },
                        new
                        {
                            Id = 3,
                            Nome = "Comédia"
                        },
                        new
                        {
                            Id = 4,
                            Nome = "Documentário"
                        },
                        new
                        {
                            Id = 5,
                            Nome = "Drama"
                        },
                        new
                        {
                            Id = 6,
                            Nome = "Fantasia"
                        },
                        new
                        {
                            Id = 7,
                            Nome = "Romance"
                        },
                        new
                        {
                            Id = 8,
                            Nome = "Suspense"
                        },
                        new
                        {
                            Id = 9,
                            Nome = "Terror"
                        },
                        new
                        {
                            Id = 10,
                            Nome = "SFI"
                        },
                        new
                        {
                            Id = 11,
                            Nome = "Animação"
                        });
                });

            modelBuilder.Entity("Watch_List.Models.Pessoa", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime?>("DataInic")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DataNasc")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DataObi")
                        .HasColumnType("datetime2");

                    b.Property<string>("Foto")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Nacionalidade")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("ProfissaoFK")
                        .HasColumnType("int");

                    b.Property<int?>("ProfissoesId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ProfissoesId");

                    b.ToTable("Pessoa");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            DataInic = new DateTime(1995, 4, 26, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            DataNasc = new DateTime(1971, 10, 6, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Foto = "emilymortimer.jpg",
                            Nacionalidade = "Inglês",
                            Nome = "Emily Kathleen Anne Mortimer",
                            ProfissaoFK = 1
                        },
                        new
                        {
                            Id = 2,
                            DataInic = new DateTime(1995, 5, 19, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            DataNasc = new DateTime(1966, 12, 14, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Foto = "lucreciamarte.jpg",
                            Nacionalidade = "Argentina",
                            Nome = "Lucrecia Martel",
                            ProfissaoFK = 2
                        },
                        new
                        {
                            Id = 3,
                            DataInic = new DateTime(1963, 12, 21, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            DataNasc = new DateTime(1941, 1, 5, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Foto = "hayaomiyazaki.jpg",
                            Nacionalidade = "Japonês",
                            Nome = "Hayao Miyazaki",
                            ProfissaoFK = 3
                        },
                        new
                        {
                            Id = 4,
                            DataInic = new DateTime(1968, 7, 21, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            DataNasc = new DateTime(1948, 8, 19, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Foto = "toshiosuzuki.jpg",
                            Nacionalidade = "Japonês",
                            Nome = "Toshio Suzuki",
                            ProfissaoFK = 4
                        });
                });

            modelBuilder.Entity("Watch_List.Models.PessoaFilme", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("FilmeFK")
                        .HasColumnType("int");

                    b.Property<int>("PessoaFK")
                        .HasColumnType("int");

                    b.Property<string>("Premio")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.HasIndex("FilmeFK");

                    b.HasIndex("PessoaFK");

                    b.ToTable("PessoaFilme");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            FilmeFK = 1,
                            PessoaFK = 1
                        },
                        new
                        {
                            Id = 2,
                            FilmeFK = 1,
                            PessoaFK = 3
                        },
                        new
                        {
                            Id = 3,
                            FilmeFK = 1,
                            PessoaFK = 4
                        });
                });

            modelBuilder.Entity("Watch_List.Models.Profissao", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("PessoaId")
                        .HasColumnType("int");

                    b.Property<string>("Tarefa")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.HasIndex("PessoaId");

                    b.ToTable("Profissao");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Tarefa = "Actor"
                        },
                        new
                        {
                            Id = 2,
                            Tarefa = "Realizador"
                        },
                        new
                        {
                            Id = 3,
                            Tarefa = "Diretor"
                        },
                        new
                        {
                            Id = 4,
                            Tarefa = "Produtor"
                        });
                });

            modelBuilder.Entity("Watch_List.Models.UtilFilme", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ApplicationUserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Estado")
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.Property<int>("FilFK")
                        .HasColumnType("int");

                    b.Property<string>("UtilIdFK")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("UtilizadorId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ApplicationUserId");

                    b.HasIndex("FilFK");

                    b.HasIndex("UtilizadorId");

                    b.ToTable("UtilFilme");
                });

            modelBuilder.Entity("Watch_List.Models.Utilizador", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Email")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(32)
                        .HasColumnType("nvarchar(32)");

                    b.Property<string>("UtilIdFK")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Utilizador");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("Watch_List.Data.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("Watch_List.Data.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("Watch_List.Data.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("Watch_List.Data.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();
                });

            modelBuilder.Entity("Watch_List.Models.FilmeGenero", b =>
                {
                    b.HasOne("Watch_List.Models.Filme", "Filme")
                        .WithMany("ListaDeGeneros")
                        .HasForeignKey("FilmeFK")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("Watch_List.Models.Genero", "Genero")
                        .WithMany("ListaDeFilmes")
                        .HasForeignKey("GeneroFK")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Filme");

                    b.Navigation("Genero");
                });

            modelBuilder.Entity("Watch_List.Models.Pessoa", b =>
                {
                    b.HasOne("Watch_List.Models.Profissao", "Profissoes")
                        .WithMany()
                        .HasForeignKey("ProfissoesId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.Navigation("Profissoes");
                });

            modelBuilder.Entity("Watch_List.Models.PessoaFilme", b =>
                {
                    b.HasOne("Watch_List.Models.Filme", "Filme")
                        .WithMany("ListaDePessoas")
                        .HasForeignKey("FilmeFK")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("Watch_List.Models.Pessoa", "Pessoa")
                        .WithMany("ListaDeFilmes")
                        .HasForeignKey("PessoaFK")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Filme");

                    b.Navigation("Pessoa");
                });

            modelBuilder.Entity("Watch_List.Models.Profissao", b =>
                {
                    b.HasOne("Watch_List.Models.Pessoa", null)
                        .WithMany("ListaDeProfissoes")
                        .HasForeignKey("PessoaId")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("Watch_List.Models.UtilFilme", b =>
                {
                    b.HasOne("Watch_List.Data.ApplicationUser", null)
                        .WithMany("ListaDeFilmes")
                        .HasForeignKey("ApplicationUserId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("Watch_List.Models.Filme", "Filme")
                        .WithMany("ListaDeUtilizadores")
                        .HasForeignKey("FilFK")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("Watch_List.Models.Utilizador", null)
                        .WithMany("ListaDeFilmes")
                        .HasForeignKey("UtilizadorId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.Navigation("Filme");
                });

            modelBuilder.Entity("Watch_List.Data.ApplicationUser", b =>
                {
                    b.Navigation("ListaDeFilmes");
                });

            modelBuilder.Entity("Watch_List.Models.Filme", b =>
                {
                    b.Navigation("ListaDeGeneros");

                    b.Navigation("ListaDePessoas");

                    b.Navigation("ListaDeUtilizadores");
                });

            modelBuilder.Entity("Watch_List.Models.Genero", b =>
                {
                    b.Navigation("ListaDeFilmes");
                });

            modelBuilder.Entity("Watch_List.Models.Pessoa", b =>
                {
                    b.Navigation("ListaDeFilmes");

                    b.Navigation("ListaDeProfissoes");
                });

            modelBuilder.Entity("Watch_List.Models.Utilizador", b =>
                {
                    b.Navigation("ListaDeFilmes");
                });
#pragma warning restore 612, 618
        }
    }
}