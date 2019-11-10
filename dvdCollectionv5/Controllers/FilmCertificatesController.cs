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
    public class FilmCertificatesController : Controller
    {
        private readonly dvdCollectionContext _context;

        public FilmCertificatesController(dvdCollectionContext context)
        {
            _context = context;
        }

        // GET: FilmCertificates
        public async Task<IActionResult> Index()
        {
            return View(await _context.FilmCertificates.ToListAsync());
        }

        // GET: FilmCertificates/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var filmCertificates = await _context.FilmCertificates
                .FirstOrDefaultAsync(m => m.CertificateID == id);
            if (filmCertificates == null)
            {
                return NotFound();
            }

            return View(filmCertificates);
        }

        // GET: FilmCertificates/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: FilmCertificates/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CertificateID,FilmCertificate")] FilmCertificates filmCertificates)
        {
            if (ModelState.IsValid)
            {
                _context.Add(filmCertificates);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(filmCertificates);
        }

        // GET: FilmCertificates/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var filmCertificates = await _context.FilmCertificates.FindAsync(id);
            if (filmCertificates == null)
            {
                return NotFound();
            }
            return View(filmCertificates);
        }

        // POST: FilmCertificates/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CertificateID,FilmCertificate")] FilmCertificates filmCertificates)
        {
            if (id != filmCertificates.CertificateID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(filmCertificates);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FilmCertificatesExists(filmCertificates.CertificateID))
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
            return View(filmCertificates);
        }

        // GET: FilmCertificates/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var filmCertificates = await _context.FilmCertificates
                .FirstOrDefaultAsync(m => m.CertificateID == id);
            if (filmCertificates == null)
            {
                return NotFound();
            }

            return View(filmCertificates);
        }

        // POST: FilmCertificates/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var filmCertificates = await _context.FilmCertificates.FindAsync(id);
            _context.FilmCertificates.Remove(filmCertificates);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FilmCertificatesExists(int id)
        {
            return _context.FilmCertificates.Any(e => e.CertificateID == id);
        }
    }
}
