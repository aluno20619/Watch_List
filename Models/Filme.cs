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
            ListaDeGeneros = new HashSet<FilmeGenero>();
            ListaDePessoas = new HashSet<PessoaFilme>();
            ListaDeUtilizadores = new HashSet<UtilFilme>();
          
        }
        [Key]
        public int Id { get; set; }

        /// <summary>
        /// Título do filme
        /// </summary>
        [Required(ErrorMessage = "É obrigatório preencher o {0}")]
        [StringLength(100, ErrorMessage = "O {0} não pode ter mais de {1} caracteres.")]
        [Display(Name = "Título")]
        public string Titulo { get; set; }

        /// <summary>
        /// Ano em que o fime estreou ou irá estrear
        /// </summary>
        //[MaxLength(2022, ErrorMessage = "O {0} não pode ter mais de {1} caracteres.")]
        public int Ano { get; set; }

        /// <summary>
        /// Descrição do filme
        /// </summary>
        [StringLength(10000, ErrorMessage = "O {0} não pode ter mais de {1} caracteres.")]
        public string Resumo { get; set; }

        /// <summary>
        /// Extensão da imagem do filme
        /// </summary>
        [MaxLength(100, ErrorMessage = "O {0} não pode ter mais de {1} caracteres.")]
        [FileExtensions(ErrorMessage = "A extensão do {0} não é válida.")]
        public string Poster { get; set; }

        /// <summary>
        /// Extensão do video do trailer do filme
        /// </summary>
        [MaxLength(150, ErrorMessage = "O {0} não pode ter mais de {1} caracteres.")]
        [Url(ErrorMessage = "O link do {0} não é válido.")]
        public string Trailer { get; set; }


        

        //***********************************************************************
        /// <summary>
        /// definição do atributo que será utilizado para exprimir o relacionamento com os objetos da classe Genero
        /// </summary>
        //***********************************************************************
        [Display(Name = "Lista de Géneros")]
        public ICollection<FilmeGenero> ListaDeGeneros { get; set; }

        //***********************************************************************
        /// <summary>
        /// definição do atributo que será utilizado para exprimir o relacionamento com os objetos da classe Pessoa
        /// </summary>
        //***********************************************************************
        [Display(Name = "Lista de Pessoas")]
        public ICollection<PessoaFilme> ListaDePessoas { get; set; }

        //***********************************************************************
        /// <summary>
        /// definição do atributo que será utilizado para exprimir o relacionamento com os objetos da classe intermédia Util_Filme
        /// </summary>
        //***********************************************************************
        [Display(Name = "Lista de Utilizadores")]
        public ICollection<UtilFilme> ListaDeUtilizadores { get; set; }

       

    }
}
