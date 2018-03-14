using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using NMS.Models;
using NMS.Models.LcrViewModels;

namespace NMS.Controllers
{
    public class LcrsController : Controller
    {
        private readonly nmsdbContext _context;

        public LcrsController(nmsdbContext context)
        {
            _context = context;
        }

        // GET: Lcrs
        public async Task<IActionResult> Index()
        {
            return View(await _context.Lcr.ToListAsync());
        }

        // GET: Lcrs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var lcr = await _context.Lcr
                .SingleOrDefaultAsync(m => m.Idlcr == id);
            if (lcr == null)
            {
                return NotFound();
            }

            return View(lcr);
        }

        // GET: Lcrs/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Lcrs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Idlcr,Name,Description")] Lcr lcr)
        {
            if (ModelState.IsValid)
            {
                _context.Add(lcr);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(lcr);
        }

        // GET: Lcrs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var lcr = await _context.Lcr.SingleOrDefaultAsync(m => m.Idlcr == id);
            if (lcr == null)
            {
                return NotFound();
            }
            return View(lcr);
        }

        // POST: Lcrs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Idlcr,Name,Description")] Lcr lcr)
        {
            if (id != lcr.Idlcr)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(lcr);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LcrExists(lcr.Idlcr))
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
            return View(lcr);
        }

        // GET: Lcrs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var lcr = await _context.Lcr
                .SingleOrDefaultAsync(m => m.Idlcr == id);
            if (lcr == null)
            {
                return NotFound();
            }

            return View(lcr);
        }

        // POST: Lcrs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var lcr = await _context.Lcr.SingleOrDefaultAsync(m => m.Idlcr == id);
            _context.Lcr.Remove(lcr);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool LcrExists(int id)
        {
            return _context.Lcr.Any(e => e.Idlcr == id);
        }
    }
}
