// <copyright file="IvractionsController.cs" company="252afh">
//   Copyright © 252afh 2018. All rights reserved.
// </copyright>

namespace NMS.Controllers
{
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.EntityFrameworkCore;
    using NMS.Models;
    using NMS.Models.IvrActionViewModels;

    public class IvractionsController : Controller
    {
        private readonly NmsdbContext context;

        public IvractionsController(NmsdbContext context)
        {
            this.context = context;
        }

        // GET: Ivractions
        public async Task<IActionResult> Index()
        {
            return this.View(await this.context.Ivraction.ToListAsync());
        }

        // GET: Ivractions/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return this.NotFound();
            }

            var ivraction = await this.context.Ivraction
                .SingleOrDefaultAsync(m => m.Idivraction == id);
            if (ivraction == null)
            {
                return this.NotFound();
            }

            return this.View(ivraction);
        }

        // GET: Ivractions/Create
        public IActionResult Create()
        {
            return this.View();
        }

        // POST: Ivractions/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Idivraction,Digit,FkIvr,FkIvrDest,FkContactDest,FkAnnouncementDest,FkMailboxDest,VoicemailMain")] Ivraction ivraction)
        {
            if (this.ModelState.IsValid)
            {
                this.context.Add(ivraction);
                await this.context.SaveChangesAsync();
                return this.RedirectToAction(nameof(this.Index));
            }

            return this.View(ivraction);
        }

        // GET: Ivractions/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return this.NotFound();
            }

            var ivraction = await this.context.Ivraction.SingleOrDefaultAsync(m => m.Idivraction == id);
            if (ivraction == null)
            {
                return this.NotFound();
            }

            return this.View(ivraction);
        }

        // POST: Ivractions/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Idivraction,Digit,FkIvr,FkIvrDest,FkContactDest,FkAnnouncementDest,FkMailboxDest,VoicemailMain")] Ivraction ivraction)
        {
            if (id != ivraction.Idivraction)
            {
                return this.NotFound();
            }

            if (this.ModelState.IsValid)
            {
                try
                {
                    this.context.Update(ivraction);
                    await this.context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!this.IvractionExists(ivraction.Idivraction))
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

            return this.View(ivraction);
        }

        // GET: Ivractions/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return this.NotFound();
            }

            var ivraction = await this.context.Ivraction
                .SingleOrDefaultAsync(m => m.Idivraction == id);
            if (ivraction == null)
            {
                return this.NotFound();
            }

            return this.View(ivraction);
        }

        // POST: Ivractions/Delete/5
        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var ivraction = await this.context.Ivraction.SingleOrDefaultAsync(m => m.Idivraction == id);
            this.context.Ivraction.Remove(ivraction);
            await this.context.SaveChangesAsync();
            return this.RedirectToAction(nameof(this.Index));
        }

        private bool IvractionExists(int id)
        {
            return this.context.Ivraction.Any(e => e.Idivraction == id);
        }
    }
}
