using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Watch_List.Models
{
    /// <summary>
    /// Dados do utilizador do sistema
    /// </summary>
    public class Utilizador
    {
        public Utilizador(){
            ListaDeFilmes = new HashSet<UtilFilme>();
        }

        [Key]
        public int Id { get; set; }

        //***********************************************************************
        /// <summary>
        /// definição da chave forasteira (FK) que referencia a classe Identity User
        /// </summary>
        //***********************************************************************
        public string UtilIdFK { get; set; }

        /// <summary>
        /// Nome do utilizador
        /// </summary>
        [Required(ErrorMessage = "O {0} é de preenchimento obrigatório")]
        [StringLength(32, ErrorMessage = "O {0} não pode ter mais de {1} caracteres.")]
        [Display(Name = "Nome de utilizador")]
        public string Nome { get; set; }

        [StringLength(50, ErrorMessage = "O {0} não pode ter mais de {1} caracteres.")]
        [EmailAddress(ErrorMessage = "o {0} introduzido não é válido")]
        public string Email { get; set; }

        //***********************************************************************
        /// <summary>
        /// definição do atributo que será utilizado para exprimir o relacionamento com os objetos da classe Filme
        /// </summary>
        //***********************************************************************
        [Display(Name = "Lista de Filmes")]
        public ICollection<UtilFilme> ListaDeFilmes { get; set; }

    }
}
