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
    public class RoomTypesController : Controller
    {
        private readonly Examen3CollectionContext _context;

        public RoomTypesController(Examen3CollectionContext context)
        {
            _context = context;
        }


        public async Task<IActionResult> Index()
        {
            return View(await _context.RoomTypes.ToListAsync());
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var roomsTypes = await _context.RoomTypes
                .FirstOrDefaultAsync(m => m.RoomTypesID == id);
            if (roomsTypes == null)
            {
                return NotFound();
            }

            return View(roomsTypes);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ActorID,ActorFullName,ActorNotes")] RoomTypes roomsTypes)
        {
            if (ModelState.IsValid)
            {
                _context.Add(roomsTypes);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(roomsTypes);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var roomsTypes = await _context.RoomTypes.FindAsync(id);
            if (roomsTypes == null)
            {
                return NotFound();
            }
            return View(roomsTypes);
        }

     
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ActorID,ActorFullName,ActorNotes")] RoomTypes roomsTypes)
        {
            if (id != roomsTypes.RoomTypesID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(roomsTypes);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RoomTypesExists(roomsTypes.RoomTypesID))
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
            return View(roomsTypes);
        }

    
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var roomsTypes = await _context.RoomTypes
                .FirstOrDefaultAsync(m => m.RoomTypesID == id);
            if (roomsTypes == null)
            {
                return NotFound();
            }

            return View(roomsTypes);
        }


        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var roomsTypes = await _context.RoomTypes.FindAsync(id);
            _context.RoomTypes.Remove(roomsTypes);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RoomTypesExists(int id)
        {
            return _context.RoomTypes.Any(e => e.RoomTypesID == id);
        }
    }
}
