// <copyright file="SitesController.cs" company="252afh">
//   Copyright © 252afh 2018. All rights reserved.
// </copyright>

namespace NMS.Controllers
{
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.EntityFrameworkCore;
    using NMS.Models;
    using NMS.Models.SiteViewModels;

    public class SitesController : Controller
    {
        private readonly NmsdbContext context;

        public SitesController(NmsdbContext context)
        {
            this.context = context;
        }

        // GET: Sites
        public async Task<IActionResult> Index()
        {
            return this.View(await this.context.Site.ToListAsync());
        }

        // GET: Sites/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return this.NotFound();
            }

            var site = await this.context.Site
                .SingleOrDefaultAsync(m => m.Idsite == id);
            if (site == null)
            {
                return this.NotFound();
            }

            return this.View(site);
        }

        // GET: Sites/Create
        public IActionResult Create()
        {
            return this.View();
        }

        // POST: Sites/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Idsite,Name,Description,Domain,FkNumberFormat,FkCustomer")] Site site)
        {
            if (this.ModelState.IsValid)
            {
                this.context.Add(site);
                await this.context.SaveChangesAsync();
                return this.RedirectToAction(nameof(this.Index));
            }

            return this.View(site);
        }

        // GET: Sites/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return this.NotFound();
            }

            var site = await this.context.Site.SingleOrDefaultAsync(m => m.Idsite == id);
            if (site == null)
            {
                return this.NotFound();
            }

            return this.View(site);
        }

        // POST: Sites/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Idsite,Name,Description,Domain,FkNumberFormat,FkCustomer")] Site site)
        {
            if (id != site.Idsite)
            {
                return this.NotFound();
            }

            if (this.ModelState.IsValid)
            {
                try
                {
                    this.context.Update(site);
                    await this.context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!this.SiteExists(site.Idsite))
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

            return this.View(site);
        }

        // GET: Sites/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return this.NotFound();
            }

            var site = await this.context.Site
                .SingleOrDefaultAsync(m => m.Idsite == id);
            if (site == null)
            {
                return this.NotFound();
            }

            return this.View(site);
        }

        // POST: Sites/Delete/5
        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var site = await this.context.Site.SingleOrDefaultAsync(m => m.Idsite == id);
            this.context.Site.Remove(site);
            await this.context.SaveChangesAsync();
            return this.RedirectToAction(nameof(this.Index));
        }

        private bool SiteExists(int id)
        {
            return this.context.Site.Any(e => e.Idsite == id);
        }
    }
}
