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
    public class RoomPricesController : Controller
    {
        private readonly Examen3CollectionContext _context;

        public RoomPricesController(Examen3CollectionContext context)
        {
            _context = context;
        }


        public async Task<IActionResult> Index()
        {
            return View(await _context.RoomPrices.ToListAsync());
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var roomPrices = await _context.RoomPrices
                .FirstOrDefaultAsync(m => m.RoomPricesID == id);
            if (roomPrices == null)
            {
                return NotFound();
            }

            return View(roomPrices);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ActorID,ActorFullName,ActorNotes")] RoomPrices roomPrices)
        {
            if (ModelState.IsValid)
            {
                _context.Add(roomPrices);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(roomPrices);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var roomPrices = await _context.RoomPrices.FindAsync(id);
            if (roomPrices == null)
            {
                return NotFound();
            }
            return View(roomPrices);
        }

     
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ActorID,ActorFullName,ActorNotes")] RoomPrices roomPrices)
        {
            if (id != roomPrices.RoomPricesID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(roomPrices);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RoomPricesExists(roomPrices.RoomPricesID))
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
            return View(roomPrices);
        }

    
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var roomPrices = await _context.RoomPrices
                .FirstOrDefaultAsync(m => m.RoomPricesID == id);
            if (roomPrices == null)
            {
                return NotFound();
            }

            return View(roomPrices);
        }


        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var roomPrices = await _context.RoomPrices.FindAsync(id);
            _context.RoomPrices.Remove(roomPrices);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RoomPricesExists(int id)
        {
            return _context.RoomPrices.Any(e => e.RoomPricesID == id);
        }
    }
}
