// <copyright file="ExceptionnumbersController.cs" company="252afh">
//   Copyright © 252afh 2018. All rights reserved.
// </copyright>

namespace NMS.Controllers
{
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.EntityFrameworkCore;
    using NMS.Models;
    using NMS.Models.ExceptionNumberViewModels;

    public class ExceptionnumbersController : Controller
    {
        private readonly NmsdbContext context;

        public ExceptionnumbersController(NmsdbContext context)
        {
            this.context = context;
        }

        // GET: Exceptionnumbers
        public async Task<IActionResult> Index()
        {
            return this.View(await this.context.Exceptionnumber.ToListAsync());
        }

        // GET: Exceptionnumbers/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return this.NotFound();
            }

            var exceptionnumber = await this.context.Exceptionnumber
                .SingleOrDefaultAsync(m => m.IdexceptionNumber == id);
            if (exceptionnumber == null)
            {
                return this.NotFound();
            }

            return this.View(exceptionnumber);
        }

        // GET: Exceptionnumbers/Create
        public IActionResult Create()
        {
            return this.View();
        }

        // POST: Exceptionnumbers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdexceptionNumber,Number,Description")] Exceptionnumber exceptionnumber)
        {
            if (this.ModelState.IsValid)
            {
                this.context.Add(exceptionnumber);
                await this.context.SaveChangesAsync();
                return this.RedirectToAction(nameof(this.Index));
            }

            return this.View(exceptionnumber);
        }

        // GET: Exceptionnumbers/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return this.NotFound();
            }

            var exceptionnumber = await this.context.Exceptionnumber.SingleOrDefaultAsync(m => m.IdexceptionNumber == id);
            if (exceptionnumber == null)
            {
                return this.NotFound();
            }

            return this.View(exceptionnumber);
        }

        // POST: Exceptionnumbers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdexceptionNumber,Number,Description")] Exceptionnumber exceptionnumber)
        {
            if (id != exceptionnumber.IdexceptionNumber)
            {
                return this.NotFound();
            }

            if (this.ModelState.IsValid)
            {
                try
                {
                    this.context.Update(exceptionnumber);
                    await this.context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!this.ExceptionnumberExists(exceptionnumber.IdexceptionNumber))
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

            return this.View(exceptionnumber);
        }

        // GET: Exceptionnumbers/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return this.NotFound();
            }

            var exceptionnumber = await this.context.Exceptionnumber
                .SingleOrDefaultAsync(m => m.IdexceptionNumber == id);
            if (exceptionnumber == null)
            {
                return this.NotFound();
            }

            return this.View(exceptionnumber);
        }

        // POST: Exceptionnumbers/Delete/5
        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var exceptionnumber = await this.context.Exceptionnumber.SingleOrDefaultAsync(m => m.IdexceptionNumber == id);
            this.context.Exceptionnumber.Remove(exceptionnumber);
            await this.context.SaveChangesAsync();
            return this.RedirectToAction(nameof(this.Index));
        }

        private bool ExceptionnumberExists(int id)
        {
            return this.context.Exceptionnumber.Any(e => e.IdexceptionNumber == id);
        }
    }
}
