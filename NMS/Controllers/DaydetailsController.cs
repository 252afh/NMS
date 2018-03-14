using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using NMS.Models;
using NMS.Models.DayDetailsViewModels;

namespace NMS.Controllers
{
    public class DaydetailsController : Controller
    {
        private readonly nmsdbContext _context;

        public DaydetailsController(nmsdbContext context)
        {
            _context = context;
        }

        // GET: Daydetails
        public async Task<IActionResult> Index()
        {
            return View(await _context.Daydetails.ToListAsync());
        }

        // GET: Daydetails/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var daydetails = await _context.Daydetails
                .SingleOrDefaultAsync(m => m.IddayDetails == id);
            if (daydetails == null)
            {
                return NotFound();
            }

            return View(daydetails);
        }

        // GET: Daydetails/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Daydetails/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IddayDetails,Day,TimeFrom,TimeTo,Status,FkPeriod")] Daydetails daydetails)
        {
            if (ModelState.IsValid)
            {
                _context.Add(daydetails);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(daydetails);
        }

        // GET: Daydetails/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var daydetails = await _context.Daydetails.SingleOrDefaultAsync(m => m.IddayDetails == id);
            if (daydetails == null)
            {
                return NotFound();
            }
            return View(daydetails);
        }

        // POST: Daydetails/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IddayDetails,Day,TimeFrom,TimeTo,Status,FkPeriod")] Daydetails daydetails)
        {
            if (id != daydetails.IddayDetails)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(daydetails);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DaydetailsExists(daydetails.IddayDetails))
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
            return View(daydetails);
        }

        // GET: Daydetails/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var daydetails = await _context.Daydetails
                .SingleOrDefaultAsync(m => m.IddayDetails == id);
            if (daydetails == null)
            {
                return NotFound();
            }

            return View(daydetails);
        }

        // POST: Daydetails/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var daydetails = await _context.Daydetails.SingleOrDefaultAsync(m => m.IddayDetails == id);
            _context.Daydetails.Remove(daydetails);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DaydetailsExists(int id)
        {
            return _context.Daydetails.Any(e => e.IddayDetails == id);
        }
    }
}
