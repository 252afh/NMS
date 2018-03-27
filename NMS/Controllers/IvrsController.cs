// <copyright file="IvrsController.cs" company="252afh">
//   Copyright © 252afh 2018. All rights reserved.
// </copyright>

namespace NMS.Controllers
{
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.EntityFrameworkCore;
    using NMS.Models;
    using NMS.Models.IvrViewModels;

    public class IvrsController : Controller
    {
        private readonly NmsdbContext context;

        public IvrsController(NmsdbContext context)
        {
            this.context = context;
        }

        // GET: Ivrs
        public async Task<IActionResult> Index()
        {
            return this.View(await this.context.Ivr.ToListAsync());
        }

        // GET: Ivrs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return this.NotFound();
            }

            var ivr = await this.context.Ivr
                .SingleOrDefaultAsync(m => m.Idivr == id);
            if (ivr == null)
            {
                return this.NotFound();
            }

            return this.View(ivr);
        }

        // GET: Ivrs/Create
        public IActionResult Create()
        {
            return this.View();
        }

        // POST: Ivrs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Idivr,Name,Description,Audiomessage,Audioname,Audiosize,Repeattimes,Timeout,FkCustomer")] Ivr ivr)
        {
            if (this.ModelState.IsValid)
            {
                this.context.Add(ivr);
                await this.context.SaveChangesAsync();
                return this.RedirectToAction(nameof(this.Index));
            }

            return this.View(ivr);
        }

        // GET: Ivrs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return this.NotFound();
            }

            var ivr = await this.context.Ivr.SingleOrDefaultAsync(m => m.Idivr == id);
            if (ivr == null)
            {
                return this.NotFound();
            }

            return this.View(ivr);
        }

        // POST: Ivrs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Idivr,Name,Description,Audiomessage,Audioname,Audiosize,Repeattimes,Timeout,FkCustomer")] Ivr ivr)
        {
            if (id != ivr.Idivr)
            {
                return this.NotFound();
            }

            if (this.ModelState.IsValid)
            {
                try
                {
                    this.context.Update(ivr);
                    await this.context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!this.IvrExists(ivr.Idivr))
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

            return this.View(ivr);
        }

        // GET: Ivrs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return this.NotFound();
            }

            var ivr = await this.context.Ivr
                .SingleOrDefaultAsync(m => m.Idivr == id);
            if (ivr == null)
            {
                return this.NotFound();
            }

            return this.View(ivr);
        }

        // POST: Ivrs/Delete/5
        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var ivr = await this.context.Ivr.SingleOrDefaultAsync(m => m.Idivr == id);
            this.context.Ivr.Remove(ivr);
            await this.context.SaveChangesAsync();
            return this.RedirectToAction(nameof(this.Index));
        }

        private bool IvrExists(int id)
        {
            return this.context.Ivr.Any(e => e.Idivr == id);
        }
    }
}
