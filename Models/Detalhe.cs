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

        public DateTime DataNasc { get; set; }


        public DateTime DataObi { get; set; }

        public DateTime DataInic { get; set; }

        [MaxLength(50, ErrorMessage = "O {0} não pode ter mais de {1} caracteres."))]
        public string Premio { get; set; }



	  //***********************************************************************
      // definição da chave forasteira (FK) que referencia a classe Filme
      //***********************************************************************
       [ForeignKey(nameof(MelhorFil))]
        public int MelhorFilFK { get; set; }
        public Filme MelhorFil { get; set; }


      //***********************************************************************
      // definição da chave forasteira (FK) que referencia a classe Elenco
      //***********************************************************************
        [ForeignKey(nameof(ElencoId))]
        public int ElencoIdFK { get; set; }
        public Elenco ElencoId { get; set; }
        
        
    }
}
