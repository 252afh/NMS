using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using NMS.Models;
using NMS.Models.NumberFormatViewModels;

namespace NMS.Controllers
{
    public class NumberformatsController : Controller
    {
        private readonly nmsdbContext _context;

        public NumberformatsController(nmsdbContext context)
        {
            _context = context;
        }

        // GET: Numberformats
        public async Task<IActionResult> Index()
        {
            return View(await _context.Numberformat.ToListAsync());
        }

        // GET: Numberformats/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var numberformat = await _context.Numberformat
                .SingleOrDefaultAsync(m => m.IdnumberFormat == id);
            if (numberformat == null)
            {
                return NotFound();
            }

            return View(numberformat);
        }

        // GET: Numberformats/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Numberformats/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdnumberFormat,NumberFormat,Description,Name")] Numberformat numberformat)
        {
            if (ModelState.IsValid)
            {
                _context.Add(numberformat);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(numberformat);
        }

        // GET: Numberformats/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var numberformat = await _context.Numberformat.SingleOrDefaultAsync(m => m.IdnumberFormat == id);
            if (numberformat == null)
            {
                return NotFound();
            }
            return View(numberformat);
        }

        // POST: Numberformats/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdnumberFormat,NumberFormat,Description,Name")] Numberformat numberformat)
        {
            if (id != numberformat.IdnumberFormat)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(numberformat);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!NumberformatExists(numberformat.IdnumberFormat))
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
            return View(numberformat);
        }

        // GET: Numberformats/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var numberformat = await _context.Numberformat
                .SingleOrDefaultAsync(m => m.IdnumberFormat == id);
            if (numberformat == null)
            {
                return NotFound();
            }

            return View(numberformat);
        }

        // POST: Numberformats/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var numberformat = await _context.Numberformat.SingleOrDefaultAsync(m => m.IdnumberFormat == id);
            _context.Numberformat.Remove(numberformat);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool NumberformatExists(int id)
        {
            return _context.Numberformat.Any(e => e.IdnumberFormat == id);
        }
    }
}
