// <copyright file="RoutinggroupsController.cs" company="252afh">
//   Copyright © 252afh 2018. All rights reserved.
// </copyright>

namespace NMS.Controllers
{
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.EntityFrameworkCore;
    using NMS.Models;
    using NMS.Models.RoutingGroupViewModels;

    public class RoutinggroupsController : Controller
    {
        private readonly NmsdbContext context;

        public RoutinggroupsController(NmsdbContext context)
        {
            this.context = context;
        }

        // GET: Routinggroups
        public async Task<IActionResult> Index()
        {
            return this.View(await this.context.Routinggroup.ToListAsync());
        }

        // GET: Routinggroups/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return this.NotFound();
            }

            var routinggroup = await this.context.Routinggroup
                .SingleOrDefaultAsync(m => m.IdroutingGroup == id);
            if (routinggroup == null)
            {
                return this.NotFound();
            }

            return this.View(routinggroup);
        }

        // GET: Routinggroups/Create
        public IActionResult Create()
        {
            return this.View();
        }

        // POST: Routinggroups/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdroutingGroup,Name,Description,Active,IsUserGenerated,FkCustomer,Forking")] Routinggroup routinggroup)
        {
            if (this.ModelState.IsValid)
            {
                this.context.Add(routinggroup);
                await this.context.SaveChangesAsync();
                return this.RedirectToAction(nameof(this.Index));
            }

            return this.View(routinggroup);
        }

        // GET: Routinggroups/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return this.NotFound();
            }

            var routinggroup = await this.context.Routinggroup.SingleOrDefaultAsync(m => m.IdroutingGroup == id);
            if (routinggroup == null)
            {
                return this.NotFound();
            }

            return this.View(routinggroup);
        }

        // POST: Routinggroups/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdroutingGroup,Name,Description,Active,IsUserGenerated,FkCustomer,Forking")] Routinggroup routinggroup)
        {
            if (id != routinggroup.IdroutingGroup)
            {
                return this.NotFound();
            }

            if (this.ModelState.IsValid)
            {
                try
                {
                    this.context.Update(routinggroup);
                    await this.context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!this.RoutinggroupExists(routinggroup.IdroutingGroup))
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

            return this.View(routinggroup);
        }

        // GET: Routinggroups/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return this.NotFound();
            }

            var routinggroup = await this.context.Routinggroup
                .SingleOrDefaultAsync(m => m.IdroutingGroup == id);
            if (routinggroup == null)
            {
                return this.NotFound();
            }

            return this.View(routinggroup);
        }

        // POST: Routinggroups/Delete/5
        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var routinggroup = await this.context.Routinggroup.SingleOrDefaultAsync(m => m.IdroutingGroup == id);
            this.context.Routinggroup.Remove(routinggroup);
            await this.context.SaveChangesAsync();
            return this.RedirectToAction(nameof(this.Index));
        }

        private bool RoutinggroupExists(int id)
        {
            return this.context.Routinggroup.Any(e => e.IdroutingGroup == id);
        }
    }
}
