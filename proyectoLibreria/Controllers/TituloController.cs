using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using proyecto.Data;
using proyecto.Models;

namespace proyecto.Controllers
{
    public class TituloController : Controller
    {
        private readonly proyectoContext _context;

        public TituloController(proyectoContext context)
        {
            _context = context;
        }

        // GET: Titulo
        public async Task<IActionResult> Index()
        {
            return View(await _context.Titulos.ToListAsync());
        }

        // GET: Titulo/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var titulo = await _context.Titulos
                .Include(f => f.Generos)
                .FirstOrDefaultAsync(m => m.TituloID == id);
            if (titulo == null)
            {
                return NotFound();
            }

            return View(titulo);
        }

        // GET: Titulo/Create
        public IActionResult Create()
        {
         
            ViewData["GeneroID"] = new SelectList(_context.Generos, "GenereID", "GenreDesc");
            return View();
        }

        // POST: Titulo/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("TituloID,Titulo,Prologo,fechaDePublicacion,NumeroDePaginas,GeneroID")] Titulos titulo)
        {
            if (ModelState.IsValid)
            {
                _context.Add(titulo);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["GeneroID"] = new SelectList(_context.Generos, "GenereID", "GenreDesc", titulo.GeneroID);
            return View(titulo);
        }

        // GET: Titulo/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var titulo = await _context.Titulos.FindAsync(id);
            if (titulo == null)
            {
                return NotFound();
            }
            ViewData["GeneroID"] = new SelectList(_context.Generos, "GenereID", "GenreDesc", titulo.GeneroID);
            return View(titulo);
        }

        // POST: Titulo/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("TituloID,Titulo,Prologo,fechaDePublicacion,NumeroDePaginas,GeneroID")] Titulos titulo)
        {
            if (id != titulo.TituloID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(titulo);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TituloExists(titulo.TituloID))
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
            ViewData["GeneroID"] = new SelectList(_context.Generos, "GeneroID", "GenreDesc", titulo.GeneroID);
            return View(titulo);
        }

        // GET: Titulo/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var titulo = await _context.Titulos
                .Include(f => f.Generos)
                .FirstOrDefaultAsync(m => m.TituloID == id);
            if (titulo == null)
            {
                return NotFound();
            }

            return View(titulo);
        }

        // POST: Titulo/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var titulo = await _context.Titulos.FindAsync(id);
            _context.Titulos.Remove(titulo);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TituloExists(int id)
        {
            return _context.Titulos.Any(e => e.TituloID == id);
        }
    }
}
