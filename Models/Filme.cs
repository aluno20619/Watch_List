using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


/// <summary>
/// Destalhes dos filmes
/// </summary>
namespace Watch_List.Models
{
    public class Filme
    {
        public Filme()
        {
            ListaDeGeneros = new HashSet<Genero>();
            ListaDeElencos = new HashSet<Elenco>();
            ListaDeUtilizadores = new HashSet<Util_Fil>();
        }
        [Key]
        public int Id { get; set; }


        [Required(ErrorMessage = "É obrigatório preenchero  {0]")]
        [StringLength(100, ErrorMessage = "O {0} não pode ter mais de {1} caracteres.")]
        [Display(Name = "Título")]
        public string Titulo { get; set; }

        [MaxLength(4, ErrorMessage = "O {0} não pode ter mais de {1} caracteres.")]
        public int Ano { get; set; }

        [StringLength(10000, ErrorMessage = "O {0} não pode ter mais de {1} caracteres.")]
        public string Resumo { get; set; }

        [MaxLength(100, ErrorMessage = "O {0} não pode ter mais de {1} caracteres.")]
        [FileExtensions(ErrorMessage = "A extensão do {0} não é válida.")]
        public string Poster { get; set; }

        [MaxLength(150, ErrorMessage = "O {0} não pode ter mais de {1} caracteres.")]
        [Url(ErrorMessage = "O link do {0} não é válido.")]
        public string Trailer { get; set; }



        //***********************************************************************
        // definição do atributo que será utilizado para exprimir o relacionamento:

        // com os objetos da classe Genero
        [Display(Name = "Lista de géneros")]
        public ICollection<Genero> ListaDeGeneros { get; set; }

        // com os objetos da classe Elenco
        [Display(Name = "Lista de elenco")]
        public ICollection<Elenco> ListaDeElencos { get; set; }

        // com os objetos da classe intermédia Util_Fil
        [Display(Name = "Lista de utilizadores")]
        public ICollection<Util_Fil> ListaDeUtilizadores { get; set; }
    }
}
