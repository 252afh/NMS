using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using NMS.Models;
using NMS.Models.IvrActionViewModels;

namespace NMS.Controllers
{
    public class IvractionsController : Controller
    {
        private readonly nmsdbContext _context;

        public IvractionsController(nmsdbContext context)
        {
            _context = context;
        }

        // GET: Ivractions
        public async Task<IActionResult> Index()
        {
            return View(await _context.Ivraction.ToListAsync());
        }

        // GET: Ivractions/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ivraction = await _context.Ivraction
                .SingleOrDefaultAsync(m => m.Idivraction == id);
            if (ivraction == null)
            {
                return NotFound();
            }

            return View(ivraction);
        }

        // GET: Ivractions/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Ivractions/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Idivraction,Digit,FkIvr,FkIvrDest,FkContactDest,FkAnnouncementDest,FkMailboxDest,VoicemailMain")] Ivraction ivraction)
        {
            if (ModelState.IsValid)
            {
                _context.Add(ivraction);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(ivraction);
        }

        // GET: Ivractions/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ivraction = await _context.Ivraction.SingleOrDefaultAsync(m => m.Idivraction == id);
            if (ivraction == null)
            {
                return NotFound();
            }
            return View(ivraction);
        }

        // POST: Ivractions/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Idivraction,Digit,FkIvr,FkIvrDest,FkContactDest,FkAnnouncementDest,FkMailboxDest,VoicemailMain")] Ivraction ivraction)
        {
            if (id != ivraction.Idivraction)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(ivraction);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!IvractionExists(ivraction.Idivraction))
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
            return View(ivraction);
        }

        // GET: Ivractions/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ivraction = await _context.Ivraction
                .SingleOrDefaultAsync(m => m.Idivraction == id);
            if (ivraction == null)
            {
                return NotFound();
            }

            return View(ivraction);
        }

        // POST: Ivractions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var ivraction = await _context.Ivraction.SingleOrDefaultAsync(m => m.Idivraction == id);
            _context.Ivraction.Remove(ivraction);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool IvractionExists(int id)
        {
            return _context.Ivraction.Any(e => e.Idivraction == id);
        }
    }
}
