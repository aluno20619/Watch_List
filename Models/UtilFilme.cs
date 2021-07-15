using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

/// <summary>
/// Tabela de relacionamento intermédio de Identity User e Filmes
/// </summary>
namespace Watch_List.Models
{
    public class UtilFilme
    {

        [Key]
        public int Id { get; set; }
        
        /// <summary>
        /// O estado do filme (visto ou para ver)
        /// </summary>
        [MaxLength(10, ErrorMessage = "O {0} não pode ter mais de {1} caracteres.")]
        public string Estado { get; set; }

       

        //***********************************************************************
        /// <summary>
        /// definição da chave forasteira (FK) que referencia a classe ApplicationUser
        /// </summary>
        /// //***********************************************************************
        [ForeignKey(nameof(Utilizador))]
        [Display(Name = "Utilizador")]
        public string  UtilFK { get; set; }
        public Watch_List.Data.ApplicationUser Utilizador { get; set; }

        //***********************************************************************
        /// <summary>
        /// definição da chave forasteira (FK) que referencia a classe Filme
        /// </summary>
        /// //***********************************************************************
        [ForeignKey(nameof(Filme))]
        [Display(Name = "Filmes")]
        public int FilFK { get; set; }
        public Filme Filme { get; set; }


    }
}
