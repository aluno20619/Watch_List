using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Watch_List.Models
{
    /// <summary>
    /// Tabela intermédia de Genero e Filmes
    /// </summary>
    public class FilmeGenero
    {

            [Key]
            public int Id { get; set; }

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
            /// definição da chave forasteira (FK) que referencia a classe Genero
            /// </summary>
            //***********************************************************************
            [ForeignKey(nameof(Genero))]
            [Display(Name = "Género")]
            public int GeneroFK { get; set; }
            public Genero Genero { get; set; }


        }
    }
