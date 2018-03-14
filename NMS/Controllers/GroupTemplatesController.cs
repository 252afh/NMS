// <copyright file="GroupTemplatesController.cs" company="252afh">
//   Copyright © 252afh 2018. All rights reserved.
// </copyright>

namespace NMS.Controllers
{
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.EntityFrameworkCore;
    using NMS.Models;
    using NMS.Models.GroupTemplateViewModels;

    public class GroupTemplatesController : Controller
    {
        private readonly nmsdbContext context;

        public GroupTemplatesController(nmsdbContext context)
        {
            this.context = context;
        }

        // GET: GroupTemplates
        public async Task<IActionResult> Index()
        {
            return this.View(await this.context.GroupTemplate.ToListAsync());
        }

        // GET: GroupTemplates/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return this.NotFound();
            }

            var groupTemplate = await this.context.GroupTemplate
                .SingleOrDefaultAsync(m => m.IdgroupTemplate == id);
            if (groupTemplate == null)
            {
                return this.NotFound();
            }

            return this.View(groupTemplate);
        }

        // GET: GroupTemplates/Create
        public IActionResult Create()
        {
            return this.View();
        }

        // POST: GroupTemplates/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdgroupTemplate,FkGroup,FkTemplate,Priority,Active,FkRoutingGroup")] GroupTemplate groupTemplate)
        {
            if (this.ModelState.IsValid)
            {
                this.context.Add(groupTemplate);
                await this.context.SaveChangesAsync();
                return this.RedirectToAction(nameof(this.Index));
            }

            return this.View(groupTemplate);
        }

        // GET: GroupTemplates/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return this.NotFound();
            }

            var groupTemplate = await this.context.GroupTemplate.SingleOrDefaultAsync(m => m.IdgroupTemplate == id);
            if (groupTemplate == null)
            {
                return this.NotFound();
            }

            return this.View(groupTemplate);
        }

        // POST: GroupTemplates/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdgroupTemplate,FkGroup,FkTemplate,Priority,Active,FkRoutingGroup")] GroupTemplate groupTemplate)
        {
            if (id != groupTemplate.IdgroupTemplate)
            {
                return this.NotFound();
            }

            if (this.ModelState.IsValid)
            {
                try
                {
                    this.context.Update(groupTemplate);
                    await this.context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!this.GroupTemplateExists(groupTemplate.IdgroupTemplate))
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

            return this.View(groupTemplate);
        }

        // GET: GroupTemplates/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return this.NotFound();
            }

            var groupTemplate = await this.context.GroupTemplate
                .SingleOrDefaultAsync(m => m.IdgroupTemplate == id);
            if (groupTemplate == null)
            {
                return this.NotFound();
            }

            return this.View(groupTemplate);
        }

        // POST: GroupTemplates/Delete/5
        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var groupTemplate = await this.context.GroupTemplate.SingleOrDefaultAsync(m => m.IdgroupTemplate == id);
            this.context.GroupTemplate.Remove(groupTemplate);
            await this.context.SaveChangesAsync();
            return this.RedirectToAction(nameof(this.Index));
        }

        private bool GroupTemplateExists(int id)
        {
            return this.context.GroupTemplate.Any(e => e.IdgroupTemplate == id);
        }
    }
}
