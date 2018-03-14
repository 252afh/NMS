// <copyright file="CarrierCodeExceptionsController.cs" company="252afh">
//   Copyright © 252afh 2018. All rights reserved.
// </copyright>

namespace NMS.Controllers
{
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.EntityFrameworkCore;
    using NMS.Models;
    using NMS.Models.CarrierCodeExceptionViewModels;

    public class CarrierCodeExceptionsController : Controller
    {
        private readonly nmsdbContext context;

        public CarrierCodeExceptionsController(nmsdbContext context)
        {
            this.context = context;
        }

        // GET: CarrierCodeExceptions
        public async Task<IActionResult> Index()
        {
            return this.View(await this.context.CarrierCodeException.ToListAsync());
        }

        // GET: CarrierCodeExceptions/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return this.NotFound();
            }

            var carrierCodeException = await this.context.CarrierCodeException
                .SingleOrDefaultAsync(m => m.IdcarrierCodeException == id);
            if (carrierCodeException == null)
            {
                return this.NotFound();
            }

            return this.View(carrierCodeException);
        }

        // GET: CarrierCodeExceptions/Create
        public IActionResult Create()
        {
            return this.View();
        }

        // POST: CarrierCodeExceptions/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdcarrierCodeException,Priority,Status,FkCarrier,FkCode,FkExceptionLcr")] CarrierCodeException carrierCodeException)
        {
            if (this.ModelState.IsValid)
            {
                this.context.Add(carrierCodeException);
                await this.context.SaveChangesAsync();
                return this.RedirectToAction(nameof(this.Index));
            }

            return this.View(carrierCodeException);
        }

        // GET: CarrierCodeExceptions/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return this.NotFound();
            }

            var carrierCodeException = await this.context.CarrierCodeException.SingleOrDefaultAsync(m => m.IdcarrierCodeException == id);
            if (carrierCodeException == null)
            {
                return this.NotFound();
            }

            return this.View(carrierCodeException);
        }

        // POST: CarrierCodeExceptions/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdcarrierCodeException,Priority,Status,FkCarrier,FkCode,FkExceptionLcr")] CarrierCodeException carrierCodeException)
        {
            if (id != carrierCodeException.IdcarrierCodeException)
            {
                return this.NotFound();
            }

            if (this.ModelState.IsValid)
            {
                try
                {
                    this.context.Update(carrierCodeException);
                    await this.context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!this.CarrierCodeExceptionExists(carrierCodeException.IdcarrierCodeException))
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

            return this.View(carrierCodeException);
        }

        // GET: CarrierCodeExceptions/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return this.NotFound();
            }

            var carrierCodeException = await this.context.CarrierCodeException
                .SingleOrDefaultAsync(m => m.IdcarrierCodeException == id);
            if (carrierCodeException == null)
            {
                return this.NotFound();
            }

            return this.View(carrierCodeException);
        }

        // POST: CarrierCodeExceptions/Delete/5
        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var carrierCodeException = await this.context.CarrierCodeException.SingleOrDefaultAsync(m => m.IdcarrierCodeException == id);
            this.context.CarrierCodeException.Remove(carrierCodeException);
            await this.context.SaveChangesAsync();
            return this.RedirectToAction(nameof(this.Index));
        }

        private bool CarrierCodeExceptionExists(int id)
        {
            return this.context.CarrierCodeException.Any(e => e.IdcarrierCodeException == id);
        }
    }
}
