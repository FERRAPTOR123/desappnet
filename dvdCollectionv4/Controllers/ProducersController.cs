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
    public class ProducersController : Controller
    {
        private readonly dvdCollectionContext _context;

        public ProducersController(dvdCollectionContext context)
        {
            _context = context;
        }

        // GET: Producers
        public async Task<IActionResult> Index()
        {
            return View(await _context.Producers.ToListAsync());
        }

        // GET: Producers/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var producers = await _context.Producers
                .FirstOrDefaultAsync(m => m.ProducerID == id);
            if (producers == null)
            {
                return NotFound();
            }

            return View(producers);
        }

        // GET: Producers/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Producers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ProducerID,ProducerName,ContactEmailAddress,WebSite")] Producers producers)
        {
            if (ModelState.IsValid)
            {
                _context.Add(producers);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(producers);
        }

        // GET: Producers/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var producers = await _context.Producers.FindAsync(id);
            if (producers == null)
            {
                return NotFound();
            }
            return View(producers);
        }

        // POST: Producers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ProducerID,ProducerName,ContactEmailAddress,WebSite")] Producers producers)
        {
            if (id != producers.ProducerID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(producers);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProducersExists(producers.ProducerID))
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
            return View(producers);
        }

        // GET: Producers/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var producers = await _context.Producers
                .FirstOrDefaultAsync(m => m.ProducerID == id);
            if (producers == null)
            {
                return NotFound();
            }

            return View(producers);
        }

        // POST: Producers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var producers = await _context.Producers.FindAsync(id);
            _context.Producers.Remove(producers);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProducersExists(int id)
        {
            return _context.Producers.Any(e => e.ProducerID == id);
        }
    }
}
