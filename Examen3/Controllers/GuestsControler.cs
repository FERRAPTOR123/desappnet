using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Examen3.Data;
using Examen3.Models;

namespace Examen3.Controllers
{
    public class GuestsController : Controller
    {
        private readonly Examen3CollectionContext _context;

        public GuestsController(Examen3CollectionContext context)
        {
            _context = context;
        }


        public async Task<IActionResult> Index()
        {
            return View(await _context.Guests.ToListAsync());
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var guests = await _context.Guests
                .FirstOrDefaultAsync(m => m.GuestID == id);
            if (guests == null)
            {
                return NotFound();
            }

            return View(guests);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ActorID,ActorFullName,ActorNotes")] Guests guests)
        {
            if (ModelState.IsValid)
            {
                _context.Add(guests);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(guests);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var guests = await _context.Guests.FindAsync(id);
            if (guests == null)
            {
                return NotFound();
            }
            return View(guests);
        }

     
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ActorID,ActorFullName,ActorNotes")] Guests guests)
        {
            if (id != guests.GuestID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(guests);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!GuestsExists(guests.GuestID))
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
            return View(guests);
        }

    
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var guests = await _context.Guests
                .FirstOrDefaultAsync(m => m.GuestID == id);
            if (guests == null)
            {
                return NotFound();
            }

            return View(guests);
        }


        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var guests = await _context.Guests.FindAsync(id);
            _context.Guests.Remove(guests);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool GuestsExists(int id)
        {
            return _context.Guests.Any(e => e.GuestID == id);
        }
    }
}
