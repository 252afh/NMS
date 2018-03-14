using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using NMS.Models;
using NMS.Models.ReportConfigurationViewModels;

namespace NMS.Controllers
{
    public class ReportconfigurationsController : Controller
    {
        private readonly nmsdbContext _context;

        public ReportconfigurationsController(nmsdbContext context)
        {
            _context = context;
        }

        // GET: Reportconfigurations
        public async Task<IActionResult> Index()
        {
            return View(await _context.Reportconfiguration.ToListAsync());
        }

        // GET: Reportconfigurations/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var reportconfiguration = await _context.Reportconfiguration
                .SingleOrDefaultAsync(m => m.IdreportConfiguration == id);
            if (reportconfiguration == null)
            {
                return NotFound();
            }

            return View(reportconfiguration);
        }

        // GET: Reportconfigurations/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Reportconfigurations/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdreportConfiguration,Name,Description,FkUserProfile,FkCustomer")] Reportconfiguration reportconfiguration)
        {
            if (ModelState.IsValid)
            {
                _context.Add(reportconfiguration);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(reportconfiguration);
        }

        // GET: Reportconfigurations/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var reportconfiguration = await _context.Reportconfiguration.SingleOrDefaultAsync(m => m.IdreportConfiguration == id);
            if (reportconfiguration == null)
            {
                return NotFound();
            }
            return View(reportconfiguration);
        }

        // POST: Reportconfigurations/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdreportConfiguration,Name,Description,FkUserProfile,FkCustomer")] Reportconfiguration reportconfiguration)
        {
            if (id != reportconfiguration.IdreportConfiguration)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(reportconfiguration);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ReportconfigurationExists(reportconfiguration.IdreportConfiguration))
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
            return View(reportconfiguration);
        }

        // GET: Reportconfigurations/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var reportconfiguration = await _context.Reportconfiguration
                .SingleOrDefaultAsync(m => m.IdreportConfiguration == id);
            if (reportconfiguration == null)
            {
                return NotFound();
            }

            return View(reportconfiguration);
        }

        // POST: Reportconfigurations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var reportconfiguration = await _context.Reportconfiguration.SingleOrDefaultAsync(m => m.IdreportConfiguration == id);
            _context.Reportconfiguration.Remove(reportconfiguration);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ReportconfigurationExists(int id)
        {
            return _context.Reportconfiguration.Any(e => e.IdreportConfiguration == id);
        }
    }
}
