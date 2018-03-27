// <copyright file="DaydetailsController.cs" company="252afh">
//   Copyright © 252afh 2018. All rights reserved.
// </copyright>

namespace NMS.Controllers
{
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.EntityFrameworkCore;
    using NMS.Models;
    using NMS.Models.DayDetailsViewModels;

    public class DaydetailsController : Controller
    {
        private readonly NmsdbContext context;

        public DaydetailsController(NmsdbContext context)
        {
            this.context = context;
        }

        // GET: Daydetails
        public async Task<IActionResult> Index()
        {
            return this.View(await this.context.Daydetails.ToListAsync());
        }

        // GET: Daydetails/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return this.NotFound();
            }

            var daydetails = await this.context.Daydetails
                .SingleOrDefaultAsync(m => m.IddayDetails == id);
            if (daydetails == null)
            {
                return this.NotFound();
            }

            return this.View(daydetails);
        }

        // GET: Daydetails/Create
        public IActionResult Create()
        {
            return this.View();
        }

        // POST: Daydetails/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IddayDetails,Day,TimeFrom,TimeTo,Status,FkPeriod")] Daydetails daydetails)
        {
            if (this.ModelState.IsValid)
            {
                this.context.Add(daydetails);
                await this.context.SaveChangesAsync();
                return this.RedirectToAction(nameof(this.Index));
            }

            return this.View(daydetails);
        }

        // GET: Daydetails/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return this.NotFound();
            }

            var daydetails = await this.context.Daydetails.SingleOrDefaultAsync(m => m.IddayDetails == id);
            if (daydetails == null)
            {
                return this.NotFound();
            }

            return this.View(daydetails);
        }

        // POST: Daydetails/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IddayDetails,Day,TimeFrom,TimeTo,Status,FkPeriod")] Daydetails daydetails)
        {
            if (id != daydetails.IddayDetails)
            {
                return this.NotFound();
            }

            if (this.ModelState.IsValid)
            {
                try
                {
                    this.context.Update(daydetails);
                    await this.context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!this.DaydetailsExists(daydetails.IddayDetails))
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

            return this.View(daydetails);
        }

        // GET: Daydetails/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return this.NotFound();
            }

            var daydetails = await this.context.Daydetails
                .SingleOrDefaultAsync(m => m.IddayDetails == id);
            if (daydetails == null)
            {
                return this.NotFound();
            }

            return this.View(daydetails);
        }

        // POST: Daydetails/Delete/5
        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var daydetails = await this.context.Daydetails.SingleOrDefaultAsync(m => m.IddayDetails == id);
            this.context.Daydetails.Remove(daydetails);
            await this.context.SaveChangesAsync();
            return this.RedirectToAction(nameof(this.Index));
        }

        private bool DaydetailsExists(int id)
        {
            return this.context.Daydetails.Any(e => e.IddayDetails == id);
        }
    }
}
