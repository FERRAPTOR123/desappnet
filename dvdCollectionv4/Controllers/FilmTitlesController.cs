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
    public class FilmTitlesController : Controller
    {
        private readonly dvdCollectionContext _context;

        public FilmTitlesController(dvdCollectionContext context)
        {
            _context = context;
        }

        // GET: FilmTitles
        public async Task<IActionResult> Index()
        {
            var dvdCollectionContext = _context.FilmTitles.Include(f => f.FilmCertificate).Include(f => f.FilmGenere);
            return View(await dvdCollectionContext.ToListAsync());
        }

        // GET: FilmTitles/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var filmTitles = await _context.FilmTitles
                .Include(f => f.FilmCertificate)
                .Include(f => f.FilmGenere)
                .FirstOrDefaultAsync(m => m.FilmTitleID == id);
            if (filmTitles == null)
            {
                return NotFound();
            }

            return View(filmTitles);
        }

        // GET: FilmTitles/Create
        public IActionResult Create()
        {
            ViewData["FilmCertificateID"] = new SelectList(_context.FilmCertificates, "CertificateID", "FilmCertificate");
            ViewData["FilmGenereID"] = new SelectList(_context.FilmGeneres, "GenereID", "GenreDesc");
            return View();
        }

        // POST: FilmTitles/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("FilmTitleID,FilmTitle,FilmStory,FilmRelaseDate,FilmDuration,FilmGenereID,FilmCertificateID,FilmAdditionalInfo")] FilmTitles filmTitles)
        {
            if (ModelState.IsValid)
            {
                _context.Add(filmTitles);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["FilmCertificateID"] = new SelectList(_context.FilmCertificates, "CertificateID", "FilmCertificate", filmTitles.FilmCertificateID);
            ViewData["FilmGenereID"] = new SelectList(_context.FilmGeneres, "GenereID", "GenreDesc", filmTitles.FilmGenereID);
            return View(filmTitles);
        }

        // GET: FilmTitles/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var filmTitles = await _context.FilmTitles.FindAsync(id);
            if (filmTitles == null)
            {
                return NotFound();
            }
            ViewData["FilmCertificateID"] = new SelectList(_context.FilmCertificates, "CertificateID", "FilmCertificate", filmTitles.FilmCertificateID);
            ViewData["FilmGenereID"] = new SelectList(_context.FilmGeneres, "GenereID", "GenreDesc", filmTitles.FilmGenereID);
            return View(filmTitles);
        }

        // POST: FilmTitles/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("FilmTitleID,FilmTitle,FilmStory,FilmRelaseDate,FilmDuration,FilmGenereID,FilmCertificateID,FilmAdditionalInfo")] FilmTitles filmTitles)
        {
            if (id != filmTitles.FilmTitleID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(filmTitles);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FilmTitlesExists(filmTitles.FilmTitleID))
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
            ViewData["FilmCertificateID"] = new SelectList(_context.FilmCertificates, "CertificateID", "FilmCertificate", filmTitles.FilmCertificateID);
            ViewData["FilmGenereID"] = new SelectList(_context.FilmGeneres, "GenereID", "GenreDesc", filmTitles.FilmGenereID);
            return View(filmTitles);
        }

        // GET: FilmTitles/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var filmTitles = await _context.FilmTitles
                .Include(f => f.FilmCertificate)
                .Include(f => f.FilmGenere)
                .FirstOrDefaultAsync(m => m.FilmTitleID == id);
            if (filmTitles == null)
            {
                return NotFound();
            }

            return View(filmTitles);
        }

        // POST: FilmTitles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var filmTitles = await _context.FilmTitles.FindAsync(id);
            _context.FilmTitles.Remove(filmTitles);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FilmTitlesExists(int id)
        {
            return _context.FilmTitles.Any(e => e.FilmTitleID == id);
        }
    }
}
