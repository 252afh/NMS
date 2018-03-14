using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using NMS.Models;
using NMS.Models.ReportConfigurationNumberViewModels;

namespace NMS.Controllers
{
    public class ReportconfigurationNumbersController : Controller
    {
        private readonly nmsdbContext _context;

        public ReportconfigurationNumbersController(nmsdbContext context)
        {
            _context = context;
        }

        // GET: ReportconfigurationNumbers
        public async Task<IActionResult> Index()
        {
            return View(await _context.ReportconfigurationNumber.ToListAsync());
        }

        // GET: ReportconfigurationNumbers/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var reportconfigurationNumber = await _context.ReportconfigurationNumber
                .SingleOrDefaultAsync(m => m.IdreportconfigurationNumber == id);
            if (reportconfigurationNumber == null)
            {
                return NotFound();
            }

            return View(reportconfigurationNumber);
        }

        // GET: ReportconfigurationNumbers/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ReportconfigurationNumbers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdreportconfigurationNumber,FkReportConfiguration,FkNumber")] ReportconfigurationNumber reportconfigurationNumber)
        {
            if (ModelState.IsValid)
            {
                _context.Add(reportconfigurationNumber);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(reportconfigurationNumber);
        }

        // GET: ReportconfigurationNumbers/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var reportconfigurationNumber = await _context.ReportconfigurationNumber.SingleOrDefaultAsync(m => m.IdreportconfigurationNumber == id);
            if (reportconfigurationNumber == null)
            {
                return NotFound();
            }
            return View(reportconfigurationNumber);
        }

        // POST: ReportconfigurationNumbers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdreportconfigurationNumber,FkReportConfiguration,FkNumber")] ReportconfigurationNumber reportconfigurationNumber)
        {
            if (id != reportconfigurationNumber.IdreportconfigurationNumber)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(reportconfigurationNumber);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ReportconfigurationNumberExists(reportconfigurationNumber.IdreportconfigurationNumber))
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
            return View(reportconfigurationNumber);
        }

        // GET: ReportconfigurationNumbers/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var reportconfigurationNumber = await _context.ReportconfigurationNumber
                .SingleOrDefaultAsync(m => m.IdreportconfigurationNumber == id);
            if (reportconfigurationNumber == null)
            {
                return NotFound();
            }

            return View(reportconfigurationNumber);
        }

        // POST: ReportconfigurationNumbers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var reportconfigurationNumber = await _context.ReportconfigurationNumber.SingleOrDefaultAsync(m => m.IdreportconfigurationNumber == id);
            _context.ReportconfigurationNumber.Remove(reportconfigurationNumber);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ReportconfigurationNumberExists(int id)
        {
            return _context.ReportconfigurationNumber.Any(e => e.IdreportconfigurationNumber == id);
        }
    }
}
