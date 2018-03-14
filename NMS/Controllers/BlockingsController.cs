using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using NMS.Models;
using NMS.Models.BlockingViewModels;

namespace NMS.Controllers
{
    public class BlockingsController : Controller
    {
        private readonly nmsdbContext _context;

        public BlockingsController(nmsdbContext context)
        {
            _context = context;
        }

        // GET: Blockings
        public async Task<IActionResult> Index()
        {
            return View(await _context.Blocking.ToListAsync());
        }

        // GET: Blockings/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var blocking = await _context.Blocking
                .SingleOrDefaultAsync(m => m.Idblocking == id);
            if (blocking == null)
            {
                return NotFound();
            }

            return View(blocking);
        }

        // GET: Blockings/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Blockings/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Idblocking,Code,NormalisedCode,Description,FkCustomer")] Blocking blocking)
        {
            if (ModelState.IsValid)
            {
                _context.Add(blocking);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(blocking);
        }

        // GET: Blockings/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var blocking = await _context.Blocking.SingleOrDefaultAsync(m => m.Idblocking == id);
            if (blocking == null)
            {
                return NotFound();
            }
            return View(blocking);
        }

        // POST: Blockings/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Idblocking,Code,NormalisedCode,Description,FkCustomer")] Blocking blocking)
        {
            if (id != blocking.Idblocking)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(blocking);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BlockingExists(blocking.Idblocking))
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
            return View(blocking);
        }

        // GET: Blockings/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var blocking = await _context.Blocking
                .SingleOrDefaultAsync(m => m.Idblocking == id);
            if (blocking == null)
            {
                return NotFound();
            }

            return View(blocking);
        }

        // POST: Blockings/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var blocking = await _context.Blocking.SingleOrDefaultAsync(m => m.Idblocking == id);
            _context.Blocking.Remove(blocking);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BlockingExists(int id)
        {
            return _context.Blocking.Any(e => e.Idblocking == id);
        }
    }
}
