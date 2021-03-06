using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Watch_List.Models
{
    /// <summary>
    /// Profissão desempenhada por cada elemento
    /// </summary>
    public class Profissao
    {
       
        [Key]
        public int Id { get; set; }

        /// <summary>
        /// Profissão desempenhada por uma pessoa 
        /// </summary>
        [StringLength(100, ErrorMessage = "A {0} não pode ter mais de {1} caracteres.")]
        [Display(Name = "Profissão")]
        public string Tarefa { get; set; }

        


       

    }
}
