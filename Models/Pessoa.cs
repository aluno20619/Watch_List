using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Watch_List.Models
{
    /// <summary>
    /// Descrição das pessoas envolvidas nos filmes
    /// </summary>
    public class Pessoa
    {
        public Pessoa()
        {

            ListaDeFilmes = new HashSet<PessoaFilme>();
        }

        /// <summary>
        /// Número de identifição da pessoa
        /// </summary>
        [Key]
        public int Id { get; set; }

        /// <summary>
        /// Nome da pessoa
        /// </summary>
        //[RegularExpression("^[a-zA-ZÆÐƎƏƐƔĲŊŒẞÞǷȜæðǝəɛɣĳŋœĸſßþƿȝĄƁÇĐƊĘĦĮƘŁØƠŞȘŢȚŦŲƯY̨Ƴąɓçđɗęħįƙłøơşșţțŧųưy̨ƴÁÀÂÄǍĂĀÃÅǺĄÆǼǢƁĆĊĈČÇĎḌĐƊÐÉÈĖÊËĚĔĒĘẸƎƏƐĠĜǦĞĢƔáàâäǎăāãåǻąæǽǣɓćċĉčçďḍđɗðéèėêëěĕēęẹǝəɛġĝǧğģɣĤḤĦIÍÌİÎÏǏĬĪĨĮỊĲĴĶƘĹĻŁĽĿʼNŃN̈ŇÑŅŊÓÒÔÖǑŎŌÕŐỌØǾƠŒĥḥħıíìiîïǐĭīĩįịĳĵķƙĸĺļłľŀŉńn̈ňñņŋóòôöǒŏōõőọøǿơœŔŘŖŚŜŠŞȘṢẞŤŢṬŦÞÚÙÛÜǓŬŪŨŰŮŲỤƯẂẀŴẄǷÝỲŶŸȲỸƳŹŻŽẒŕřŗſśŝšşșṣßťţṭŧþúùûüǔŭūũűůųụưẃẁŵẅƿýỳŷÿȳỹƴźżžẓ-,.\']+$")]
        [Required(ErrorMessage = "O {0} é de preenchimento obrigatório")]
        [StringLength(50, ErrorMessage = "O {0} não pode ter mais de {1} caracteres.")]
        public string Nome { get; set; }

        /// <summary>
        /// Extensão do ficheiro da imagem da pessoa
        /// </summary>
        [MaxLength(100, ErrorMessage = "A {0} não pode ter mais de {1} caracteres.")]
        [FileExtensions(ErrorMessage = "A extensão da {0} não é válida.")]
        public string Foto { get; set; }

        /// <summary>
        /// Data de nascimento da pessoa
        /// </summary>
        [Display(Name = "Data de Nascimento")]
        public DateTime DataNasc { get; set; }

        /// <summary>
        /// Data de óbito da pessoa
        /// </summary>
        [Display(Name = "Data de Óbito")]
        public DateTime DataObi { get; set; }

        /// <summary>
        /// Data de ínicio de carreira da pessoa
        /// </summary>
        [Display(Name = "Data de ínicio de carreira")]
        public DateTime DataInic { get; set; }

        /// <summary>
        /// Nacionalidade da pessoa
        /// </summary>
        [StringLength(50, ErrorMessage = "O {0} não pode ter mais de {1} caracteres.")]
        public string Nacionalidade { get; set; }



        //***********************************************************************
        /// <summary>
        /// definição do atributo que será utilizado para exprimir o relacionamento com os objetos da classe Filme
        /// </summary>
        //***********************************************************************
        [Display(Name = "Lista de filmes")]
        public ICollection<PessoaFilme> ListaDeFilmes { get; set; }
    }
}
