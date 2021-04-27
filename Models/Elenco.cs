using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Watch_List.Models
{
    /// <summary>
    /// Descrição do Elenco
    /// </summary>
    public class Elenco
    {
        public Elenco()
        {

            ListaDeFilmes = new HashSet<Filme>();
        }

        [Key]
        public int Id { get; set; }



        [StringLength(100, ErrorMessage = "A {0} não pode ter mais de {1} caracteres.")]
        [Display(Name = "Profissão")]
        public string Profissao { get; set; }


        //[RegularExpression("^[a-zA-ZÆÐƎƏƐƔĲŊŒẞÞǷȜæðǝəɛɣĳŋœĸſßþƿȝĄƁÇĐƊĘĦĮƘŁØƠŞȘŢȚŦŲƯY̨Ƴąɓçđɗęħįƙłøơşșţțŧųưy̨ƴÁÀÂÄǍĂĀÃÅǺĄÆǼǢƁĆĊĈČÇĎḌĐƊÐÉÈĖÊËĚĔĒĘẸƎƏƐĠĜǦĞĢƔáàâäǎăāãåǻąæǽǣɓćċĉčçďḍđɗðéèėêëěĕēęẹǝəɛġĝǧğģɣĤḤĦIÍÌİÎÏǏĬĪĨĮỊĲĴĶƘĹĻŁĽĿʼNŃN̈ŇÑŅŊÓÒÔÖǑŎŌÕŐỌØǾƠŒĥḥħıíìiîïǐĭīĩįịĳĵķƙĸĺļłľŀŉńn̈ňñņŋóòôöǒŏōõőọøǿơœŔŘŖŚŜŠŞȘṢẞŤŢṬŦÞÚÙÛÜǓŬŪŨŰŮŲỤƯẂẀŴẄǷÝỲŶŸȲỸƳŹŻŽẒŕřŗſśŝšşșṣßťţṭŧþúùûüǔŭūũűůųụưẃẁŵẅƿýỳŷÿȳỹƴźżžẓ-,.\']+$")]
        [Required(ErrorMessage = "O {0} é de preenchimento obrigatório")]
        [StringLength(50, ErrorMessage = "O {0} não pode ter mais de {1} caracteres.")]
        public string Nome { get; set; }

        [MaxLength(100, ErrorMessage = "A {0} não pode ter mais de {1} caracteres.")]
        [FileExtensions(ErrorMessage = "A extensão da {0} não é válida.")]
        public string Foto { get; set; }


        //***********************************************************************
        // definição do atributo que será utilizado para exprimir o relacionamento 
        // com os objetos da classe Filme
        [Display(Name = "Lista de filmes")]
        public ICollection<Filme> ListaDeFilmes { get; set; }
    }
}
