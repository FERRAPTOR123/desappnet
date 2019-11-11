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
    public class RoomBandsController : Controller
    {
        private readonly Examen3CollectionContext _context;

        public RoomBandsController(Examen3CollectionContext context)
        {
            _context = context;
        }


        public async Task<IActionResult> Index()
        {
            return View(await _context.RoomBands.ToListAsync());
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var roomBands = await _context.RoomBands
                .FirstOrDefaultAsync(m => m.RoomBandsID == id);
            if (roomBands == null)
            {
                return NotFound();
            }

            return View(roomBands);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ActorID,ActorFullName,ActorNotes")] RoomBands roomBands)
        {
            if (ModelState.IsValid)
            {
                _context.Add(roomBands);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(roomBands);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var roomBands = await _context.RoomBands.FindAsync(id);
            if (roomBands == null)
            {
                return NotFound();
            }
            return View(roomBands);
        }

     
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ActorID,ActorFullName,ActorNotes")] RoomBands roomBands)
        {
            if (id != roomBands.RoomBandsID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(roomBands);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RoomBandsExists(roomBands.RoomBandsID))
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
            return View(roomBands);
        }

    
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var roomBands = await _context.RoomBands
                .FirstOrDefaultAsync(m => m.RoomBandsID == id);
            if (roomBands == null)
            {
                return NotFound();
            }

            return View(roomBands);
        }


        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var roomBands = await _context.RoomBands.FindAsync(id);
            _context.RoomBands.Remove(roomBands);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RoomBandsExists(int id)
        {
            return _context.RoomBands.Any(e => e.RoomBandsID == id);
        }
    }
}
