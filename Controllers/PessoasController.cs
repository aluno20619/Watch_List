using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Watch_List.Data;
using Watch_List.Models;

namespace Watch_List.Controllers
{
   // [Authorize]
    public class PessoasController : Controller
    {
        /// <summary>
        /// Representa a bd
        /// </summary>
        private readonly WatchListDbContext _context;

        /// <summary>
        /// Atributo de dados da app web 
        /// </summary>
        private readonly IWebHostEnvironment _caminho;

     

        public PessoasController(WatchListDbContext context, IWebHostEnvironment caminho)
        {
            _context = context;
            _caminho = caminho;

        }

        [AllowAnonymous]
        /// <summary>
        /// Mostra a lista de pessoas 
        /// </summary>
        /// <returns></returns>
        // GET: Pessoas
        public async Task<IActionResult> Index()
        {

            //Profissões associadas a pessoas
           // var profissoes = await _context.Pessoa.Include(f => f.Profissoes).ToListAsync();

            return View(await _context.Pessoa.ToListAsync());
        }

        /// <summary>
        /// Mostra os detalhes de uma pessoa
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        // GET: Pessoas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            //se não houver id
            if (id == null)
            {
                return RedirectToAction("Index");
            }


            var pessoa = await _context.Pessoa
                .Include(p => p.Profissoes)
                .FirstOrDefaultAsync(p => p.Id == id);

            //se nao houver pessoas
            if (pessoa == null)
            {
                return RedirectToAction("Index");
            }

            return View(pessoa);
        }

        /// <summary>
        /// Mostra a página de criação e pessoa
        /// </summary>
        /// <returns></returns>
        // GET: Pessoas/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Pessoas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nome,Foto,DataNasc,DataObi,DataInic,Nacionalidade,ProfissaoFK")] Pessoa pessoa, IFormFile imagem)
        {
            // var auxiliar
            string caminhoCompleto = "";

           
            if (imagem == null)
            {
               // não há ficheiro
               // adicionar msg de erro
                ModelState.AddModelError("", "Adicione uma fotografia, por favor");
               // devolver o controlo à View
                return View(pessoa);
                //pessoa.Foto = "noimage.png";
            }
            else
            {
                // há ficheiro. Mas, será um ficheiro válido?
                if (imagem.ContentType == "image/jpeg" || imagem.ContentType == "image/png" || imagem.ContentType == "image/jpg")
                {
                    // definir o novo nome da fotografia     
                    Guid g;
                    g = Guid.NewGuid();
                    caminhoCompleto = pessoa.Foto + "_" + g.ToString(); // determinar a extensão do nome da imagem

                    string extensao = Path.GetExtension(imagem.FileName).ToLower();
                    // caminho completo do ficheiro
                    caminhoCompleto = caminhoCompleto + extensao;

                    // associar este ficheiro aos dados ds foto
                    pessoa.Foto = caminhoCompleto;

                    // localização do armazenamento da imagem
                    string localizacaoFicheiro = _caminho.WebRootPath;
                    caminhoCompleto = Path.Combine(localizacaoFicheiro, "Imagens", caminhoCompleto);
                }
                else
                {
                    // ficheiro não é válido
                    // adicionar msg de erro
                    ModelState.AddModelError("", "Só pode escolher uma imagem");
                    // devolver o controlo à View
                    return View(pessoa);
                }
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Add(pessoa);
                    await _context.SaveChangesAsync();

                    // vou guardar, agora, no disco rígido do Servidor a imagem
                    using var stream = new FileStream(caminhoCompleto, FileMode.Create);
                    await imagem.CopyToAsync(stream);
                    return RedirectToAction(nameof(Index));
                }   
                catch (Exception ex)
                {
                    ModelState.AddModelError("", "Ocorreu um erro...");

                }
        }


            return View(pessoa);
        }

        /// <summary>
        /// mostra a página do edit
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        // GET: Pessoas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pessoa = await _context.Pessoa.FindAsync(id);
            if (pessoa == null)
            {
                return NotFound();
            }
            // guardar o ID do objeto enviado para o browser
            // através de uma variável de sessão
            HttpContext.Session.SetInt32("NumFotoEmEdicao", pessoa.Id);
            return View(pessoa);
        }

        // POST: Pessoas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nome,Foto,DataNasc,DataObi,DataInic,Nacionalidade,ProfissaoFK")] Pessoa pessoa)
        {
            if (id != pessoa.Id)
            {
                return NotFound();
            }

            // recuperar o ID do objeto enviado para o browser
            var numIdFoto = HttpContext.Session.GetInt32("NumFotoEmEdicao");

            // e compará-lo com o ID recebido
            // se forem iguais, continuamos
            // se forem diferentes, não fazemos a alteração

            if (numIdFoto == null || numIdFoto != pessoa.Id)
            {
                //não houve problemas e redirecionamos para o index
                return RedirectToAction("Index");
            }


            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(pessoa);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PessoaExists(pessoa.Id))
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
           
            return View(pessoa);
        }

        /// <summary>
        /// Mostra a página do delete
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        // GET: Pessoas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pessoa = await _context.Pessoa
                .Include(p => p.ProfissaoFK)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (pessoa == null)
            {
                return NotFound();
            }

            return View(pessoa);
        }

        
        // POST: Pessoas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var pessoa = await _context.Pessoa.FindAsync(id);

            // Protege a eliminação de uma foto
            try { 
            
                _context.Pessoa.Remove(pessoa);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));

                //remover o ficheiro

                // localização do armazenamento da imagem              
                var localizacaoFicheiro = _caminho.WebRootPath;
                var caminhoCompleto = Path.Combine(localizacaoFicheiro, "Imagens", pessoa.Foto);

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
            
        }

        private bool PessoaExists(int id)
        {
            return _context.Pessoa.Any(e => e.Id == id);
        }
    }
}
