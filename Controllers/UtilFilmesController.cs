using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Watch_List.Data;
using Watch_List.Models;

namespace Watch_List.Controllers
{

    [Authorize]
    public class UtilFilmesController : Controller
    {
        private readonly WatchListDbContext _context;

        private readonly UserManager<ApplicationUser> _userManager;

        public UtilFilmesController(WatchListDbContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        // GET: UtilFilmes
       
        public async Task<IActionResult> Index()
        {
            // var. auxiliar
            string idDaPessoaAutenticada = _userManager.GetUserId(User);




            //Filmes assosciados a um utilizador
            var filmes = await (from f in _context.Filme
                                join uf in _context.UtilFilme on f.Id equals uf.FilFK
                                where uf.UtilIdFK == idDaPessoaAutenticada
                                select new UtilizadoresFilmes { 
                                Id = uf.Id,
                                Titulo = f.Titulo,
                                Ano = f.Ano,
                                Poster = f.Poster,
                                Estado = uf.Estado,
                                FilmeFK = f.Id
                                }).ToListAsync();

            
            return View(filmes);
        }

        // GET: UtilFilmes/Details/5
        //public async Task<IActionResult> Details(int? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    //var utilFilme = await _context.UtilFilme
        //    //    .Include(u => u.Filme);
                

        //    var filme = await _context.Filme
        //        .FirstOrDefaultAsync(m => m.Id == id);

        //    if (filme == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(filme);
        //}

        // GET: UtilFilmes/Create
        public async Task<IActionResult> Create()
        {
            // Lista de filmes do utilizador autenticado
            //var filmes = await (from f in _context.Filme
            //              join uf in _context.UtilFilme on f.Id equals uf.FilFK
            //              //where uf.UtilIdFK == _userManager.GetUserId(User)
            //              select f).OrderBy(f => f.Titulo).ToListAsync();

            var filmes = await _context.Filme.OrderBy(f => f.Titulo).ToListAsync();

            ViewData["ListaFilmes"] = new SelectList(filmes, "Id", "Titulo");
           
            return View();
        }

        // POST: UtilFilmes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Estado,UtilIdFK,FilFK")] UtilFilme utilFilme)
        {

            utilFilme.UtilIdFK = _userManager.GetUserId(User);


            if (ModelState.IsValid)
            {
                _context.Add(utilFilme);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["FilFK"] = new SelectList(_context.Filme, "Id", "Titulo", utilFilme.FilFK);
            return View(utilFilme);
        }

        // GET: UtilFilmes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {

            if (id == null)
            {
                return NotFound();
            }

            var utilFilme = await _context.UtilFilme.FindAsync(id);
            if (utilFilme == null)
            {
                return NotFound();
            }


            var filmes = await _context.Filme.OrderBy(f => f.Titulo).ToListAsync();

            ViewData["ListaFilmes"] = new SelectList(filmes, "Id", "Titulo");

            return View(utilFilme);
        }

        // POST: UtilFilmes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Estado,UtilIdFK,FilFK")] UtilFilme utilFilme)
        {
            utilFilme.UtilIdFK = _userManager.GetUserId(User);

            if (id != utilFilme.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                   
                   

                   utilFilme.Filme = await _context.Filme.FirstAsync(f => f.Id == utilFilme.FilFK);
                    _context.UtilFilme.Update(utilFilme);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException )
                {

                    if (!UtilFilmeExists(utilFilme.Id))
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
            var filmes = await _context.Filme.OrderBy(f => f.Titulo).ToListAsync();

            ViewData["ListaFilmes"] = new SelectList(filmes, "Id", "Titulo");
            return View(utilFilme);
        }

        // GET: UtilFilmes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var utilFilme = await _context.UtilFilme
                .Include(u => u.Filme)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (utilFilme == null)
            {
                return NotFound();
            }

            return View(utilFilme);
        }

        // POST: UtilFilmes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var utilFilme = await _context.UtilFilme.FindAsync(id);
            _context.UtilFilme.Remove(utilFilme);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool UtilFilmeExists(int id)
        {
            return _context.UtilFilme.Any(e => e.Id == id);
        }
    }
}
