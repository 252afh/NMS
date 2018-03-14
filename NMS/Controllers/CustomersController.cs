// <copyright file="CustomersController.cs" company="252afh">
//   Copyright © 252afh 2018. All rights reserved.
// </copyright>

namespace NMS.Controllers
{
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.EntityFrameworkCore;
    using NMS.Models;
    using NMS.Models.CustomerViewModels;

    public class CustomersController : Controller
    {
        private readonly nmsdbContext context;

        public CustomersController(nmsdbContext context)
        {
            this.context = context;
        }

        // GET: Customers
        public async Task<IActionResult> Index()
        {
            return this.View(await this.context.Customer.ToListAsync());
        }

        // GET: Customers/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return this.NotFound();
            }

            var customer = await this.context.Customer
                .SingleOrDefaultAsync(m => m.Idcustomer == id);
            if (customer == null)
            {
                return this.NotFound();
            }

            return this.View(customer);
        }

        // GET: Customers/Create
        public IActionResult Create()
        {
            return this.View();
        }

        // POST: Customers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Idcustomer,Name,Description,RoutingNumber,DefaultBillingNumber,NonGeo,FkExceptionLcr,BlockAnonymous,Customercol")] Customer customer)
        {
            if (this.ModelState.IsValid)
            {
                this.context.Add(customer);
                await this.context.SaveChangesAsync();
                return this.RedirectToAction(nameof(this.Index));
            }

            return this.View(customer);
        }

        // GET: Customers/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return this.NotFound();
            }

            var customer = await this.context.Customer.SingleOrDefaultAsync(m => m.Idcustomer == id);
            if (customer == null)
            {
                return this.NotFound();
            }

            return this.View(customer);
        }

        // POST: Customers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Idcustomer,Name,Description,RoutingNumber,DefaultBillingNumber,NonGeo,FkExceptionLcr,BlockAnonymous,Customercol")] Customer customer)
        {
            if (id != customer.Idcustomer)
            {
                return this.NotFound();
            }

            if (this.ModelState.IsValid)
            {
                try
                {
                    this.context.Update(customer);
                    await this.context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!this.CustomerExists(customer.Idcustomer))
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

            return this.View(customer);
        }

        // GET: Customers/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return this.NotFound();
            }

            var customer = await this.context.Customer
                .SingleOrDefaultAsync(m => m.Idcustomer == id);
            if (customer == null)
            {
                return this.NotFound();
            }

            return this.View(customer);
        }

        // POST: Customers/Delete/5
        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var customer = await this.context.Customer.SingleOrDefaultAsync(m => m.Idcustomer == id);
            this.context.Customer.Remove(customer);
            await this.context.SaveChangesAsync();
            return this.RedirectToAction(nameof(this.Index));
        }

        private bool CustomerExists(int id)
        {
            return this.context.Customer.Any(e => e.Idcustomer == id);
        }
    }
}
