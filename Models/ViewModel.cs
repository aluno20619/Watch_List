using System;
using System.Collections.Generic;
    
namespace Watch_List.Models {
    /// <summary>
    /// Permite o transporte de dados do Controller para a View, e vice-versa
    /// </summary>
    

    public class UtilizadoresFilmes
    {

        /// <summary>
        /// lista dos IDs dos filmes associados à pessoa autenticada
        /// </summary>
        public ICollection<int> ListaDeFilmes { get; set; }
    }

   


    public class ErrorViewModel
    {
        public string RequestId { get; set; }
        public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);
    }
}