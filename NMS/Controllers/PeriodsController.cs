// <copyright file="PeriodsController.cs" company="252afh">
//   Copyright © 252afh 2018. All rights reserved.
// </copyright>

namespace NMS.Controllers
{
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.EntityFrameworkCore;
    using NMS.Models;
    using NMS.Models.PeriodViewModels;

    public class PeriodsController : Controller
    {
        private readonly NmsdbContext context;

        public PeriodsController(NmsdbContext context)
        {
            this.context = context;
        }

        // GET: Periods
        public async Task<IActionResult> Index()
        {
            return this.View(await this.context.Period.ToListAsync());
        }

        // GET: Periods/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return this.NotFound();
            }

            var period = await this.context.Period
                .SingleOrDefaultAsync(m => m.Idperiod == id);
            if (period == null)
            {
                return this.NotFound();
            }

            return this.View(period);
        }

        // GET: Periods/Create
        public IActionResult Create()
        {
            return this.View();
        }

        // POST: Periods/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Idperiod,TimeFrom,TimeTo,Frequency,Day,Status,FkTemplate")] Period period)
        {
            if (this.ModelState.IsValid)
            {
                this.context.Add(period);
                await this.context.SaveChangesAsync();
                return this.RedirectToAction(nameof(this.Index));
            }

            return this.View(period);
        }

        // GET: Periods/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return this.NotFound();
            }

            var period = await this.context.Period.SingleOrDefaultAsync(m => m.Idperiod == id);
            if (period == null)
            {
                return this.NotFound();
            }

            return this.View(period);
        }

        // POST: Periods/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Idperiod,TimeFrom,TimeTo,Frequency,Day,Status,FkTemplate")] Period period)
        {
            if (id != period.Idperiod)
            {
                return this.NotFound();
            }

            if (this.ModelState.IsValid)
            {
                try
                {
                    this.context.Update(period);
                    await this.context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!this.PeriodExists(period.Idperiod))
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

            return this.View(period);
        }

        // GET: Periods/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return this.NotFound();
            }

            var period = await this.context.Period
                .SingleOrDefaultAsync(m => m.Idperiod == id);
            if (period == null)
            {
                return this.NotFound();
            }

            return this.View(period);
        }

        // POST: Periods/Delete/5
        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var period = await this.context.Period.SingleOrDefaultAsync(m => m.Idperiod == id);
            this.context.Period.Remove(period);
            await this.context.SaveChangesAsync();
            return this.RedirectToAction(nameof(this.Index));
        }

        private bool PeriodExists(int id)
        {
            return this.context.Period.Any(e => e.Idperiod == id);
        }
    }
}
