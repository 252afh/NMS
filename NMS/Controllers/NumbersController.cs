// <copyright file="NumbersController.cs" company="252afh">
//   Copyright © 252afh 2018. All rights reserved.
// </copyright>

namespace NMS.Controllers
{
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.EntityFrameworkCore;
    using NMS.Models;
    using NMS.Models.NumberViewModels;

    public class NumbersController : Controller
    {
        private readonly NmsdbContext context;

        public NumbersController(NmsdbContext context)
        {
            this.context = context;
        }

        // GET: Numbers
        public async Task<IActionResult> Index()
        {
            return this.View(await this.context.Number.ToListAsync());
        }

        // GET: Numbers/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return this.NotFound();
            }

            var number = await this.context.Number
                .SingleOrDefaultAsync(m => m.Idnumber == id);
            if (number == null)
            {
                return this.NotFound();
            }

            return this.View(number);
        }

        // GET: Numbers/Create
        public IActionResult Create()
        {
            return this.View();
        }

        // POST: Numbers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Idnumber,Number1,Description,FkCustomer,FkGroup,ActiveDate,CustomerDescription,CeaseDate")] Number number)
        {
            if (this.ModelState.IsValid)
            {
                this.context.Add(number);
                await this.context.SaveChangesAsync();
                return this.RedirectToAction(nameof(this.Index));
            }

            return this.View(number);
        }

        // GET: Numbers/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return this.NotFound();
            }

            var number = await this.context.Number.SingleOrDefaultAsync(m => m.Idnumber == id);
            if (number == null)
            {
                return this.NotFound();
            }

            return this.View(number);
        }

        // POST: Numbers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Idnumber,Number1,Description,FkCustomer,FkGroup,ActiveDate,CustomerDescription,CeaseDate")] Number number)
        {
            if (id != number.Idnumber)
            {
                return this.NotFound();
            }

            if (this.ModelState.IsValid)
            {
                try
                {
                    this.context.Update(number);
                    await this.context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!this.NumberExists(number.Idnumber))
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

            return this.View(number);
        }

        // GET: Numbers/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return this.NotFound();
            }

            var number = await this.context.Number
                .SingleOrDefaultAsync(m => m.Idnumber == id);
            if (number == null)
            {
                return this.NotFound();
            }

            return this.View(number);
        }

        // POST: Numbers/Delete/5
        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var number = await this.context.Number.SingleOrDefaultAsync(m => m.Idnumber == id);
            this.context.Number.Remove(number);
            await this.context.SaveChangesAsync();
            return this.RedirectToAction(nameof(this.Index));
        }

        private bool NumberExists(int id)
        {
            return this.context.Number.Any(e => e.Idnumber == id);
        }
    }
}
