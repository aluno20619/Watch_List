using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Watch_List.Data;
using Watch_List.Models;

namespace Watch_List.Controllers.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class FilmeControllerAPI : ControllerBase
    {
        private readonly WatchListDbContext _context;
        private readonly IWebHostEnvironment _path;

        public FilmeControllerAPI(WatchListDbContext context, IWebHostEnvironment path)
        {
            _context = context;
            _path = path;
        }

        // GET: api/FilmeControllerAPI
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Filme>>> GetFilme()
        {
            return await _context.Filme.ToListAsync();
        }

        // GET: api/FilmeControllerAPI/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Filme>> GetFilme(int id)
        {
            var filme = await _context.Filme.FindAsync(id);

            if (filme == null)
            {
                return NotFound();
            }

            return filme;
        }

        // PUT: api/FilmeControllerAPI/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutFilme(int id, [FromForm]Filme filme, IFormFile poster)
        {
            if (id != filme.Id)
            {
                return BadRequest();
            }

            string caminhoCompleto = "";
            var deprecatedFilme = await _context.Filme.FindAsync(id);

            if (poster.FileName == "null")
            {
                filme.Poster = deprecatedFilme.Poster;
            }
            else
            {

                // definir o novo nome da fotografia     
                Guid g;
                g = Guid.NewGuid();

                //apagar a imagem anterior
                string localizacaoFicheiro = _path.WebRootPath;
                    caminhoCompleto = Path.Combine(localizacaoFicheiro, "Imagens", deprecatedFilme.Poster);
                if (System.IO.File.Exists(caminhoCompleto))
                {
                    System.IO.File.Delete(caminhoCompleto);
                }

                caminhoCompleto = g.ToString(); // determinar a extensão do nome da imagem

                string extensao = Path.GetExtension(poster.FileName).ToLower();
                // caminho completo do ficheiro
                caminhoCompleto += extensao;

                // associar este ficheiro aos dados ds foto
                filme.Poster = caminhoCompleto;

                // localização do armazenamento da imagem

                caminhoCompleto = Path.Combine(localizacaoFicheiro, "Imagens", caminhoCompleto);
            }
            _context.Entry<Filme>(deprecatedFilme).State = EntityState.Detached;
            try
            {
                _context.Entry(filme).State = EntityState.Modified;
                await _context.SaveChangesAsync();
                if(poster.FileName != "null")
                {
                    using var stream = new FileStream(caminhoCompleto, FileMode.Create);
                    await poster.CopyToAsync(stream);
                }
                
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FilmeExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/FilmeControllerAPI
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Filme>> PostFilme([FromForm]Filme filme, IFormFile? poster)
        {
            string caminhoCompleto = "";
            bool haImagem = false;

            if (poster == null)
            {
                // não há ficheiro!

                filme.Poster = "noimage.png";
            }
            else
            {
                // há ficheiro.

                if (poster.ContentType == "image/jpeg" || poster.ContentType == "image/png")
                {
                    //existe imagem

                    Guid g;
                    g = Guid.NewGuid();
                    // identificar a Extensão do ficheiro
                    string extensao = Path.GetExtension(poster.FileName).ToLower();
                    // nome do ficheiro
                    string nome = g.ToString() + extensao;


                    // Identificar o caminho onde o ficheiro vai ser guardado
                    caminhoCompleto = Path.Combine(_path.WebRootPath, "Imagens", nome);
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


            _context.Filme.Add(filme);
            await _context.SaveChangesAsync();

            if (haImagem)
            {
                using var stream = new FileStream(caminhoCompleto, FileMode.Create);
                await poster.CopyToAsync(stream);
            }

            return CreatedAtAction("GetFilme", new { id = filme.Id }, filme);
        }

        // DELETE: api/FilmeControllerAPI/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFilme(int id)
        {
            var filme = await _context.Filme.FindAsync(id);
            if (filme == null)
            {
                return NotFound();
            }

            _context.Filme.Remove(filme);
            
            var filmeGenero = await _context.FilmeGenero.Where(fg => fg.FilmeFK == id).ToListAsync();
            var pessoaFilme = await _context.PessoaFilme.Where(pf => pf.FilmeFK == id).ToListAsync();

            _context.FilmeGenero.RemoveRange(filmeGenero);
            _context.PessoaFilme.RemoveRange(pessoaFilme);

            await _context.SaveChangesAsync();

            var localizacaoFicheiro = _path.WebRootPath;
            var caminhoCompleto = Path.Combine(localizacaoFicheiro, "Imagens", filme.Poster);

            //source: https://stackoverflow.com/questions/22650740/asp-net-mvc-5-delete-file-from-server
            if (System.IO.File.Exists(caminhoCompleto))
            {
                System.IO.File.Delete(caminhoCompleto);
            }

            return NoContent();
        }

        private bool FilmeExists(int id)
        {
            return _context.Filme.Any(e => e.Id == id);
        }
    }
}
