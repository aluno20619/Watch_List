using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Watch_List.Data;
using Watch_List.Models;

namespace Watch_List.Controllers
{
    
    [Authorize]
    public class PessoaFilmesController : Controller
    {
        private readonly WatchListDbContext _context;

        public PessoaFilmesController(WatchListDbContext context)
        {
            _context = context;
        }

        // GET: PessoaFilmes
        public async Task<IActionResult> Index()
        {
            var watchListDbContext = _context.PessoaFilme.Include(p => p.Filme).Include(p => p.Pessoa);
            return View(await watchListDbContext.ToListAsync());
        }

        // GET: PessoaFilmes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pessoaFilme = await _context.PessoaFilme
                .Include(p => p.Filme)
                .Include(p => p.Pessoa)
                
                .FirstOrDefaultAsync(m => m.Id == id);
            if (pessoaFilme == null)
            {
                return NotFound();
            }

            return View(pessoaFilme);
        }

        // GET: PessoaFilmes/Create
        public IActionResult Create()
        {
            ViewData["FilmeFK"] = new SelectList(_context.Filme, "Id", "Titulo");
            ViewData["PessoaFK"] = new SelectList(_context.Pessoa, "Id", "Nome");
            return View();
        }

        // POST: PessoaFilmes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Premio,FilmeFK,PessoaFK")] PessoaFilme pessoaFilme)
        {
            if (ModelState.IsValid)
            {
                _context.Add(pessoaFilme);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["FilmeFK"] = new SelectList(_context.Filme, "Id", "Titulo", pessoaFilme.FilmeFK);
            ViewData["PessoaFK"] = new SelectList(_context.Pessoa, "Id", "Nome", pessoaFilme.PessoaFK);
            return RedirectToAction("Index","Filmes");
        }

        // GET: PessoaFilmes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pessoaFilme = await _context.PessoaFilme.FindAsync(id);
            if (pessoaFilme == null)
            {
                return NotFound();
            }
            ViewData["FilmeFK"] = new SelectList(_context.Filme, "Id", "Titulo", pessoaFilme.FilmeFK);
            ViewData["PessoaFK"] = new SelectList(_context.Pessoa, "Id", "Nome", pessoaFilme.PessoaFK);
            return View(pessoaFilme);
        }

        // POST: PessoaFilmes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Premio,FilmeFK,PessoaFK")] PessoaFilme pessoaFilme)
        {
            if (id != pessoaFilme.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(pessoaFilme);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PessoaFilmeExists(pessoaFilme.Id))
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
            ViewData["FilmeFK"] = new SelectList(_context.Filme, "Id", "Titulo", pessoaFilme.FilmeFK);
            ViewData["PessoaFK"] = new SelectList(_context.Pessoa, "Id", "Nome", pessoaFilme.PessoaFK);
            return View(pessoaFilme);
        }

        // GET: PessoaFilmes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pessoaFilme = await _context.PessoaFilme
                .Include(p => p.Filme)
                .Include(p => p.Pessoa)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (pessoaFilme == null)
            {
                return NotFound();
            }

            return View(pessoaFilme);
        }

        // POST: PessoaFilmes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var pessoaFilme = await _context.PessoaFilme.FindAsync(id);
            _context.PessoaFilme.Remove(pessoaFilme);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PessoaFilmeExists(int id)
        {
            return _context.PessoaFilme.Any(e => e.Id == id);
        }
    }
}
