using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Watch_List.Data;
using Watch_List.Models;

//source : https://codewithmukesh.com/blog/user-management-in-aspnet-core-mvc/
namespace Watch_List.Controllers
{
    [Authorize]
    [Authorize(Roles = "Gestor")]
    public class RoleManager : Controller
    {
        private readonly RoleManager<IdentityRole> _roleManager;
        public RoleManager(RoleManager<IdentityRole> roleManager)
        {
            _roleManager = roleManager;
        }
        public async Task<IActionResult> Index()
        {
            //lista de roles
            var roles = await _roleManager.Roles.ToListAsync();
            return View(roles);
        }
      
    }
}
