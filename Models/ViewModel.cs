using System;
using System.Collections.Generic;
    
namespace Watch_List.Models {
    /// <summary>
    /// Permite o transporte de dados do Controller para a View, e vice-versa
    /// </summary>
    

    public class UtilizadoresFilmes
    {

        
        public int Id { get; set; }
        public int FilmeFK { get; set; }
        public string Titulo { get; set; }
        public string Poster { get; set; }
        public string Estado { get; set; }
        public int Ano { get; set; }
       
    }
   
    //source :https://codewithmukesh.com/blog/user-management-in-aspnet-core-mvc/
    public class UserRolesViewModel
    {
        public string UserId { get; set; }
        public string Email { get; set; }
        public IEnumerable<string> Roles { get; set; }
    }

    //source :https://codewithmukesh.com/blog/user-management-in-aspnet-core-mvc/
    public class ManageUserRolesViewModel
    {
        public string RoleId { get; set; }
        public string RoleName { get; set; }
        public bool Selected { get; set; }
    }


    public class ErrorViewModel
    {
        public string RequestId { get; set; }
        public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);
    }
}