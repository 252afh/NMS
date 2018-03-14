// <copyright file="NumberformatsController.cs" company="252afh">
//   Copyright © 252afh 2018. All rights reserved.
// </copyright>

namespace NMS.Controllers
{
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.EntityFrameworkCore;
    using NMS.Models;
    using NMS.Models.NumberFormatViewModels;

    public class NumberformatsController : Controller
    {
        private readonly nmsdbContext context;

        public NumberformatsController(nmsdbContext context)
        {
            this.context = context;
        }

        // GET: Numberformats
        public async Task<IActionResult> Index()
        {
            return this.View(await this.context.Numberformat.ToListAsync());
        }

        // GET: Numberformats/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return this.NotFound();
            }

            var numberformat = await this.context.Numberformat
                .SingleOrDefaultAsync(m => m.IdnumberFormat == id);
            if (numberformat == null)
            {
                return this.NotFound();
            }

            return this.View(numberformat);
        }

        // GET: Numberformats/Create
        public IActionResult Create()
        {
            return this.View();
        }

        // POST: Numberformats/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdnumberFormat,NumberFormat,Description,Name")] Numberformat numberformat)
        {
            if (this.ModelState.IsValid)
            {
                this.context.Add(numberformat);
                await this.context.SaveChangesAsync();
                return this.RedirectToAction(nameof(this.Index));
            }

            return this.View(numberformat);
        }

        // GET: Numberformats/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return this.NotFound();
            }

            var numberformat = await this.context.Numberformat.SingleOrDefaultAsync(m => m.IdnumberFormat == id);
            if (numberformat == null)
            {
                return this.NotFound();
            }

            return this.View(numberformat);
        }

        // POST: Numberformats/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdnumberFormat,NumberFormat,Description,Name")] Numberformat numberformat)
        {
            if (id != numberformat.IdnumberFormat)
            {
                return this.NotFound();
            }

            if (this.ModelState.IsValid)
            {
                try
                {
                    this.context.Update(numberformat);
                    await this.context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!this.NumberformatExists(numberformat.IdnumberFormat))
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

            return this.View(numberformat);
        }

        // GET: Numberformats/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return this.NotFound();
            }

            var numberformat = await this.context.Numberformat
                .SingleOrDefaultAsync(m => m.IdnumberFormat == id);
            if (numberformat == null)
            {
                return this.NotFound();
            }

            return this.View(numberformat);
        }

        // POST: Numberformats/Delete/5
        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var numberformat = await this.context.Numberformat.SingleOrDefaultAsync(m => m.IdnumberFormat == id);
            this.context.Numberformat.Remove(numberformat);
            await this.context.SaveChangesAsync();
            return this.RedirectToAction(nameof(this.Index));
        }

        private bool NumberformatExists(int id)
        {
            return this.context.Numberformat.Any(e => e.IdnumberFormat == id);
        }
    }
}
