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
    public class BookingsRoomsController : Controller
    {
        private readonly Examen3CollectionContext _context;

        public BookingsRoomsController(Examen3CollectionContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _context.BookingsRooms.ToListAsync());
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bookingsRooms = await _context.BookingsRooms
                .FirstOrDefaultAsync(m => m.BookingsRoomsID == id);
            if (bookingsRooms == null)
            {
                return NotFound();
            }

            return View(bookingsRooms);
        }


        public IActionResult Create()
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ActorID,ActorFullName,ActorNotes")] BookingsRooms bookings)
        {
            if (ModelState.IsValid)
            {
                _context.Add(bookings);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(bookings);
        }
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bookingsRooms = await _context.BookingsRooms.FindAsync(id);
            if (bookingsRooms == null)
            {
                return NotFound();
            }
            return View(bookingsRooms);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ActorID,ActorFullName,ActorNotes")] BookingsRooms bookings)
        {
            if (id != bookings.BookingsRoomsID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(bookings);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BookingsRoomsExists(bookings.BookingsRoomsID))
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
            return View(bookings);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bookingsRooms = await _context.BookingsRooms
                .FirstOrDefaultAsync(m => m.BookingsRoomsID == id);
            if (bookingsRooms == null)
            {
                return NotFound();
            }

            return View(bookingsRooms);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var bookingsRooms = await _context.BookingsRooms.FindAsync(id);
            _context.BookingsRooms.Remove(bookingsRooms);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BookingsRoomsExists(int id)
        {
            return _context.BookingsRooms.Any(e => e.BookingsRoomsID == id);
        }
    }
}
