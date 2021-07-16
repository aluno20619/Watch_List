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
    public class FilmeGeneroesController : Controller
    {
        private readonly WatchListDbContext _context;

        public FilmeGeneroesController(WatchListDbContext context)
        {
            _context = context;
        }

        // GET: FilmeGeneroes
        public async Task<IActionResult> Index()
        {
            var watchListDbContext = _context.FilmeGenero.Include(f => f.Filme).Include(f => f.Genero);
            return View(await watchListDbContext.ToListAsync());
        }

        // GET: FilmeGeneroes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var filmeGenero = await _context.FilmeGenero
                .Include(f => f.Filme)
                .Include(f => f.Genero)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (filmeGenero == null)
            {
                return NotFound();
            }

            return View(filmeGenero);
        }

        // GET: FilmeGeneroes/Create
        public IActionResult Create()
        {
            ViewData["FilmeFK"] = new SelectList(_context.Filme, "Id", "Titulo");
            ViewData["GeneroFK"] = new SelectList(_context.Genero, "Id", "Nome");
            return View();
        }

        // POST: FilmeGeneroes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,FilmeFK,GeneroFK")] FilmeGenero filmeGenero)
        {
            if (ModelState.IsValid)
            {
                _context.Add(filmeGenero);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["FilmeFK"] = new SelectList(_context.Filme, "Id", "Titulo", filmeGenero.FilmeFK);
            ViewData["GeneroFK"] = new SelectList(_context.Genero, "Id", "Nome", filmeGenero.GeneroFK);
            return View(filmeGenero);
        }

        // GET: FilmeGeneroes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var filmeGenero = await _context.FilmeGenero.FindAsync(id);
            if (filmeGenero == null)
            {
                return NotFound();
            }
            ViewData["FilmeFK"] = new SelectList(_context.Filme, "Id", "Titulo", filmeGenero.FilmeFK);
            ViewData["GeneroFK"] = new SelectList(_context.Genero, "Id", "Nome", filmeGenero.GeneroFK);
            return View(filmeGenero);
        }

        // POST: FilmeGeneroes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,FilmeFK,GeneroFK")] FilmeGenero filmeGenero)
        {
            if (id != filmeGenero.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(filmeGenero);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FilmeGeneroExists(filmeGenero.Id))
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
            ViewData["FilmeFK"] = new SelectList(_context.Filme, "Id", "Titulo", filmeGenero.FilmeFK);
            ViewData["GeneroFK"] = new SelectList(_context.Genero, "Id", "Nome", filmeGenero.GeneroFK);
            return View(filmeGenero);
        }

        // GET: FilmeGeneroes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var filmeGenero = await _context.FilmeGenero
                .Include(f => f.Filme)
                .Include(f => f.Genero)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (filmeGenero == null)
            {
                return NotFound();
            }

            return View(filmeGenero);
        }

        // POST: FilmeGeneroes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var filmeGenero = await _context.FilmeGenero.FindAsync(id);
            _context.FilmeGenero.Remove(filmeGenero);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FilmeGeneroExists(int id)
        {
            return _context.FilmeGenero.Any(e => e.Id == id);
        }
    }
}
