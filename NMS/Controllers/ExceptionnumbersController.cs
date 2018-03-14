using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using NMS.Models;
using NMS.Models.ExceptionNumberViewModels;

namespace NMS.Controllers
{
    public class ExceptionnumbersController : Controller
    {
        private readonly nmsdbContext _context;

        public ExceptionnumbersController(nmsdbContext context)
        {
            _context = context;
        }

        // GET: Exceptionnumbers
        public async Task<IActionResult> Index()
        {
            return View(await _context.Exceptionnumber.ToListAsync());
        }

        // GET: Exceptionnumbers/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var exceptionnumber = await _context.Exceptionnumber
                .SingleOrDefaultAsync(m => m.IdexceptionNumber == id);
            if (exceptionnumber == null)
            {
                return NotFound();
            }

            return View(exceptionnumber);
        }

        // GET: Exceptionnumbers/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Exceptionnumbers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdexceptionNumber,Number,Description")] Exceptionnumber exceptionnumber)
        {
            if (ModelState.IsValid)
            {
                _context.Add(exceptionnumber);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(exceptionnumber);
        }

        // GET: Exceptionnumbers/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var exceptionnumber = await _context.Exceptionnumber.SingleOrDefaultAsync(m => m.IdexceptionNumber == id);
            if (exceptionnumber == null)
            {
                return NotFound();
            }
            return View(exceptionnumber);
        }

        // POST: Exceptionnumbers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdexceptionNumber,Number,Description")] Exceptionnumber exceptionnumber)
        {
            if (id != exceptionnumber.IdexceptionNumber)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(exceptionnumber);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ExceptionnumberExists(exceptionnumber.IdexceptionNumber))
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
            return View(exceptionnumber);
        }

        // GET: Exceptionnumbers/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var exceptionnumber = await _context.Exceptionnumber
                .SingleOrDefaultAsync(m => m.IdexceptionNumber == id);
            if (exceptionnumber == null)
            {
                return NotFound();
            }

            return View(exceptionnumber);
        }

        // POST: Exceptionnumbers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var exceptionnumber = await _context.Exceptionnumber.SingleOrDefaultAsync(m => m.IdexceptionNumber == id);
            _context.Exceptionnumber.Remove(exceptionnumber);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ExceptionnumberExists(int id)
        {
            return _context.Exceptionnumber.Any(e => e.IdexceptionNumber == id);
        }
    }
}
