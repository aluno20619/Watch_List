using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Watch_List.Data;
using Watch_List.Models;

namespace Watch_List.Controllers
{
    [Authorize]
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

        /// <summary>
        /// esta variável recolhe os dados da pessoa q se autenticou
        /// </summary>
        private readonly UserManager<ApplicationUser> _userManager;

        public PessoasController(WatchListDbContext context, IWebHostEnvironment caminho, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _caminho = caminho;
            _userManager = userManager;
        }

        [AllowAnonymous]
        /// <summary>
        /// Mostra a lista de pessoas 
        /// </summary>
        /// <returns></returns>
        // GET: Pessoas
        public async Task<IActionResult> Index()
        {
            // dados das fotos
            var foto = await _context.Pessoa.Include(f => f.ProfissaoFK).ToListAsync();
            
            // variavel aux para obter o id da pessoa autenticada
            string idPessoaAutenticada = _userManager.GetUserId(User);
            

            //Filmes assosciados a uma pessoa
            //equivalente a: SELECT * FROM UtilFilme uf, Pessoa p, Profissoes t, Filme f, PessoaFilme pf WHERE p.ProfissaoFK = t.Id AND pf.PessoaFK = p.Id AND pf.FilmeFK = f.Id And u.UserName == idPessoaAutenticada
            var filmes = await (from f in _context.Filme
                                join pf in _context.PessoaFilme on f.Id equals pf.FilmeFK
                                join p in _context.Pessoa on pf.PessoaFK equals p.Id
                                join t in _context.Profissao on p.ProfissaoFK equals t.Id
                                join uf in _context.UtilFilme on f.Id equals uf.FilFK
                               // join u in _context. on uf equals uf.
                               // where u.UtilIdFK == idPessoaAutenticada
                              select f.Id).ToListAsync();

            //INSERT VIEWMODEL
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
            if (id == null)
            {
                return NotFound();
            }

            var pessoa = await _context.Pessoa
                .FirstOrDefaultAsync(m => m.Id == id);
            if (pessoa == null)
            {
                return NotFound();
            }

            return View(pessoa);
        }

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
        public async Task<IActionResult> Create([Bind("Id,Nome,Foto,DataNasc,DataObi,DataInic,Nacionalidade,ProfissaoFK")] Pessoa pessoa)
        {
            if (ModelState.IsValid)
            {
                _context.Add(pessoa);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(pessoa);
        }

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

        // GET: Pessoas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pessoa = await _context.Pessoa
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
            _context.Pessoa.Remove(pessoa);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PessoaExists(int id)
        {
            return _context.Pessoa.Any(e => e.Id == id);
        }
    }
}
