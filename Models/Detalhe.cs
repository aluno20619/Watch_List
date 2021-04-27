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
    public class Detalhe
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "Data de Nascimento")]
        public DateTime DataNasc { get; set; }

        [Display(Name = "Data de Óbito")]
        public DateTime DataObi { get; set; }

        [Display(Name = "Data de ínicio de carreira")]
        public DateTime DataInic { get; set; }

        [MaxLength(50, ErrorMessage = "O {0} não pode ter mais de {1} caracteres.")]
        [Display(Name = "Prémio")]
        public string Premio { get; set; }



        //***********************************************************************
        // definição da chave forasteira (FK) que referencia a classe Filme
        //***********************************************************************
        [ForeignKey(nameof(MelhorFil))]
        [Display(Name = "Melhor Filme")]
        public int MelhorFilFK { get; set; }
        public Filme MelhorFil { get; set; }


        //***********************************************************************
        // definição da chave forasteira (FK) que referencia a classe Elenco
        //***********************************************************************
        [ForeignKey(nameof(ElencoId))]
        [Display(Name = "Elenco do Filme")]
        public int ElencoFK { get; set; }
        public Elenco ElencoId { get; set; }


    }
}
