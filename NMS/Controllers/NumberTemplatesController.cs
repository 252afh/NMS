// <copyright file="NumberTemplatesController.cs" company="252afh">
//   Copyright © 252afh 2018. All rights reserved.
// </copyright>

namespace NMS.Controllers
{
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.EntityFrameworkCore;
    using NMS.Models;
    using NMS.Models.NumberTemplateViewModels;

    public class NumberTemplatesController : Controller
    {
        private readonly nmsdbContext context;

        public NumberTemplatesController(nmsdbContext context)
        {
            this.context = context;
        }

        // GET: NumberTemplates
        public async Task<IActionResult> Index()
        {
            return this.View(await this.context.NumberTemplate.ToListAsync());
        }

        // GET: NumberTemplates/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return this.NotFound();
            }

            var numberTemplate = await this.context.NumberTemplate
                .SingleOrDefaultAsync(m => m.IdnumberTemplate == id);
            if (numberTemplate == null)
            {
                return this.NotFound();
            }

            return this.View(numberTemplate);
        }

        // GET: NumberTemplates/Create
        public IActionResult Create()
        {
            return this.View();
        }

        // POST: NumberTemplates/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdnumberTemplate,FkNumber,FkTemplate,Priority,Active,FkRoutingGroup")] NumberTemplate numberTemplate)
        {
            if (this.ModelState.IsValid)
            {
                this.context.Add(numberTemplate);
                await this.context.SaveChangesAsync();
                return this.RedirectToAction(nameof(this.Index));
            }

            return this.View(numberTemplate);
        }

        // GET: NumberTemplates/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return this.NotFound();
            }

            var numberTemplate = await this.context.NumberTemplate.SingleOrDefaultAsync(m => m.IdnumberTemplate == id);
            if (numberTemplate == null)
            {
                return this.NotFound();
            }

            return this.View(numberTemplate);
        }

        // POST: NumberTemplates/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdnumberTemplate,FkNumber,FkTemplate,Priority,Active,FkRoutingGroup")] NumberTemplate numberTemplate)
        {
            if (id != numberTemplate.IdnumberTemplate)
            {
                return this.NotFound();
            }

            if (this.ModelState.IsValid)
            {
                try
                {
                    this.context.Update(numberTemplate);
                    await this.context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!this.NumberTemplateExists(numberTemplate.IdnumberTemplate))
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

            return this.View(numberTemplate);
        }

        // GET: NumberTemplates/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return this.NotFound();
            }

            var numberTemplate = await this.context.NumberTemplate
                .SingleOrDefaultAsync(m => m.IdnumberTemplate == id);
            if (numberTemplate == null)
            {
                return this.NotFound();
            }

            return this.View(numberTemplate);
        }

        // POST: NumberTemplates/Delete/5
        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var numberTemplate = await this.context.NumberTemplate.SingleOrDefaultAsync(m => m.IdnumberTemplate == id);
            this.context.NumberTemplate.Remove(numberTemplate);
            await this.context.SaveChangesAsync();
            return this.RedirectToAction(nameof(this.Index));
        }

        private bool NumberTemplateExists(int id)
        {
            return this.context.NumberTemplate.Any(e => e.IdnumberTemplate == id);
        }
    }
}
