using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using NMS.Models;
using NMS.Models.CarrierCodeViewModels;

namespace NMS.Controllers
{
    public class CarrierCodesController : Controller
    {
        private readonly nmsdbContext _context;

        public CarrierCodesController(nmsdbContext context)
        {
            _context = context;
        }

        // GET: CarrierCodes
        public async Task<IActionResult> Index()
        {
            return View(await _context.CarrierCode.ToListAsync());
        }

        // GET: CarrierCodes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var carrierCode = await _context.CarrierCode
                .SingleOrDefaultAsync(m => m.IdcarrierCode == id);
            if (carrierCode == null)
            {
                return NotFound();
            }

            return View(carrierCode);
        }

        // GET: CarrierCodes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: CarrierCodes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdcarrierCode,Priority,Status,FkCarrier,FkCode,FkLcr")] CarrierCode carrierCode)
        {
            if (ModelState.IsValid)
            {
                _context.Add(carrierCode);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(carrierCode);
        }

        // GET: CarrierCodes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var carrierCode = await _context.CarrierCode.SingleOrDefaultAsync(m => m.IdcarrierCode == id);
            if (carrierCode == null)
            {
                return NotFound();
            }
            return View(carrierCode);
        }

        // POST: CarrierCodes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdcarrierCode,Priority,Status,FkCarrier,FkCode,FkLcr")] CarrierCode carrierCode)
        {
            if (id != carrierCode.IdcarrierCode)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(carrierCode);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CarrierCodeExists(carrierCode.IdcarrierCode))
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
            return View(carrierCode);
        }

        // GET: CarrierCodes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var carrierCode = await _context.CarrierCode
                .SingleOrDefaultAsync(m => m.IdcarrierCode == id);
            if (carrierCode == null)
            {
                return NotFound();
            }

            return View(carrierCode);
        }

        // POST: CarrierCodes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var carrierCode = await _context.CarrierCode.SingleOrDefaultAsync(m => m.IdcarrierCode == id);
            _context.CarrierCode.Remove(carrierCode);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CarrierCodeExists(int id)
        {
            return _context.CarrierCode.Any(e => e.IdcarrierCode == id);
        }
    }
}
