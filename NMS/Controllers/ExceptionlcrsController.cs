using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using NMS.Models;
using NMS.Models.ExceptionLcrViewModels;

namespace NMS.Controllers
{
    public class ExceptionlcrsController : Controller
    {
        private readonly nmsdbContext _context;

        public ExceptionlcrsController(nmsdbContext context)
        {
            _context = context;
        }

        // GET: Exceptionlcrs
        public async Task<IActionResult> Index()
        {
            return View(await _context.Exceptionlcr.ToListAsync());
        }

        // GET: Exceptionlcrs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var exceptionlcr = await _context.Exceptionlcr
                .SingleOrDefaultAsync(m => m.IdexceptionLcr == id);
            if (exceptionlcr == null)
            {
                return NotFound();
            }

            return View(exceptionlcr);
        }

        // GET: Exceptionlcrs/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Exceptionlcrs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdexceptionLcr,Name,Description")] Exceptionlcr exceptionlcr)
        {
            if (ModelState.IsValid)
            {
                _context.Add(exceptionlcr);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(exceptionlcr);
        }

        // GET: Exceptionlcrs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var exceptionlcr = await _context.Exceptionlcr.SingleOrDefaultAsync(m => m.IdexceptionLcr == id);
            if (exceptionlcr == null)
            {
                return NotFound();
            }
            return View(exceptionlcr);
        }

        // POST: Exceptionlcrs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdexceptionLcr,Name,Description")] Exceptionlcr exceptionlcr)
        {
            if (id != exceptionlcr.IdexceptionLcr)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(exceptionlcr);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ExceptionlcrExists(exceptionlcr.IdexceptionLcr))
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
            return View(exceptionlcr);
        }

        // GET: Exceptionlcrs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var exceptionlcr = await _context.Exceptionlcr
                .SingleOrDefaultAsync(m => m.IdexceptionLcr == id);
            if (exceptionlcr == null)
            {
                return NotFound();
            }

            return View(exceptionlcr);
        }

        // POST: Exceptionlcrs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var exceptionlcr = await _context.Exceptionlcr.SingleOrDefaultAsync(m => m.IdexceptionLcr == id);
            _context.Exceptionlcr.Remove(exceptionlcr);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ExceptionlcrExists(int id)
        {
            return _context.Exceptionlcr.Any(e => e.IdexceptionLcr == id);
        }
    }
}
