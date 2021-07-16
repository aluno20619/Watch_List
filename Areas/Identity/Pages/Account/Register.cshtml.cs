using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.Extensions.Logging;
using Watch_List.Data;
using Watch_List.Models;

namespace Watch_List.Areas.Identity.Pages.Account
{
    [AllowAnonymous]
    public class RegisterModel : PageModel
    {
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly ILogger<RegisterModel> _logger;
        private readonly IEmailSender _emailSender;

        private readonly WatchListDbContext _context;

        public RegisterModel(
            UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager,
            ILogger<RegisterModel> logger,
            IEmailSender emailSender,
            WatchListDbContext context)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _logger = logger;
            _emailSender = emailSender;
            _context = context;

        }

        [BindProperty]
        public InputModel Input { get; set; }

        public string ReturnUrl { get; set; }

        public IList<AuthenticationScheme> ExternalLogins { get; set; }

        public class InputModel
        {

            //[Required(ErrorMessage = "O {0} é de preenchimento obrigatório")]
            //[StringLength(32, ErrorMessage = "O {0} não pode ter mais de {1} caracteres.")]
            //[Display(Name = "Nome de utilizador")]
            //public string UserName { get; set; }

            

            [Required]
            [EmailAddress]
            [Display(Name = "Email")]
            public string Email { get; set; }

            [Required]
            [StringLength(100, ErrorMessage = "A {0} deve ter no minimo {2} charateres e máximo {1} characteres.", MinimumLength = 6)]
            [DataType(DataType.Password)]
            [Display(Name = "Password")]
            public string Password { get; set; }

            [DataType(DataType.Password)]
            [Display(Name = "Confirm password")]
            [Compare("Password", ErrorMessage = "A password e a sua confirmação não são iguais")]
            public string ConfirmPassword { get; set; }

            
            /// <summary>
            /// permitir a recolha dos dados do utilizador
            /// </summary>
            public Utilizador Utilizador { get; set; }
        }

        public async Task OnGetAsync(string returnUrl = null)
        {
           

            ReturnUrl = returnUrl;
            ExternalLogins = (await _signInManager.GetExternalAuthenticationSchemesAsync()).ToList();
        }


        /// <summary>
        /// criar um novo Utilizador
        ///  registar os dados pessoais do utilizador
        /// </summary>
        /// <param name="returnUrl"></param>
        /// <returns></returns>
        public async Task<IActionResult> OnPostAsync(string returnUrl = null)
        {
            returnUrl ??= Url.Content("~/");
           
            if (ModelState.IsValid)
           
            {
                var user = new ApplicationUser {
                    UserName = Input.Email, 
                    Email = Input.Email,
                    DataRegisto = DateTime.Now,
                    EmailConfirmed = true, // o email está confirmado
                };
                var result = await _userManager.CreateAsync(user, Input.Password);

                if (result.Succeeded)
                {
                    _logger.LogInformation("User created a new account with password.");
                   
                    await _userManager.AddToRoleAsync(user,"Gestor");

                    //    //*************************************************************
                    //    // Guardar os dados do Utilizador
                    //    //*************************************************************
                    //    // preparar os dados do utilizador para serem adicionados à BD


                    //    Input.Utilizador.Email = Input.Email;

                    //    Input.Utilizador.UtilIdFK = user.Id;  // adicionar o ID do utilizador,
                    //                                          // para formar uma 'ponte' (foreign key) entre
                    //                                          // os dados da autenticação e os dados do 'negócio'


                    //    // estamos em condições de guardar os dados na BD
                    try
                    {



                        //           _context.Add(Input.Utilizador); // adicionar o utilizador
                        await _context.SaveChangesAsync();



                        // Enviar para o utilizador para a página de confirmação da criaçao de Registo
                        return RedirectToPage("RegisterConfirmation");
                    }
                    catch (Exception)
                    {
                        
                        // Mas, o USER já foi criado na BD
                        // é efetuado o Roolback da ação
                        await _userManager.DeleteAsync(user);

                        // avisar que houve um erro
                        ModelState.AddModelError("", "Ocorreu um erro na criação de dados");
                    }

                    /*Codigo default*/
                    //    var code = await _userManager.GenerateEmailConfirmationTokenAsync(user);
                    //    code = WebEncoders.Base64UrlEncode(Encoding.UTF8.GetBytes(code));
                    //    var callbackUrl = Url.Page(
                    //        "/Account/ConfirmEmail",
                    //        pageHandler: null,
                    //        values: new { area = "Identity", userId = user.Id, code = code, returnUrl = returnUrl },
                    //        protocol: Request.Scheme);

                    //    await _emailSender.SendEmailAsync(Input.Email, "Confirm your email",
                    //        $"Please confirm your account by <a href='{HtmlEncoder.Default.Encode(callbackUrl)}'>clicking here</a>.");

                    //    if (_userManager.Options.SignIn.RequireConfirmedAccount)
                    //    {
                    //        return RedirectToPage("RegisterConfirmation", new { email = Input.Email, returnUrl = returnUrl });
                    //    }
                    //    else
                    //    {
                    //        await _signInManager.SignInAsync(user, isPersistent: false);
                    //        return LocalRedirect(returnUrl);
                    //    }
                }
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
            }

            // If we got this far, something failed, redisplay form
            return Page();
        }
    }
}
