// <copyright file="CarrierNumberExceptionsController.cs" company="252afh">
//   Copyright © 252afh 2018. All rights reserved.
// </copyright>

namespace NMS.Controllers
{
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.EntityFrameworkCore;
    using NMS.Models;
    using NMS.Models.CarrierNumberExceptionViewModels;

    public class CarrierNumberExceptionsController : Controller
    {
        private readonly nmsdbContext context;

        public CarrierNumberExceptionsController(nmsdbContext context)
        {
            this.context = context;
        }

        // GET: CarrierNumberExceptions
        public async Task<IActionResult> Index()
        {
            return this.View(await this.context.CarrierNumberException.ToListAsync());
        }

        // GET: CarrierNumberExceptions/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return this.NotFound();
            }

            var carrierNumberException = await this.context.CarrierNumberException
                .SingleOrDefaultAsync(m => m.IdcarrierNumberException == id);
            if (carrierNumberException == null)
            {
                return this.NotFound();
            }

            return this.View(carrierNumberException);
        }

        // GET: CarrierNumberExceptions/Create
        public IActionResult Create()
        {
            return this.View();
        }

        // POST: CarrierNumberExceptions/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdcarrierNumberException,Priority,Status,FkCarrier,FkExceptionNumber,FkExceptionLcr")] CarrierNumberException carrierNumberException)
        {
            if (this.ModelState.IsValid)
            {
                this.context.Add(carrierNumberException);
                await this.context.SaveChangesAsync();
                return this.RedirectToAction(nameof(this.Index));
            }

            return this.View(carrierNumberException);
        }

        // GET: CarrierNumberExceptions/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return this.NotFound();
            }

            var carrierNumberException = await this.context.CarrierNumberException.SingleOrDefaultAsync(m => m.IdcarrierNumberException == id);
            if (carrierNumberException == null)
            {
                return this.NotFound();
            }

            return this.View(carrierNumberException);
        }

        // POST: CarrierNumberExceptions/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdcarrierNumberException,Priority,Status,FkCarrier,FkExceptionNumber,FkExceptionLcr")] CarrierNumberException carrierNumberException)
        {
            if (id != carrierNumberException.IdcarrierNumberException)
            {
                return this.NotFound();
            }

            if (this.ModelState.IsValid)
            {
                try
                {
                    this.context.Update(carrierNumberException);
                    await this.context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!this.CarrierNumberExceptionExists(carrierNumberException.IdcarrierNumberException))
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

            return this.View(carrierNumberException);
        }

        // GET: CarrierNumberExceptions/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return this.NotFound();
            }

            var carrierNumberException = await this.context.CarrierNumberException
                .SingleOrDefaultAsync(m => m.IdcarrierNumberException == id);
            if (carrierNumberException == null)
            {
                return this.NotFound();
            }

            return this.View(carrierNumberException);
        }

        // POST: CarrierNumberExceptions/Delete/5
        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var carrierNumberException = await this.context.CarrierNumberException.SingleOrDefaultAsync(m => m.IdcarrierNumberException == id);
            this.context.CarrierNumberException.Remove(carrierNumberException);
            await this.context.SaveChangesAsync();
            return this.RedirectToAction(nameof(this.Index));
        }

        private bool CarrierNumberExceptionExists(int id)
        {
            return this.context.CarrierNumberException.Any(e => e.IdcarrierNumberException == id);
        }
    }
}
