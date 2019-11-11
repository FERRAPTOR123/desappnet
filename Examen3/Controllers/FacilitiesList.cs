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
    public class FacilitiesListController : Controller
    {
        private readonly Examen3CollectionContext _context;

        public FacilitiesListController(Examen3CollectionContext context)
        {
            _context = context;
        }


        public async Task<IActionResult> Index()
        {
            return View(await _context.FacilitiesList.ToListAsync());
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var facilities = await _context.FacilitiesList
                .FirstOrDefaultAsync(m => m.FacilityID == id);
            if (facilities == null)
            {
                return NotFound();
            }

            return View(facilities);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ActorID,ActorFullName,ActorNotes")] FacilitiesList facilities)
        {
            if (ModelState.IsValid)
            {
                _context.Add(facilities);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(facilities);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var facilities = await _context.FacilitiesList.FindAsync(id);
            if (facilities == null)
            {
                return NotFound();
            }
            return View(facilities);
        }

     
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ActorID,ActorFullName,ActorNotes")] FacilitiesList facilities)
        {
            if (id != facilities.FacilityID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(facilities);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FacilitiesListExists(facilities.FacilityID))
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
            return View(facilities);
        }

    
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var facilities = await _context.FacilitiesList
                .FirstOrDefaultAsync(m => m.FacilityID == id);
            if (facilities == null)
            {
                return NotFound();
            }

            return View(facilities);
        }


        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var facilities = await _context.FacilitiesList.FindAsync(id);
            _context.FacilitiesList.Remove(facilities);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FacilitiesListExists(int id)
        {
            return _context.FacilitiesList.Any(e => e.FacilityID == id);
        }
    }
}
