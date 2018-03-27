// <copyright file="BlockingsController.cs" company="252afh">
//   Copyright © 252afh 2018. All rights reserved.
// </copyright>

namespace NMS.Controllers
{
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.EntityFrameworkCore;
    using Models;
    using Models.BlockingViewModels;

    public class BlockingsController : Controller
    {
        private readonly NmsdbContext context;

        public BlockingsController(NmsdbContext context)
        {
            this.context = context;
        }

        // GET: Blockings
        public async Task<IActionResult> Index()
        {
            return this.View(await this.context.Blocking.ToListAsync());
        }

        // GET: Blockings/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return this.NotFound();
            }

            var blocking = await this.context.Blocking
                .SingleOrDefaultAsync(m => m.Idblocking == id);
            if (blocking == null)
            {
                return this.NotFound();
            }

            return this.View(blocking);
        }

        // GET: Blockings/Create
        public IActionResult Create()
        {
            return this.View();
        }

        // POST: Blockings/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Idblocking,Code,NormalisedCode,Description,FkCustomer")] Blocking blocking)
        {
            if (this.ModelState.IsValid)
            {
                this.context.Add(blocking);
                await this.context.SaveChangesAsync();
                return this.RedirectToAction(nameof(this.Index));
            }

            return this.View(blocking);
        }

        // GET: Blockings/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return this.NotFound();
            }

            var blocking = await this.context.Blocking.SingleOrDefaultAsync(m => m.Idblocking == id);
            if (blocking == null)
            {
                return this.NotFound();
            }

            return this.View(blocking);
        }

        // POST: Blockings/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Idblocking,Code,NormalisedCode,Description,FkCustomer")] Blocking blocking)
        {
            if (id != blocking.Idblocking)
            {
                return this.NotFound();
            }

            if (this.ModelState.IsValid)
            {
                try
                {
                    this.context.Update(blocking);
                    await this.context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!this.BlockingExists(blocking.Idblocking))
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

            return this.View(blocking);
        }

        // GET: Blockings/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return this.NotFound();
            }

            var blocking = await this.context.Blocking
                .SingleOrDefaultAsync(m => m.Idblocking == id);
            if (blocking == null)
            {
                return this.NotFound();
            }

            return this.View(blocking);
        }

        // POST: Blockings/Delete/5
        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var blocking = await this.context.Blocking.SingleOrDefaultAsync(m => m.Idblocking == id);
            this.context.Blocking.Remove(blocking);
            await this.context.SaveChangesAsync();
            return this.RedirectToAction(nameof(this.Index));
        }

        private bool BlockingExists(int id)
        {
            return this.context.Blocking.Any(e => e.Idblocking == id);
        }
    }
}
