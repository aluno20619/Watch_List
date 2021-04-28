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
        //***********************************************************************
        /// <summary>
        /// definição da chave forasteira (FK) que referencia a classe PessoaFilme
        /// </summary>
        //***********************************************************************
        [ForeignKey(nameof(Tarefa))]
        [Display(Name = "Profissão")]
        [Key]
        public int TarefaFK { get; set; }

        public PessoaFilme Tarefa { get; set; }
    }
}
