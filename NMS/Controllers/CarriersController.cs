// <copyright file="CarriersController.cs" company="252afh">
//   Copyright © 252afh 2018. All rights reserved.
// </copyright>

namespace NMS.Controllers
{
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.EntityFrameworkCore;
    using NMS.Models;
    using NMS.Models.CarrierViewModels;

    public class CarriersController : Controller
    {
        private readonly nmsdbContext context;

        public CarriersController(nmsdbContext context)
        {
            this.context = context;
        }

        // GET: Carriers
        public async Task<IActionResult> Index()
        {
            return this.View(await this.context.Carrier.ToListAsync());
        }

        // GET: Carriers/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return this.NotFound();
            }

            var carrier = await this.context.Carrier
                .SingleOrDefaultAsync(m => m.Idcarrier == id);
            if (carrier == null)
            {
                return this.NotFound();
            }

            return this.View(carrier);
        }

        // GET: Carriers/Create
        public IActionResult Create()
        {
            return this.View();
        }

        // POST: Carriers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Idcarrier,Name,Description,Domain,RoutingNumber,BillingNumber,Preference")] Carrier carrier)
        {
            if (this.ModelState.IsValid)
            {
                this.context.Add(carrier);
                await this.context.SaveChangesAsync();
                return this.RedirectToAction(nameof(this.Index));
            }

            return this.View(carrier);
        }

        // GET: Carriers/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return this.NotFound();
            }

            var carrier = await this.context.Carrier.SingleOrDefaultAsync(m => m.Idcarrier == id);
            if (carrier == null)
            {
                return this.NotFound();
            }

            return this.View(carrier);
        }

        // POST: Carriers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Idcarrier,Name,Description,Domain,RoutingNumber,BillingNumber,Preference")] Carrier carrier)
        {
            if (id != carrier.Idcarrier)
            {
                return this.NotFound();
            }

            if (this.ModelState.IsValid)
            {
                try
                {
                    this.context.Update(carrier);
                    await this.context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!this.CarrierExists(carrier.Idcarrier))
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

            return this.View(carrier);
        }

        // GET: Carriers/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return this.NotFound();
            }

            var carrier = await this.context.Carrier
                .SingleOrDefaultAsync(m => m.Idcarrier == id);
            if (carrier == null)
            {
                return this.NotFound();
            }

            return this.View(carrier);
        }

        // POST: Carriers/Delete/5
        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var carrier = await this.context.Carrier.SingleOrDefaultAsync(m => m.Idcarrier == id);
            this.context.Carrier.Remove(carrier);
            await this.context.SaveChangesAsync();
            return this.RedirectToAction(nameof(this.Index));
        }

        private bool CarrierExists(int id)
        {
            return this.context.Carrier.Any(e => e.Idcarrier == id);
        }
    }
}
