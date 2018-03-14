// <copyright file="ExceptionlcrsController.cs" company="252afh">
//   Copyright © 252afh 2018. All rights reserved.
// </copyright>

namespace NMS.Controllers
{
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.EntityFrameworkCore;
    using NMS.Models;
    using NMS.Models.ExceptionLcrViewModels;

    public class ExceptionlcrsController : Controller
    {
        private readonly nmsdbContext context;

        public ExceptionlcrsController(nmsdbContext context)
        {
            this.context = context;
        }

        // GET: Exceptionlcrs
        public async Task<IActionResult> Index()
        {
            return this.View(await this.context.Exceptionlcr.ToListAsync());
        }

        // GET: Exceptionlcrs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return this.NotFound();
            }

            var exceptionlcr = await this.context.Exceptionlcr
                .SingleOrDefaultAsync(m => m.IdexceptionLcr == id);
            if (exceptionlcr == null)
            {
                return this.NotFound();
            }

            return this.View(exceptionlcr);
        }

        // GET: Exceptionlcrs/Create
        public IActionResult Create()
        {
            return this.View();
        }

        // POST: Exceptionlcrs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdexceptionLcr,Name,Description")] Exceptionlcr exceptionlcr)
        {
            if (this.ModelState.IsValid)
            {
                this.context.Add(exceptionlcr);
                await this.context.SaveChangesAsync();
                return this.RedirectToAction(nameof(this.Index));
            }

            return this.View(exceptionlcr);
        }

        // GET: Exceptionlcrs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return this.NotFound();
            }

            var exceptionlcr = await this.context.Exceptionlcr.SingleOrDefaultAsync(m => m.IdexceptionLcr == id);
            if (exceptionlcr == null)
            {
                return this.NotFound();
            }

            return this.View(exceptionlcr);
        }

        // POST: Exceptionlcrs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdexceptionLcr,Name,Description")] Exceptionlcr exceptionlcr)
        {
            if (id != exceptionlcr.IdexceptionLcr)
            {
                return this.NotFound();
            }

            if (this.ModelState.IsValid)
            {
                try
                {
                    this.context.Update(exceptionlcr);
                    await this.context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!this.ExceptionlcrExists(exceptionlcr.IdexceptionLcr))
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

            return this.View(exceptionlcr);
        }

        // GET: Exceptionlcrs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return this.NotFound();
            }

            var exceptionlcr = await this.context.Exceptionlcr
                .SingleOrDefaultAsync(m => m.IdexceptionLcr == id);
            if (exceptionlcr == null)
            {
                return this.NotFound();
            }

            return this.View(exceptionlcr);
        }

        // POST: Exceptionlcrs/Delete/5
        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var exceptionlcr = await this.context.Exceptionlcr.SingleOrDefaultAsync(m => m.IdexceptionLcr == id);
            this.context.Exceptionlcr.Remove(exceptionlcr);
            await this.context.SaveChangesAsync();
            return this.RedirectToAction(nameof(this.Index));
        }

        private bool ExceptionlcrExists(int id)
        {
            return this.context.Exceptionlcr.Any(e => e.IdexceptionLcr == id);
        }
    }
}
