using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using NMS.Models;
using NMS.Models.CustomLcrModels;

namespace NMS.Controllers
{
    public class CustomLcrController : Controller
    {
        private readonly NMSDBContext _context;

        public CustomLcrController(NMSDBContext context)
        {
            _context = context;
        }

        // GET: CustomLcrs
        public async Task<IActionResult> Index()
        {
            return View(await _context.CustomLcr.ToListAsync());
        }

        // GET: CustomLcrs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var CustomLcr = await _context.CustomLcr
                .SingleOrDefaultAsync(m => m.IdCustomLcr == id);
            if (CustomLcr == null)
            {
                return NotFound();
            }

            return View(CustomLcr);
        }

        // GET: CustomLcrs/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: CustomLcr/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdCustomLcr,Name,Description")] CustomLcr CustomLcr)
        {
            if (ModelState.IsValid)
            {
                _context.Add(CustomLcr);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(CustomLcr);
        }

        // GET: Customlcrs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var CustomLcr = await _context.CustomLcr.SingleOrDefaultAsync(m => m.IdCustomLcr == id);
            if (CustomLcr == null)
            {
                return NotFound();
            }
            return View(CustomLcr);
        }

        // POST: Customlcrs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdCustomLcr,Name,Description")] CustomLcr CustomLcr)
        {
            if (id != CustomLcr.IdCustomLcr)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(CustomLcr);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CustomlcrExists(CustomLcr.IdCustomLcr))
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
            return View(CustomLcr);
        }

        // GET: Customlcrs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var CustomLcr = await _context.CustomLcr
                .SingleOrDefaultAsync(m => m.IdCustomLcr == id);
            if (CustomLcr == null)
            {
                return NotFound();
            }

            return View(CustomLcr);
        }

        // POST: Customlcrs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var CustomLcr = await _context.CustomLcr.SingleOrDefaultAsync(m => m.IdCustomLcr == id);
            _context.CustomLcr.Remove(CustomLcr);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CustomlcrExists(int id)
        {
            return _context.CustomLcr.Any(e => e.IdCustomLcr == id);
        }
    }
}
