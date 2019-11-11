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
    public class PaymentMethodsController : Controller
    {
        private readonly Examen3CollectionContext _context;

        public PaymentMethodsController(Examen3CollectionContext context)
        {
            _context = context;
        }


        public async Task<IActionResult> Index()
        {
            return View(await _context.PaymentMethods.ToListAsync());
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var paymentMethods = await _context.PaymentMethods
                .FirstOrDefaultAsync(m => m.PaymentMethodsID == id);
            if (paymentMethods == null)
            {
                return NotFound();
            }

            return View(paymentMethods);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ActorID,ActorFullName,ActorNotes")] PaymentMethods paymentMethods)
        {
            if (ModelState.IsValid)
            {
                _context.Add(paymentMethods);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(paymentMethods);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var paymentMethods = await _context.PaymentMethods.FindAsync(id);
            if (paymentMethods == null)
            {
                return NotFound();
            }
            return View(paymentMethods);
        }

     
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ActorID,ActorFullName,ActorNotes")] PaymentMethods paymentMethods)
        {
            if (id != paymentMethods.PaymentMethodsID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(paymentMethods);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PaymentMethodsExists(paymentMethods.PaymentMethodsID))
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
            return View(paymentMethods);
        }

    
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var paymentMethods = await _context.PaymentMethods
                .FirstOrDefaultAsync(m => m.PaymentMethodsID == id);
            if (paymentMethods == null)
            {
                return NotFound();
            }

            return View(paymentMethods);
        }


        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var paymentMethods = await _context.PaymentMethods.FindAsync(id);
            _context.PaymentMethods.Remove(paymentMethods);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PaymentMethodsExists(int id)
        {
            return _context.PaymentMethods.Any(e => e.PaymentMethodsID == id);
        }
    }
}
