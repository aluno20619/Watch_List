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

            ViewData["ListaDePessoas"] = await (from f in _context.Filme
                                                join pf in _context.PessoaFilme on f.Id equals pf.FilmeFK
                                                join p in _context.Pessoa on pf.PessoaFK equals p.Id
                                                where f.Id == id
                                                select p).ToListAsync();

            ViewData["ListaDeGeneros"] = await (from f in _context.Filme
                                                join gf in _context.FilmeGenero on f.Id equals gf.FilmeFK
                                                join g in _context.Genero on gf.GeneroFK equals g.Id
                                                where f.Id == id
                                                select g).ToListAsync();

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
                
                if (foto.ContentType == "image/jpeg" || foto.ContentType == "image/png" )
                {
                    //existe imagem

                    Guid g;
                    g = Guid.NewGuid();
                    // identificar a Extensão do ficheiro
                    string extensao = Path.GetExtension(foto.FileName).ToLower();
                    // nome do ficheiro
                    string nome = g.ToString() + extensao;
                    

                    // Identificar o caminho onde o ficheiro vai ser guardado
                    caminhoCompleto = Path.Combine(_caminho.WebRootPath, "Imagens",nome);
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
                catch (Exception)
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
        public async Task<IActionResult> Edit(int id, [Bind("Id,Titulo,Ano,Resumo,Poster,Trailer")] Filme filme,IFormFile imagem)
        {
            if (id != filme.Id)
            {
                return NotFound();
            }

            // recuperar o ID do objeto enviado para o browser
            var numIdFoto = HttpContext.Session.GetString("NumFotoEmEdicao");



            // var auxiliar
            string caminhoCompleto = "";


            if (ModelState.IsValid)
            {
                try
                {
                    if (imagem == null)
                    {
                        filme.Poster = numIdFoto;
                    }
                    else
                    {
                        // há ficheiro. Mas, será um ficheiro válido?
                        if (imagem.ContentType == "image/jpeg" || imagem.ContentType == "image/png" || imagem.ContentType == "image/jpg")
                        {
                            // definir o novo nome da fotografia     
                            Guid g;
                            g = Guid.NewGuid();

                            //apagar a imagem anterior
                            string localizacaoFicheiro = _caminho.WebRootPath;
                            caminhoCompleto = Path.Combine(localizacaoFicheiro, "Imagens", numIdFoto);
                            if (System.IO.File.Exists(caminhoCompleto))
                            {
                                System.IO.File.Delete(caminhoCompleto);
                            }

                            caminhoCompleto = g.ToString(); // determinar a extensão do nome da imagem

                            string extensao = Path.GetExtension(imagem.FileName).ToLower();
                            // caminho completo do ficheiro
                            caminhoCompleto = caminhoCompleto + extensao;

                            // associar este ficheiro aos dados ds foto
                            filme.Poster = caminhoCompleto;

                            // localização do armazenamento da imagem

                            caminhoCompleto = Path.Combine(localizacaoFicheiro, "Imagens", caminhoCompleto);
                        }
                        else
                        {
                            // ficheiro não é válido
                            // adicionar msg de erro
                            ModelState.AddModelError("", "Só pode escolher uma imagem");
                            // devolver o controlo à View

                            var profissao = (from pr in _context.Profissao
                                             join p in _context.Pessoa on pr.Id equals p.ProfissaoFK
                                             select pr)
                             .OrderBy(pr => pr.Tarefa);

                            ViewData["ProFK"] = new SelectList(profissao, "Id", "Tarefa");
                            return View(filme);
                        }
                        _context.Update(filme);
                        await _context.SaveChangesAsync();
                        // vou guardar, agora, no disco rígido do Servidor a imagem
                        using var stream = new FileStream(caminhoCompleto, FileMode.Create);
                        await imagem.CopyToAsync(stream);
                        }
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
