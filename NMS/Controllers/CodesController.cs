// <copyright file="CodesController.cs" company="252afh">
//   Copyright © 252afh 2018. All rights reserved.
// </copyright>

namespace NMS.Controllers
{
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.EntityFrameworkCore;
    using NMS.Models;
    using NMS.Models.CodeViewModels;

    public class CodesController : Controller
    {
        private readonly nmsdbContext context;

        public CodesController(nmsdbContext context)
        {
            this.context = context;
        }

        // GET: Codes
        public async Task<IActionResult> Index()
        {
            return this.View(await this.context.Code.ToListAsync());
        }

        // GET: Codes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return this.NotFound();
            }

            var code = await this.context.Code
                .SingleOrDefaultAsync(m => m.Idcode == id);
            if (code == null)
            {
                return this.NotFound();
            }

            return this.View(code);
        }

        // GET: Codes/Create
        public IActionResult Create()
        {
            return this.View();
        }

        // POST: Codes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Idcode,DialledNumber,Description")] Code code)
        {
            if (this.ModelState.IsValid)
            {
                this.context.Add(code);
                await this.context.SaveChangesAsync();
                return this.RedirectToAction(nameof(this.Index));
            }

            return this.View(code);
        }

        // GET: Codes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return this.NotFound();
            }

            var code = await this.context.Code.SingleOrDefaultAsync(m => m.Idcode == id);
            if (code == null)
            {
                return this.NotFound();
            }

            return this.View(code);
        }

        // POST: Codes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Idcode,DialledNumber,Description")] Code code)
        {
            if (id != code.Idcode)
            {
                return this.NotFound();
            }

            if (this.ModelState.IsValid)
            {
                try
                {
                    this.context.Update(code);
                    await this.context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!this.CodeExists(code.Idcode))
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

            return this.View(code);
        }

        // GET: Codes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return this.NotFound();
            }

            var code = await this.context.Code
                .SingleOrDefaultAsync(m => m.Idcode == id);
            if (code == null)
            {
                return this.NotFound();
            }

            return this.View(code);
        }

        // POST: Codes/Delete/5
        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var code = await this.context.Code.SingleOrDefaultAsync(m => m.Idcode == id);
            this.context.Code.Remove(code);
            await this.context.SaveChangesAsync();
            return this.RedirectToAction(nameof(this.Index));
        }

        private bool CodeExists(int id)
        {
            return this.context.Code.Any(e => e.Idcode == id);
        }
    }
}
