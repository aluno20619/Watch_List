using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Watch_List.Data;
using Watch_List.Models;

namespace Watch_List.Controllers
{
    [Authorize]
    public class FilmesController : Controller
    {
        /// <summary>
        /// Representa a bd
        /// </summary>
        private readonly WatchListDbContext _context;

        /// <summary>
        /// este atributo contém os dados da app web no servidor
        /// </summary>
        private readonly IWebHostEnvironment _caminho;

        /// <summary>
        /// Recolhe os dados da pessoa que se autenticou
        /// </summary>
        private readonly UserManager<ApplicationUser> _userManager;

        public FilmesController(WatchListDbContext context, IWebHostEnvironment caminho,UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _caminho = caminho;
            _userManager = userManager;

        }

        /// <summary>
        /// Mostra uma lista de filmes
        /// </summary>
        /// <returns></returns>
        [AllowAnonymous]
        // GET: Filmes
        public async Task<IActionResult> Index()
        {

            
            // return View(filmes);
            return View(await _context.Filme.ToListAsync());
        }

        /// <summary>
        /// Mostra os detalhes de um filme
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        // GET: Filmes/Details/5
        [AllowAnonymous]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("Index");
            }

            var filme = await _context.Filme
                .FirstOrDefaultAsync(m => m.Id == id);
            if (filme == null)
            {
                return RedirectToAction("Index");
            }

            return View(filme);
        }

        // GET: Filmes/Create
        [Authorize(Roles = "Funcionario,Gestor")]
        public IActionResult Create()
        {
            

            return View();
        }

        // POST: Filmes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Funcionario,Gestor")]
        public async Task<IActionResult> Create([Bind("Id,Titulo,Ano,Resumo,Poster,Trailer")] Filme filme, IFormFile foto)
        {
            

            string caminhoCompleto = "";
            bool haImagem = false;

            // avaliar se  o utilizador escolheu uma opção válida na dropdown
            /******************************************/


            if (foto == null)
            {
                // não há ficheiro!
                
                filme.Poster = "noimage.png";
            }
            else
            {
                // há ficheiro.
                
                if (foto.ContentType == "image/jpeg" || foto.ContentType == "image/png" || foto.ContentType == "image/jpg")
                {
                    //existe imagem

                    Guid g;
                    g = Guid.NewGuid();
                    // identificar a Extensão do ficheiro
                    string extensao = Path.GetExtension(foto.FileName).ToLower();
                    // nome do ficheiro
                    string nome = g.ToString() + extensao;
                    

                    // Identificar o caminho onde o ficheiro vai ser guardado
                    caminhoCompleto = Path.Combine(_caminho.WebRootPath, "Imagens", filme.Poster);
                    // associar o nome da fotografia 
                    filme.Poster = nome;
                    // assinalar que existe imagem
                    haImagem = true;
                }
                else
                {

                    filme.Poster = "noimage.png";
                }
               

            }
            if (ModelState.IsValid)
            {
                try { 
                    _context.Add(filme);
                    await _context.SaveChangesAsync();
               
                    if (haImagem)
                    {
                        using var stream = new FileStream(caminhoCompleto, FileMode.Create);
                        await foto.CopyToAsync(stream);
                    }

                    // redireciona o utilizador para a View Index
                    return RedirectToAction(nameof(Index));
                    }
                catch (Exception ex)
                {
                    ModelState.AddModelError("", "Ocorreu um erro...");

                }

            }
           
            ViewData["ListFilmes"] = new SelectList(_context.Filme.OrderBy(c => c.Titulo), "Id", "Titulo", foto);

            return View(filme);
            
        }

        // GET: Filmes/Edit/5
        [Authorize(Roles = "Funcionario,Gestor")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var filme = await _context.Filme.FindAsync(id);
            if (filme == null)
            {
                return NotFound();
            }

            ViewData["ListFilmes"] = new SelectList(_context.Filme.OrderBy(c => c.Titulo), "Id", "Titulo", filme.Poster);

            // guardar o ID do objeto enviado para o browser
            // através de uma variável de sessão
            HttpContext.Session.SetInt32("NumFotoEmEdicao", filme.Id);

            return View(filme);
        }

        // POST: Filmes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Funcionario,Gestor")]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Titulo,Ano,Resumo,Poster,Trailer")] Filme filme)
        {
            if (id != filme.Id)
            {
                return NotFound();
            }

            // recuperar o ID do objeto enviado para o browser
            var numIdFoto = HttpContext.Session.GetInt32("NumFotoEmEdicao");

            // e compará-lo com o ID recebido
            // se forem iguais, continuamos
            // se forem diferentes, não fazemos a alteração

            if (numIdFoto == null || numIdFoto != filme.Id)
            {
                //não houve problemas e redirecionamos para o index
                return RedirectToAction("Index");
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(filme);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FilmeExists(filme.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(filme);
        }

        // GET: Filmes/Delete/5
        [Authorize(Roles = "Funcionario,Gestor")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var filme = await _context.Filme
                .FirstOrDefaultAsync(m => m.Id == id);
            if (filme == null)
            {
                return NotFound();
            }

            return View(filme);
        }

        // POST: Filmes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Funcionario,Gestor")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            try { 
            var filme = await _context.Filme.FindAsync(id);
            _context.Filme.Remove(filme);
            await _context.SaveChangesAsync();

            //remover o ficheiro

            // localização do armazenamento da imagem              
            var localizacaoFicheiro = _caminho.WebRootPath;
            var caminhoCompleto = Path.Combine(localizacaoFicheiro, "Imagens", filme.Poster);

            //source: https://stackoverflow.com/questions/22650740/asp-net-mvc-5-delete-file-from-server
            if (System.IO.File.Exists(caminhoCompleto))
            {
                System.IO.File.Delete(caminhoCompleto);
            }
            }
            catch (Exception)
            {

                throw;
            }
            return RedirectToAction(nameof(Index));
        }

        private bool FilmeExists(int id)
        {
            return _context.Filme.Any(e => e.Id == id);
        }
    }
}
