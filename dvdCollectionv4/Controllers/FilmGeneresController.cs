using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using dvdCollection.Data;
using dvdCollection.Models;

namespace dvdCollection.Controllers
{
    public class FilmGeneresController : Controller
    {
        private readonly dvdCollectionContext _context;

        public FilmGeneresController(dvdCollectionContext context)
        {
            _context = context;
        }

        // GET: FilmGeneres
        public async Task<IActionResult> Index()
        {
            return View(await _context.FilmGeneres.ToListAsync());
        }

        // GET: FilmGeneres/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var filmGeneres = await _context.FilmGeneres
                .FirstOrDefaultAsync(m => m.GenereID == id);
            if (filmGeneres == null)
            {
                return NotFound();
            }

            return View(filmGeneres);
        }

        // GET: FilmGeneres/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: FilmGeneres/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("GenereID,GenreDesc")] FilmGeneres filmGeneres)
        {
            if (ModelState.IsValid)
            {
                _context.Add(filmGeneres);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(filmGeneres);
        }

        // GET: FilmGeneres/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var filmGeneres = await _context.FilmGeneres.FindAsync(id);
            if (filmGeneres == null)
            {
                return NotFound();
            }
            return View(filmGeneres);
        }

        // POST: FilmGeneres/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("GenereID,GenreDesc")] FilmGeneres filmGeneres)
        {
            if (id != filmGeneres.GenereID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(filmGeneres);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FilmGeneresExists(filmGeneres.GenereID))
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
            return View(filmGeneres);
        }

        // GET: FilmGeneres/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var filmGeneres = await _context.FilmGeneres
                .FirstOrDefaultAsync(m => m.GenereID == id);
            if (filmGeneres == null)
            {
                return NotFound();
            }

            return View(filmGeneres);
        }

        // POST: FilmGeneres/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var filmGeneres = await _context.FilmGeneres.FindAsync(id);
            _context.FilmGeneres.Remove(filmGeneres);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FilmGeneresExists(int id)
        {
            return _context.FilmGeneres.Any(e => e.GenereID == id);
        }
    }
}
