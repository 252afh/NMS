using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using NMS.Models;
using NMS.Models.BarringViewModels;

namespace NMS.Controllers
{
    public class BarringsController : Controller
    {
        private readonly nmsdbContext _context;

        public BarringsController(nmsdbContext context)
        {
            _context = context;
        }

        // GET: Barrings
        public async Task<IActionResult> Index()
        {
            return View(await _context.Barring.ToListAsync());
        }

        // GET: Barrings/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var barring = await _context.Barring
                .SingleOrDefaultAsync(m => m.Idbarring == id);
            if (barring == null)
            {
                return NotFound();
            }

            return View(barring);
        }

        // GET: Barrings/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Barrings/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Idbarring,Code,NormalisedCode,Description,Status,FkCustomer")] Barring barring)
        {
            if (ModelState.IsValid)
            {
                _context.Add(barring);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(barring);
        }

        // GET: Barrings/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var barring = await _context.Barring.SingleOrDefaultAsync(m => m.Idbarring == id);
            if (barring == null)
            {
                return NotFound();
            }
            return View(barring);
        }

        // POST: Barrings/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Idbarring,Code,NormalisedCode,Description,Status,FkCustomer")] Barring barring)
        {
            if (id != barring.Idbarring)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(barring);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BarringExists(barring.Idbarring))
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
            return View(barring);
        }

        // GET: Barrings/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var barring = await _context.Barring
                .SingleOrDefaultAsync(m => m.Idbarring == id);
            if (barring == null)
            {
                return NotFound();
            }

            return View(barring);
        }

        // POST: Barrings/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var barring = await _context.Barring.SingleOrDefaultAsync(m => m.Idbarring == id);
            _context.Barring.Remove(barring);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BarringExists(int id)
        {
            return _context.Barring.Any(e => e.Idbarring == id);
        }
    }
}
