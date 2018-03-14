using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using NMS.Models;
using NMS.Models.CarrierNumberExceptionViewModels;

namespace NMS.Controllers
{
    public class CarrierNumberExceptionsController : Controller
    {
        private readonly nmsdbContext _context;

        public CarrierNumberExceptionsController(nmsdbContext context)
        {
            _context = context;
        }

        // GET: CarrierNumberExceptions
        public async Task<IActionResult> Index()
        {
            return View(await _context.CarrierNumberException.ToListAsync());
        }

        // GET: CarrierNumberExceptions/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var carrierNumberException = await _context.CarrierNumberException
                .SingleOrDefaultAsync(m => m.IdcarrierNumberException == id);
            if (carrierNumberException == null)
            {
                return NotFound();
            }

            return View(carrierNumberException);
        }

        // GET: CarrierNumberExceptions/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: CarrierNumberExceptions/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdcarrierNumberException,Priority,Status,FkCarrier,FkExceptionNumber,FkExceptionLcr")] CarrierNumberException carrierNumberException)
        {
            if (ModelState.IsValid)
            {
                _context.Add(carrierNumberException);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(carrierNumberException);
        }

        // GET: CarrierNumberExceptions/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var carrierNumberException = await _context.CarrierNumberException.SingleOrDefaultAsync(m => m.IdcarrierNumberException == id);
            if (carrierNumberException == null)
            {
                return NotFound();
            }
            return View(carrierNumberException);
        }

        // POST: CarrierNumberExceptions/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdcarrierNumberException,Priority,Status,FkCarrier,FkExceptionNumber,FkExceptionLcr")] CarrierNumberException carrierNumberException)
        {
            if (id != carrierNumberException.IdcarrierNumberException)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(carrierNumberException);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CarrierNumberExceptionExists(carrierNumberException.IdcarrierNumberException))
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
            return View(carrierNumberException);
        }

        // GET: CarrierNumberExceptions/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var carrierNumberException = await _context.CarrierNumberException
                .SingleOrDefaultAsync(m => m.IdcarrierNumberException == id);
            if (carrierNumberException == null)
            {
                return NotFound();
            }

            return View(carrierNumberException);
        }

        // POST: CarrierNumberExceptions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var carrierNumberException = await _context.CarrierNumberException.SingleOrDefaultAsync(m => m.IdcarrierNumberException == id);
            _context.CarrierNumberException.Remove(carrierNumberException);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CarrierNumberExceptionExists(int id)
        {
            return _context.CarrierNumberException.Any(e => e.IdcarrierNumberException == id);
        }
    }
}
