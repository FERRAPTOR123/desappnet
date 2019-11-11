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
    public class RoomsFacilitiesController : Controller
    {
        private readonly Examen3CollectionContext _context;

        public RoomsFacilitiesController(Examen3CollectionContext context)
        {
            _context = context;
        }


        public async Task<IActionResult> Index()
        {
            return View(await _context.RoomsFacilities.ToListAsync());
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var roomsFacilities = await _context.RoomsFacilities
                .FirstOrDefaultAsync(m => m.RoomID == id);
            if (roomsFacilities == null)
            {
                return NotFound();
            }

            return View(roomsFacilities);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ActorID,ActorFullName,ActorNotes")] RoomsFacilities roomsFacilities)
        {
            if (ModelState.IsValid)
            {
                _context.Add(roomsFacilities);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(roomsFacilities);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var roomsFacilities = await _context.RoomsFacilities.FindAsync(id);
            if (roomsFacilities == null)
            {
                return NotFound();
            }
            return View(roomsFacilities);
        }

     
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ActorID,ActorFullName,ActorNotes")] RoomsFacilities roomsFacilities)
        {
            if (id != roomsFacilities.RoomID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(roomsFacilities);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RoomsFacilitiesExists(roomsFacilities.RoomID))
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
            return View(roomsFacilities);
        }

    
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var roomsFacilities = await _context.RoomsFacilities
                .FirstOrDefaultAsync(m => m.RoomID == id);
            if (roomsFacilities == null)
            {
                return NotFound();
            }

            return View(roomsFacilities);
        }


        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var roomsFacilities = await _context.RoomsFacilities.FindAsync(id);
            _context.RoomsFacilities.Remove(roomsFacilities);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RoomsFacilitiesExists(int id)
        {
            return _context.RoomsFacilities.Any(e => e.RoomID == id);
        }
    }
}
