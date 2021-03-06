using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

/// <summary>
/// Géneros dos filmes
/// </summary>
namespace Watch_List.Models
{

    public class Genero
    {

        public Genero()
        {

            ListaDeFilmes = new HashSet<FilmeGenero>();
        }

        [Key]
        public int Id { get; set; }

        /// <summary>
        /// Nome do género
        /// </summary>
        
        [Required(ErrorMessage = "O {0} é de preenchimento obrigatório")]
        [MaxLength(20, ErrorMessage = "O {0} não pode ter mais de {1} caracteres.")]
        [Display(Name = "Género")]
        public string Nome { get; set; }


        //***********************************************************************
        /// <summary>
        /// definição do atributo que será utilizado para exprimir o relacionamento com os objetos da classe Filme
        /// </summary>
        //***********************************************************************
        [Display(Name = "Lista de filmes")]
        public ICollection<FilmeGenero> ListaDeFilmes { get; set; }
    }
}
