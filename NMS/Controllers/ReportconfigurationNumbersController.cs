// <copyright file="ReportconfigurationNumbersController.cs" company="252afh">
//   Copyright © 252afh 2018. All rights reserved.
// </copyright>

namespace NMS.Controllers
{
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.EntityFrameworkCore;
    using NMS.Models;
    using NMS.Models.ReportConfigurationNumberViewModels;

    public class ReportconfigurationNumbersController : Controller
    {
        private readonly NmsdbContext context;

        public ReportconfigurationNumbersController(NmsdbContext context)
        {
            this.context = context;
        }

        // GET: ReportconfigurationNumbers
        public async Task<IActionResult> Index()
        {
            return this.View(await this.context.ReportconfigurationNumber.ToListAsync());
        }

        // GET: ReportconfigurationNumbers/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return this.NotFound();
            }

            var reportconfigurationNumber = await this.context.ReportconfigurationNumber
                .SingleOrDefaultAsync(m => m.IdreportconfigurationNumber == id);
            if (reportconfigurationNumber == null)
            {
                return this.NotFound();
            }

            return this.View(reportconfigurationNumber);
        }

        // GET: ReportconfigurationNumbers/Create
        public IActionResult Create()
        {
            return this.View();
        }

        // POST: ReportconfigurationNumbers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdreportconfigurationNumber,FkReportConfiguration,FkNumber")] ReportconfigurationNumber reportconfigurationNumber)
        {
            if (this.ModelState.IsValid)
            {
                this.context.Add(reportconfigurationNumber);
                await this.context.SaveChangesAsync();
                return this.RedirectToAction(nameof(this.Index));
            }

            return this.View(reportconfigurationNumber);
        }

        // GET: ReportconfigurationNumbers/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return this.NotFound();
            }

            var reportconfigurationNumber = await this.context.ReportconfigurationNumber.SingleOrDefaultAsync(m => m.IdreportconfigurationNumber == id);
            if (reportconfigurationNumber == null)
            {
                return this.NotFound();
            }

            return this.View(reportconfigurationNumber);
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
                return this.NotFound();
            }

            if (this.ModelState.IsValid)
            {
                try
                {
                    this.context.Update(reportconfigurationNumber);
                    await this.context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!this.ReportconfigurationNumberExists(reportconfigurationNumber.IdreportconfigurationNumber))
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

            return this.View(reportconfigurationNumber);
        }

        // GET: ReportconfigurationNumbers/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return this.NotFound();
            }

            var reportconfigurationNumber = await this.context.ReportconfigurationNumber
                .SingleOrDefaultAsync(m => m.IdreportconfigurationNumber == id);
            if (reportconfigurationNumber == null)
            {
                return this.NotFound();
            }

            return this.View(reportconfigurationNumber);
        }

        // POST: ReportconfigurationNumbers/Delete/5
        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var reportconfigurationNumber = await this.context.ReportconfigurationNumber.SingleOrDefaultAsync(m => m.IdreportconfigurationNumber == id);
            this.context.ReportconfigurationNumber.Remove(reportconfigurationNumber);
            await this.context.SaveChangesAsync();
            return this.RedirectToAction(nameof(this.Index));
        }

        private bool ReportconfigurationNumberExists(int id)
        {
            return this.context.ReportconfigurationNumber.Any(e => e.IdreportconfigurationNumber == id);
        }
    }
}
