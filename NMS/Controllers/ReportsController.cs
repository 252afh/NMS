// <copyright file="ReportsController.cs" company="252afh">
//   Copyright © 252afh 2018. All rights reserved.
// </copyright>

namespace NMS.Controllers
{
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.EntityFrameworkCore;
    using NMS.Models;
    using NMS.Models.ReportViewModels;

    public class ReportsController : Controller
    {
        private readonly nmsdbContext context;

        public ReportsController(nmsdbContext context)
        {
            this.context = context;
        }

        // GET: Reports
        public async Task<IActionResult> Index()
        {
            return this.View(await this.context.Report.ToListAsync());
        }

        // GET: Reports/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return this.NotFound();
            }

            var report = await this.context.Report
                .SingleOrDefaultAsync(m => m.Idreport == id);
            if (report == null)
            {
                return this.NotFound();
            }

            return this.View(report);
        }

        // GET: Reports/Create
        public IActionResult Create()
        {
            return this.View();
        }

        // POST: Reports/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Idreport,Name")] Report report)
        {
            if (this.ModelState.IsValid)
            {
                this.context.Add(report);
                await this.context.SaveChangesAsync();
                return this.RedirectToAction(nameof(this.Index));
            }

            return this.View(report);
        }

        // GET: Reports/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return this.NotFound();
            }

            var report = await this.context.Report.SingleOrDefaultAsync(m => m.Idreport == id);
            if (report == null)
            {
                return this.NotFound();
            }

            return this.View(report);
        }

        // POST: Reports/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Idreport,Name")] Report report)
        {
            if (id != report.Idreport)
            {
                return this.NotFound();
            }

            if (this.ModelState.IsValid)
            {
                try
                {
                    this.context.Update(report);
                    await this.context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!this.ReportExists(report.Idreport))
                    {
                        return this.NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }

                return this.RedirectToAction(nameof(this.Index));
            }

            return this.View(report);
        }

        // GET: Reports/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return this.NotFound();
            }

            var report = await this.context.Report
                .SingleOrDefaultAsync(m => m.Idreport == id);
            if (report == null)
            {
                return this.NotFound();
            }

            return this.View(report);
        }

        // POST: Reports/Delete/5
        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var report = await this.context.Report.SingleOrDefaultAsync(m => m.Idreport == id);
            this.context.Report.Remove(report);
            await this.context.SaveChangesAsync();
            return this.RedirectToAction(nameof(this.Index));
        }

        private bool ReportExists(int id)
        {
            return this.context.Report.Any(e => e.Idreport == id);
        }
    }
}
