// <copyright file="RoutingsController.cs" company="252afh">
//   Copyright © 252afh 2018. All rights reserved.
// </copyright>

namespace NMS.Controllers
{
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.EntityFrameworkCore;
    using NMS.Models;
    using NMS.Models.RoutingViewModels;

    public class RoutingsController : Controller
    {
        private readonly NmsdbContext context;

        public RoutingsController(NmsdbContext context)
        {
            this.context = context;
        }

        // GET: Routings
        public async Task<IActionResult> Index()
        {
            return this.View(await this.context.Routing.ToListAsync());
        }

        // GET: Routings/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return this.NotFound();
            }

            var routing = await this.context.Routing
                .SingleOrDefaultAsync(m => m.Idrouting == id);
            if (routing == null)
            {
                return this.NotFound();
            }

            return this.View(routing);
        }

        // GET: Routings/Create
        public IActionResult Create()
        {
            return this.View();
        }

        // POST: Routings/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Idrouting,Priority,RingingTime,FkContact,FkSite,Active,FkRoutingGroup,HuntBusy,FkAnnouncement,FkIvr,FkMailbox,VoicemailMain")] Routing routing)
        {
            if (this.ModelState.IsValid)
            {
                this.context.Add(routing);
                await this.context.SaveChangesAsync();
                return this.RedirectToAction(nameof(this.Index));
            }

            return this.View(routing);
        }

        // GET: Routings/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return this.NotFound();
            }

            var routing = await this.context.Routing.SingleOrDefaultAsync(m => m.Idrouting == id);
            if (routing == null)
            {
                return this.NotFound();
            }

            return this.View(routing);
        }

        // POST: Routings/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Idrouting,Priority,RingingTime,FkContact,FkSite,Active,FkRoutingGroup,HuntBusy,FkAnnouncement,FkIvr,FkMailbox,VoicemailMain")] Routing routing)
        {
            if (id != routing.Idrouting)
            {
                return this.NotFound();
            }

            if (this.ModelState.IsValid)
            {
                try
                {
                    this.context.Update(routing);
                    await this.context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!this.RoutingExists(routing.Idrouting))
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

            return this.View(routing);
        }

        // GET: Routings/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return this.NotFound();
            }

            var routing = await this.context.Routing
                .SingleOrDefaultAsync(m => m.Idrouting == id);
            if (routing == null)
            {
                return this.NotFound();
            }

            return this.View(routing);
        }

        // POST: Routings/Delete/5
        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var routing = await this.context.Routing.SingleOrDefaultAsync(m => m.Idrouting == id);
            this.context.Routing.Remove(routing);
            await this.context.SaveChangesAsync();
            return this.RedirectToAction(nameof(this.Index));
        }

        private bool RoutingExists(int id)
        {
            return this.context.Routing.Any(e => e.Idrouting == id);
        }
    }
}
