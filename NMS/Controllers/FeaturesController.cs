// <copyright file="FeaturesController.cs" company="252afh">
//   Copyright © 252afh 2018. All rights reserved.
// </copyright>

namespace NMS.Controllers
{
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.EntityFrameworkCore;
    using NMS.Models;
    using NMS.Models.FeatureViewModels;

    public class FeaturesController : Controller
    {
        private readonly NmsdbContext context;

        public FeaturesController(NmsdbContext context)
        {
            this.context = context;
        }

        // GET: Features
        public async Task<IActionResult> Index()
        {
            return this.View(await this.context.Feature.ToListAsync());
        }

        // GET: Features/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return this.NotFound();
            }

            var feature = await this.context.Feature
                .SingleOrDefaultAsync(m => m.Idfeature == id);
            if (feature == null)
            {
                return this.NotFound();
            }

            return this.View(feature);
        }

        // GET: Features/Create
        public IActionResult Create()
        {
            return this.View();
        }

        // POST: Features/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Idfeature,Name,Description,Code")] Feature feature)
        {
            if (this.ModelState.IsValid)
            {
                this.context.Add(feature);
                await this.context.SaveChangesAsync();
                return this.RedirectToAction(nameof(this.Index));
            }

            return this.View(feature);
        }

        // GET: Features/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return this.NotFound();
            }

            var feature = await this.context.Feature.SingleOrDefaultAsync(m => m.Idfeature == id);
            if (feature == null)
            {
                return this.NotFound();
            }

            return this.View(feature);
        }

        // POST: Features/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Idfeature,Name,Description,Code")] Feature feature)
        {
            if (id != feature.Idfeature)
            {
                return this.NotFound();
            }

            if (this.ModelState.IsValid)
            {
                try
                {
                    this.context.Update(feature);
                    await this.context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!this.FeatureExists(feature.Idfeature))
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

            return this.View(feature);
        }

        // GET: Features/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return this.NotFound();
            }

            var feature = await this.context.Feature
                .SingleOrDefaultAsync(m => m.Idfeature == id);
            if (feature == null)
            {
                return this.NotFound();
            }

            return this.View(feature);
        }

        // POST: Features/Delete/5
        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var feature = await this.context.Feature.SingleOrDefaultAsync(m => m.Idfeature == id);
            this.context.Feature.Remove(feature);
            await this.context.SaveChangesAsync();
            return this.RedirectToAction(nameof(this.Index));
        }

        private bool FeatureExists(int id)
        {
            return this.context.Feature.Any(e => e.Idfeature == id);
        }
    }
}
