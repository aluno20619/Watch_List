using System;
using System.Collections.Generic;
    namespace Watch_List.Models {
    /// <summary>
    /// classe para permitir o transporte do Controller para a View, e vice-versa
    /// irá transportar os dados das Fotografias e dos IDs do Cães que pertencem 
    /// à pessoa autenticada
    /// </summary>
    public class PessoasOnFilmes
    {

        /// <summary>
        /// lista de todas dos posters do filme
        /// </summary>
        public ICollection<Pessoa> ListaDeFilmes { get; set; }

        /// <summary>
        /// lista dos IDs dos filmes associados à pessoa autenticada
        /// </summary>
        public ICollection<int> ListaFilme { get; set; }

    }




    public class ErrorViewModel
    {
        public string RequestId { get; set; }
        public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);
    }
}