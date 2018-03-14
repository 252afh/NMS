using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using NMS.Models;
using NMS.Models.CarrierViewModels;

namespace NMS.Controllers
{
    public class CarriersController : Controller
    {
        private readonly nmsdbContext _context;

        public CarriersController(nmsdbContext context)
        {
            _context = context;
        }

        // GET: Carriers
        public async Task<IActionResult> Index()
        {
            return View(await _context.Carrier.ToListAsync());
        }

        // GET: Carriers/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var carrier = await _context.Carrier
                .SingleOrDefaultAsync(m => m.Idcarrier == id);
            if (carrier == null)
            {
                return NotFound();
            }

            return View(carrier);
        }

        // GET: Carriers/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Carriers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Idcarrier,Name,Description,Domain,RoutingNumber,BillingNumber,Preference")] Carrier carrier)
        {
            if (ModelState.IsValid)
            {
                _context.Add(carrier);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(carrier);
        }

        // GET: Carriers/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var carrier = await _context.Carrier.SingleOrDefaultAsync(m => m.Idcarrier == id);
            if (carrier == null)
            {
                return NotFound();
            }
            return View(carrier);
        }

        // POST: Carriers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Idcarrier,Name,Description,Domain,RoutingNumber,BillingNumber,Preference")] Carrier carrier)
        {
            if (id != carrier.Idcarrier)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(carrier);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CarrierExists(carrier.Idcarrier))
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
            return View(carrier);
        }

        // GET: Carriers/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var carrier = await _context.Carrier
                .SingleOrDefaultAsync(m => m.Idcarrier == id);
            if (carrier == null)
            {
                return NotFound();
            }

            return View(carrier);
        }

        // POST: Carriers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var carrier = await _context.Carrier.SingleOrDefaultAsync(m => m.Idcarrier == id);
            _context.Carrier.Remove(carrier);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CarrierExists(int id)
        {
            return _context.Carrier.Any(e => e.Idcarrier == id);
        }
    }
}
