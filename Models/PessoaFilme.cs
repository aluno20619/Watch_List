using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Watch_List.Models
{
    /// <summary>
    /// Detalhes do Elenco
    /// </summary>
    public class PessoaFilme
    {
        [Key]
        public int Id { get; set; }

       
        /// <summary>
        /// Prémios ganhos pelas pessoas em certos filmes
        /// </summary>
        [MaxLength(50, ErrorMessage = "O {0} não pode ter mais de {1} caracteres.")]
        [Display(Name = "Prémio")]
        public string Premio { get; set; }


        //***********************************************************************
        /// <summary>
        /// definição da chave forasteira (FK) que referencia a classe Filme
        /// </summary>
        //***********************************************************************
        [ForeignKey(nameof(Filme))]
        [Display(Name = "Filme")]
        public int FilmeFK { get; set; }
        public Filme Filme { get; set; }

        //***********************************************************************
        /// <summary>
        /// definição da chave forasteira (FK) que referencia a classe Pessoa
        /// </summary>
        //***********************************************************************
        [ForeignKey(nameof(Pessoa))]
        [Display(Name = "Pessoa")]
        public int PessoaFK { get; set; }
        public Pessoa Pessoa { get; set; }


    }
}
