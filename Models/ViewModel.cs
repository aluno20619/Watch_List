using System;
using System.Collections.Generic;
    
namespace Watch_List.Models {
    /// <summary>
    /// Permite o transporte de dados do Controller para a View, e vice-versa
    /// </summary>
    



    public class PessoasOnFilmes
    {

        /// <summary>
        /// lista de profissoes que a pessoa tem
        /// </summary>
        public ICollection<Pessoa> ListaDeProfissoes { get; set; }

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