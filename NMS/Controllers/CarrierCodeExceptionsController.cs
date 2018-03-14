using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using NMS.Models;
using NMS.Models.CarrierCodeExceptionViewModels;

namespace NMS.Controllers
{
    public class CarrierCodeExceptionsController : Controller
    {
        private readonly nmsdbContext _context;

        public CarrierCodeExceptionsController(nmsdbContext context)
        {
            _context = context;
        }

        // GET: CarrierCodeExceptions
        public async Task<IActionResult> Index()
        {
            return View(await _context.CarrierCodeException.ToListAsync());
        }

        // GET: CarrierCodeExceptions/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var carrierCodeException = await _context.CarrierCodeException
                .SingleOrDefaultAsync(m => m.IdcarrierCodeException == id);
            if (carrierCodeException == null)
            {
                return NotFound();
            }

            return View(carrierCodeException);
        }

        // GET: CarrierCodeExceptions/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: CarrierCodeExceptions/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdcarrierCodeException,Priority,Status,FkCarrier,FkCode,FkExceptionLcr")] CarrierCodeException carrierCodeException)
        {
            if (ModelState.IsValid)
            {
                _context.Add(carrierCodeException);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(carrierCodeException);
        }

        // GET: CarrierCodeExceptions/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var carrierCodeException = await _context.CarrierCodeException.SingleOrDefaultAsync(m => m.IdcarrierCodeException == id);
            if (carrierCodeException == null)
            {
                return NotFound();
            }
            return View(carrierCodeException);
        }

        // POST: CarrierCodeExceptions/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdcarrierCodeException,Priority,Status,FkCarrier,FkCode,FkExceptionLcr")] CarrierCodeException carrierCodeException)
        {
            if (id != carrierCodeException.IdcarrierCodeException)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(carrierCodeException);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CarrierCodeExceptionExists(carrierCodeException.IdcarrierCodeException))
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
            return View(carrierCodeException);
        }

        // GET: CarrierCodeExceptions/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var carrierCodeException = await _context.CarrierCodeException
                .SingleOrDefaultAsync(m => m.IdcarrierCodeException == id);
            if (carrierCodeException == null)
            {
                return NotFound();
            }

            return View(carrierCodeException);
        }

        // POST: CarrierCodeExceptions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var carrierCodeException = await _context.CarrierCodeException.SingleOrDefaultAsync(m => m.IdcarrierCodeException == id);
            _context.CarrierCodeException.Remove(carrierCodeException);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CarrierCodeExceptionExists(int id)
        {
            return _context.CarrierCodeException.Any(e => e.IdcarrierCodeException == id);
        }
    }
}
