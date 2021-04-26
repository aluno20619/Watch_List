﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;


namespace Watch_List.Models
{
    public class Util_Fil
    {
       
		[Key]
		public int Id { get; set; }

        [MaxLength(10, ErrorMessage = "O {0} não pode ter mais de {1} caracteres.")]
        public string Estado { get; set; }
		
		
		
	  //***********************************************************************
      // definição da chave forasteira (FK) que referencia a classe Identity User
      //***********************************************************************
       // public int UtilIdFK { get; set; }
       
	  //***********************************************************************
      // definição da chave forasteira (FK) que referencia a classe Filme
      //***********************************************************************
        [ForeignKey(nameof(FilId))]
        [Display(Name ="Filmes")]
        public int FilIdFK { get; set; }
        public Filme FilId { get; set; }

       
    }
}
