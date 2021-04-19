using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Watch_List.Models
{
    public class Genero
    {
        public Genero() {

            ListaDeFilmes = new HashSet<Filme>();
        }

        [Key]
        [MaxLength(20)]
        public string Nome { get; set; }
		
		
		
		//***********************************************************************
      // definição do atributo que será utilizado para exprimir o relacionamento
      // com os objetos da classe Filme
        public ICollection<Filme> ListaDeFilmes { get; set; }
    }
}
