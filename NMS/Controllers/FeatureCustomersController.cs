// <copyright file="FeatureCustomersController.cs" company="252afh">
//   Copyright © 252afh 2018. All rights reserved.
// </copyright>

namespace NMS.Controllers
{
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.EntityFrameworkCore;
    using NMS.Models;
    using NMS.Models.FeatureCustomerViewModels;

    public class FeatureCustomersController : Controller
    {
        private readonly NmsdbContext context;

        public FeatureCustomersController(NmsdbContext context)
        {
            this.context = context;
        }

        // GET: FeatureCustomers
        public async Task<IActionResult> Index()
        {
            return this.View(await this.context.FeatureCustomer.ToListAsync());
        }

        // GET: FeatureCustomers/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return this.NotFound();
            }

            var featureCustomer = await this.context.FeatureCustomer
                .SingleOrDefaultAsync(m => m.IdfeatureCustomer == id);
            if (featureCustomer == null)
            {
                return this.NotFound();
            }

            return this.View(featureCustomer);
        }

        // GET: FeatureCustomers/Create
        public IActionResult Create()
        {
            return this.View();
        }

        // POST: FeatureCustomers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdfeatureCustomer,DateFrom,DateTo,Quantity,FkFeature,FkCustomer")] FeatureCustomer featureCustomer)
        {
            if (this.ModelState.IsValid)
            {
                this.context.Add(featureCustomer);
                await this.context.SaveChangesAsync();
                return this.RedirectToAction(nameof(this.Index));
            }

            return this.View(featureCustomer);
        }

        // GET: FeatureCustomers/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return this.NotFound();
            }

            var featureCustomer = await this.context.FeatureCustomer.SingleOrDefaultAsync(m => m.IdfeatureCustomer == id);
            if (featureCustomer == null)
            {
                return this.NotFound();
            }

            return this.View(featureCustomer);
        }

        // POST: FeatureCustomers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdfeatureCustomer,DateFrom,DateTo,Quantity,FkFeature,FkCustomer")] FeatureCustomer featureCustomer)
        {
            if (id != featureCustomer.IdfeatureCustomer)
            {
                return this.NotFound();
            }

            if (this.ModelState.IsValid)
            {
                try
                {
                    this.context.Update(featureCustomer);
                    await this.context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!this.FeatureCustomerExists(featureCustomer.IdfeatureCustomer))
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

            return this.View(featureCustomer);
        }

        // GET: FeatureCustomers/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return this.NotFound();
            }

            var featureCustomer = await this.context.FeatureCustomer
                .SingleOrDefaultAsync(m => m.IdfeatureCustomer == id);
            if (featureCustomer == null)
            {
                return this.NotFound();
            }

            return this.View(featureCustomer);
        }

        // POST: FeatureCustomers/Delete/5
        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var featureCustomer = await this.context.FeatureCustomer.SingleOrDefaultAsync(m => m.IdfeatureCustomer == id);
            this.context.FeatureCustomer.Remove(featureCustomer);
            await this.context.SaveChangesAsync();
            return this.RedirectToAction(nameof(this.Index));
        }

        private bool FeatureCustomerExists(int id)
        {
            return this.context.FeatureCustomer.Any(e => e.IdfeatureCustomer == id);
        }
    }
}
