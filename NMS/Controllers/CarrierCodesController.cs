// <copyright file="CarrierCodesController.cs" company="252afh">
//   Copyright © 252afh 2018. All rights reserved.
// </copyright>

namespace NMS.Controllers
{
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.EntityFrameworkCore;
    using NMS.Models;
    using NMS.Models.CarrierCodeViewModels;

    public class CarrierCodesController : Controller
    {
        private readonly NmsdbContext context;

        public CarrierCodesController(NmsdbContext context)
        {
            this.context = context;
        }

        // GET: CarrierCodes
        public async Task<IActionResult> Index()
        {
            return this.View(await this.context.CarrierCode.ToListAsync());
        }

        // GET: CarrierCodes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return this.NotFound();
            }

            var carrierCode = await this.context.CarrierCode
                .SingleOrDefaultAsync(m => m.IdcarrierCode == id);
            if (carrierCode == null)
            {
                return this.NotFound();
            }

            return this.View(carrierCode);
        }

        // GET: CarrierCodes/Create
        public IActionResult Create()
        {
            return this.View();
        }

        // POST: CarrierCodes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdcarrierCode,Priority,Status,FkCarrier,FkCode,FkLcr")] CarrierCode carrierCode)
        {
            if (this.ModelState.IsValid)
            {
                this.context.Add(carrierCode);
                await this.context.SaveChangesAsync();
                return this.RedirectToAction(nameof(this.Index));
            }

            return this.View(carrierCode);
        }

        // GET: CarrierCodes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return this.NotFound();
            }

            var carrierCode = await this.context.CarrierCode.SingleOrDefaultAsync(m => m.IdcarrierCode == id);
            if (carrierCode == null)
            {
                return this.NotFound();
            }

            return this.View(carrierCode);
        }

        // POST: CarrierCodes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdcarrierCode,Priority,Status,FkCarrier,FkCode,FkLcr")] CarrierCode carrierCode)
        {
            if (id != carrierCode.IdcarrierCode)
            {
                return this.NotFound();
            }

            if (this.ModelState.IsValid)
            {
                try
                {
                    this.context.Update(carrierCode);
                    await this.context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!this.CarrierCodeExists(carrierCode.IdcarrierCode))
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

            return this.View(carrierCode);
        }

        // GET: CarrierCodes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return this.NotFound();
            }

            var carrierCode = await this.context.CarrierCode
                .SingleOrDefaultAsync(m => m.IdcarrierCode == id);
            if (carrierCode == null)
            {
                return this.NotFound();
            }

            return this.View(carrierCode);
        }

        // POST: CarrierCodes/Delete/5
        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var carrierCode = await this.context.CarrierCode.SingleOrDefaultAsync(m => m.IdcarrierCode == id);
            this.context.CarrierCode.Remove(carrierCode);
            await this.context.SaveChangesAsync();
            return this.RedirectToAction(nameof(this.Index));
        }

        private bool CarrierCodeExists(int id)
        {
            return this.context.CarrierCode.Any(e => e.IdcarrierCode == id);
        }
    }
}
