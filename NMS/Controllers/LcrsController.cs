// <copyright file="LcrsController.cs" company="252afh">
//   Copyright © 252afh 2018. All rights reserved.
// </copyright>

namespace NMS.Controllers
{
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.EntityFrameworkCore;
    using NMS.Models;
    using NMS.Models.LcrViewModels;

    public class LcrsController : Controller
    {
        private readonly NmsdbContext context;

        public LcrsController(NmsdbContext context)
        {
            this.context = context;
        }

        // GET: Lcrs
        public async Task<IActionResult> Index()
        {
            return this.View(await this.context.Lcr.ToListAsync());
        }

        // GET: Lcrs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return this.NotFound();
            }

            var lcr = await this.context.Lcr
                .SingleOrDefaultAsync(m => m.Idlcr == id);
            if (lcr == null)
            {
                return this.NotFound();
            }

            return this.View(lcr);
        }

        // GET: Lcrs/Create
        public IActionResult Create()
        {
            return this.View();
        }

        // POST: Lcrs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Idlcr,Name,Description")] Lcr lcr)
        {
            if (this.ModelState.IsValid)
            {
                this.context.Add(lcr);
                await this.context.SaveChangesAsync();
                return this.RedirectToAction(nameof(this.Index));
            }

            return this.View(lcr);
        }

        // GET: Lcrs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return this.NotFound();
            }

            var lcr = await this.context.Lcr.SingleOrDefaultAsync(m => m.Idlcr == id);
            if (lcr == null)
            {
                return this.NotFound();
            }

            return this.View(lcr);
        }

        // POST: Lcrs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Idlcr,Name,Description")] Lcr lcr)
        {
            if (id != lcr.Idlcr)
            {
                return this.NotFound();
            }

            if (this.ModelState.IsValid)
            {
                try
                {
                    this.context.Update(lcr);
                    await this.context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!this.LcrExists(lcr.Idlcr))
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

            return this.View(lcr);
        }

        // GET: Lcrs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return this.NotFound();
            }

            var lcr = await this.context.Lcr
                .SingleOrDefaultAsync(m => m.Idlcr == id);
            if (lcr == null)
            {
                return this.NotFound();
            }

            return this.View(lcr);
        }

        // POST: Lcrs/Delete/5
        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var lcr = await this.context.Lcr.SingleOrDefaultAsync(m => m.Idlcr == id);
            this.context.Lcr.Remove(lcr);
            await this.context.SaveChangesAsync();
            return this.RedirectToAction(nameof(this.Index));
        }

        private bool LcrExists(int id)
        {
            return this.context.Lcr.Any(e => e.Idlcr == id);
        }
    }
}
