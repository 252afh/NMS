using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using NMS.Models;
using NMS.Models.IvrViewModels;

namespace NMS.Controllers
{
    public class IvrsController : Controller
    {
        private readonly nmsdbContext _context;

        public IvrsController(nmsdbContext context)
        {
            _context = context;
        }

        // GET: Ivrs
        public async Task<IActionResult> Index()
        {
            return View(await _context.Ivr.ToListAsync());
        }

        // GET: Ivrs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ivr = await _context.Ivr
                .SingleOrDefaultAsync(m => m.Idivr == id);
            if (ivr == null)
            {
                return NotFound();
            }

            return View(ivr);
        }

        // GET: Ivrs/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Ivrs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Idivr,Name,Description,Audiomessage,Audioname,Audiosize,Repeattimes,Timeout,FkCustomer")] Ivr ivr)
        {
            if (ModelState.IsValid)
            {
                _context.Add(ivr);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(ivr);
        }

        // GET: Ivrs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ivr = await _context.Ivr.SingleOrDefaultAsync(m => m.Idivr == id);
            if (ivr == null)
            {
                return NotFound();
            }
            return View(ivr);
        }

        // POST: Ivrs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Idivr,Name,Description,Audiomessage,Audioname,Audiosize,Repeattimes,Timeout,FkCustomer")] Ivr ivr)
        {
            if (id != ivr.Idivr)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(ivr);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!IvrExists(ivr.Idivr))
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
            return View(ivr);
        }

        // GET: Ivrs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ivr = await _context.Ivr
                .SingleOrDefaultAsync(m => m.Idivr == id);
            if (ivr == null)
            {
                return NotFound();
            }

            return View(ivr);
        }

        // POST: Ivrs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var ivr = await _context.Ivr.SingleOrDefaultAsync(m => m.Idivr == id);
            _context.Ivr.Remove(ivr);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool IvrExists(int id)
        {
            return _context.Ivr.Any(e => e.Idivr == id);
        }
    }
}
