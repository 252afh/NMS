// <copyright file="TemplatesController.cs" company="252afh">
//   Copyright © 252afh 2018. All rights reserved.
// </copyright>

namespace NMS.Controllers
{
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.EntityFrameworkCore;
    using NMS.Models;
    using NMS.Models.TemplateViewModels;

    public class TemplatesController : Controller
    {
        private readonly NmsdbContext context;

        public TemplatesController(NmsdbContext context)
        {
            this.context = context;
        }

        // GET: Templates
        public async Task<IActionResult> Index()
        {
            return this.View(await this.context.Template.ToListAsync());
        }

        // GET: Templates/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return this.NotFound();
            }

            var template = await this.context.Template
                .SingleOrDefaultAsync(m => m.Idtemplate == id);
            if (template == null)
            {
                return this.NotFound();
            }

            return this.View(template);
        }

        // GET: Templates/Create
        public IActionResult Create()
        {
            return this.View();
        }

        // POST: Templates/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Idtemplate,Name,Description,FkCustomer")] Template template)
        {
            if (this.ModelState.IsValid)
            {
                this.context.Add(template);
                await this.context.SaveChangesAsync();
                return this.RedirectToAction(nameof(this.Index));
            }

            return this.View(template);
        }

        // GET: Templates/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return this.NotFound();
            }

            var template = await this.context.Template.SingleOrDefaultAsync(m => m.Idtemplate == id);
            if (template == null)
            {
                return this.NotFound();
            }

            return this.View(template);
        }

        // POST: Templates/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Idtemplate,Name,Description,FkCustomer")] Template template)
        {
            if (id != template.Idtemplate)
            {
                return this.NotFound();
            }

            if (this.ModelState.IsValid)
            {
                try
                {
                    this.context.Update(template);
                    await this.context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!this.TemplateExists(template.Idtemplate))
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

            return this.View(template);
        }

        // GET: Templates/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return this.NotFound();
            }

            var template = await this.context.Template
                .SingleOrDefaultAsync(m => m.Idtemplate == id);
            if (template == null)
            {
                return this.NotFound();
            }

            return this.View(template);
        }

        // POST: Templates/Delete/5
        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var template = await this.context.Template.SingleOrDefaultAsync(m => m.Idtemplate == id);
            this.context.Template.Remove(template);
            await this.context.SaveChangesAsync();
            return this.RedirectToAction(nameof(this.Index));
        }

        private bool TemplateExists(int id)
        {
            return this.context.Template.Any(e => e.Idtemplate == id);
        }
    }
}
