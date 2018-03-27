// <copyright file="NumbergroupsController.cs" company="252afh">
//   Copyright © 252afh 2018. All rights reserved.
// </copyright>

namespace NMS.Controllers
{
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.EntityFrameworkCore;
    using NMS.Models;
    using NMS.Models.NumberGroupViewModels;

    public class NumbergroupsController : Controller
    {
        private readonly NmsdbContext context;

        public NumbergroupsController(NmsdbContext context)
        {
            this.context = context;
        }

        // GET: Numbergroups
        public async Task<IActionResult> Index()
        {
            return this.View(await this.context.Numbergroup.ToListAsync());
        }

        // GET: Numbergroups/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return this.NotFound();
            }

            var numbergroup = await this.context.Numbergroup
                .SingleOrDefaultAsync(m => m.Idgroup == id);
            if (numbergroup == null)
            {
                return this.NotFound();
            }

            return this.View(numbergroup);
        }

        // GET: Numbergroups/Create
        public IActionResult Create()
        {
            return this.View();
        }

        // POST: Numbergroups/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Idgroup,Name,Description,FkCustomer")] Numbergroup numbergroup)
        {
            if (this.ModelState.IsValid)
            {
                this.context.Add(numbergroup);
                await this.context.SaveChangesAsync();
                return this.RedirectToAction(nameof(this.Index));
            }

            return this.View(numbergroup);
        }

        // GET: Numbergroups/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return this.NotFound();
            }

            var numbergroup = await this.context.Numbergroup.SingleOrDefaultAsync(m => m.Idgroup == id);
            if (numbergroup == null)
            {
                return this.NotFound();
            }

            return this.View(numbergroup);
        }

        // POST: Numbergroups/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Idgroup,Name,Description,FkCustomer")] Numbergroup numbergroup)
        {
            if (id != numbergroup.Idgroup)
            {
                return this.NotFound();
            }

            if (this.ModelState.IsValid)
            {
                try
                {
                    this.context.Update(numbergroup);
                    await this.context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!this.NumbergroupExists(numbergroup.Idgroup))
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

            return this.View(numbergroup);
        }

        // GET: Numbergroups/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return this.NotFound();
            }

            var numbergroup = await this.context.Numbergroup
                .SingleOrDefaultAsync(m => m.Idgroup == id);
            if (numbergroup == null)
            {
                return this.NotFound();
            }

            return this.View(numbergroup);
        }

        // POST: Numbergroups/Delete/5
        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var numbergroup = await this.context.Numbergroup.SingleOrDefaultAsync(m => m.Idgroup == id);
            this.context.Numbergroup.Remove(numbergroup);
            await this.context.SaveChangesAsync();
            return this.RedirectToAction(nameof(this.Index));
        }

        private bool NumbergroupExists(int id)
        {
            return this.context.Numbergroup.Any(e => e.Idgroup == id);
        }
    }
}
