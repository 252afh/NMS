// <copyright file="ReportconfigurationsController.cs" company="252afh">
//   Copyright © 252afh 2018. All rights reserved.
// </copyright>

namespace NMS.Controllers
{
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.EntityFrameworkCore;
    using NMS.Models;
    using NMS.Models.ReportConfigurationViewModels;

    public class ReportconfigurationsController : Controller
    {
        private readonly nmsdbContext context;

        public ReportconfigurationsController(nmsdbContext context)
        {
            this.context = context;
        }

        // GET: Reportconfigurations
        public async Task<IActionResult> Index()
        {
            return this.View(await this.context.Reportconfiguration.ToListAsync());
        }

        // GET: Reportconfigurations/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return this.NotFound();
            }

            var reportconfiguration = await this.context.Reportconfiguration
                .SingleOrDefaultAsync(m => m.IdreportConfiguration == id);
            if (reportconfiguration == null)
            {
                return this.NotFound();
            }

            return this.View(reportconfiguration);
        }

        // GET: Reportconfigurations/Create
        public IActionResult Create()
        {
            return this.View();
        }

        // POST: Reportconfigurations/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdreportConfiguration,Name,Description,FkUserProfile,FkCustomer")] Reportconfiguration reportconfiguration)
        {
            if (this.ModelState.IsValid)
            {
                this.context.Add(reportconfiguration);
                await this.context.SaveChangesAsync();
                return this.RedirectToAction(nameof(this.Index));
            }

            return this.View(reportconfiguration);
        }

        // GET: Reportconfigurations/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return this.NotFound();
            }

            var reportconfiguration = await this.context.Reportconfiguration.SingleOrDefaultAsync(m => m.IdreportConfiguration == id);
            if (reportconfiguration == null)
            {
                return this.NotFound();
            }

            return this.View(reportconfiguration);
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
                return this.NotFound();
            }

            if (this.ModelState.IsValid)
            {
                try
                {
                    this.context.Update(reportconfiguration);
                    await this.context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!this.ReportconfigurationExists(reportconfiguration.IdreportConfiguration))
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

            return this.View(reportconfiguration);
        }

        // GET: Reportconfigurations/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return this.NotFound();
            }

            var reportconfiguration = await this.context.Reportconfiguration
                .SingleOrDefaultAsync(m => m.IdreportConfiguration == id);
            if (reportconfiguration == null)
            {
                return this.NotFound();
            }

            return this.View(reportconfiguration);
        }

        // POST: Reportconfigurations/Delete/5
        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var reportconfiguration = await this.context.Reportconfiguration.SingleOrDefaultAsync(m => m.IdreportConfiguration == id);
            this.context.Reportconfiguration.Remove(reportconfiguration);
            await this.context.SaveChangesAsync();
            return this.RedirectToAction(nameof(this.Index));
        }

        private bool ReportconfigurationExists(int id)
        {
            return this.context.Reportconfiguration.Any(e => e.IdreportConfiguration == id);
        }
    }
}
