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
    public class RoleTypesController : Controller
    {
        private readonly dvdCollectionContext _context;

        public RoleTypesController(dvdCollectionContext context)
        {
            _context = context;
        }

        // GET: RoleTypes
        public async Task<IActionResult> Index()
        {
            return View(await _context.RoleTypes.ToListAsync());
        }

        // GET: RoleTypes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var roleTypes = await _context.RoleTypes
                .FirstOrDefaultAsync(m => m.RoleTypeID == id);
            if (roleTypes == null)
            {
                return NotFound();
            }

            return View(roleTypes);
        }

        // GET: RoleTypes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: RoleTypes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("RoleTypeID,RoleDesc")] RoleTypes roleTypes)
        {
            if (ModelState.IsValid)
            {
                _context.Add(roleTypes);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(roleTypes);
        }

        // GET: RoleTypes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var roleTypes = await _context.RoleTypes.FindAsync(id);
            if (roleTypes == null)
            {
                return NotFound();
            }
            return View(roleTypes);
        }

        // POST: RoleTypes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("RoleTypeID,RoleDesc")] RoleTypes roleTypes)
        {
            if (id != roleTypes.RoleTypeID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(roleTypes);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RoleTypesExists(roleTypes.RoleTypeID))
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
            return View(roleTypes);
        }

        // GET: RoleTypes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var roleTypes = await _context.RoleTypes
                .FirstOrDefaultAsync(m => m.RoleTypeID == id);
            if (roleTypes == null)
            {
                return NotFound();
            }

            return View(roleTypes);
        }

        // POST: RoleTypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var roleTypes = await _context.RoleTypes.FindAsync(id);
            _context.RoleTypes.Remove(roleTypes);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RoleTypesExists(int id)
        {
            return _context.RoleTypes.Any(e => e.RoleTypeID == id);
        }
    }
}
