// <copyright file="LogsController.cs" company="252afh">
//   Copyright © 252afh 2018. All rights reserved.
// </copyright>

namespace NMS.Controllers
{
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.EntityFrameworkCore;
    using NMS.Models;
    using NMS.Models.LogViewModels;

    public class LogsController : Controller
    {
        private readonly nmsdbContext context;

        public LogsController(nmsdbContext context)
        {
            this.context = context;
        }

        // GET: Logs
        public async Task<IActionResult> Index()
        {
            return this.View(await this.context.Log.ToListAsync());
        }

        // GET: Logs/Details/5
        public async Task<IActionResult> Details(long? id)
        {
            if (id == null)
            {
                return this.NotFound();
            }

            var log = await this.context.Log
                .SingleOrDefaultAsync(m => m.Idlog == id);
            if (log == null)
            {
                return this.NotFound();
            }

            return this.View(log);
        }

        // GET: Logs/Create
        public IActionResult Create()
        {
            return this.View();
        }

        // POST: Logs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Idlog,Action,Timestamp,Table,Attribute,NewValue,IdModified,FkUser")] Log log)
        {
            if (this.ModelState.IsValid)
            {
                this.context.Add(log);
                await this.context.SaveChangesAsync();
                return this.RedirectToAction(nameof(this.Index));
            }

            return this.View(log);
        }

        // GET: Logs/Edit/5
        public async Task<IActionResult> Edit(long? id)
        {
            if (id == null)
            {
                return this.NotFound();
            }

            var log = await this.context.Log.SingleOrDefaultAsync(m => m.Idlog == id);
            if (log == null)
            {
                return this.NotFound();
            }

            return this.View(log);
        }

        // POST: Logs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long id, [Bind("Idlog,Action,Timestamp,Table,Attribute,NewValue,IdModified,FkUser")] Log log)
        {
            if (id != log.Idlog)
            {
                return this.NotFound();
            }

            if (this.ModelState.IsValid)
            {
                try
                {
                    this.context.Update(log);
                    await this.context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!this.LogExists(log.Idlog))
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

            return this.View(log);
        }

        // GET: Logs/Delete/5
        public async Task<IActionResult> Delete(long? id)
        {
            if (id == null)
            {
                return this.NotFound();
            }

            var log = await this.context.Log
                .SingleOrDefaultAsync(m => m.Idlog == id);
            if (log == null)
            {
                return this.NotFound();
            }

            return this.View(log);
        }

        // POST: Logs/Delete/5
        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long id)
        {
            var log = await this.context.Log.SingleOrDefaultAsync(m => m.Idlog == id);
            this.context.Log.Remove(log);
            await this.context.SaveChangesAsync();
            return this.RedirectToAction(nameof(this.Index));
        }

        private bool LogExists(long id)
        {
            return this.context.Log.Any(e => e.Idlog == id);
        }
    }
}
