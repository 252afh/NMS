using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using NMS.Models;
using NMS.Models.FeatureCustomerViewModels;

namespace NMS.Controllers
{
    public class FeatureCustomersController : Controller
    {
        private readonly nmsdbContext _context;

        public FeatureCustomersController(nmsdbContext context)
        {
            _context = context;
        }

        // GET: FeatureCustomers
        public async Task<IActionResult> Index()
        {
            return View(await _context.FeatureCustomer.ToListAsync());
        }

        // GET: FeatureCustomers/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var featureCustomer = await _context.FeatureCustomer
                .SingleOrDefaultAsync(m => m.IdfeatureCustomer == id);
            if (featureCustomer == null)
            {
                return NotFound();
            }

            return View(featureCustomer);
        }

        // GET: FeatureCustomers/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: FeatureCustomers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdfeatureCustomer,DateFrom,DateTo,Quantity,FkFeature,FkCustomer")] FeatureCustomer featureCustomer)
        {
            if (ModelState.IsValid)
            {
                _context.Add(featureCustomer);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(featureCustomer);
        }

        // GET: FeatureCustomers/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var featureCustomer = await _context.FeatureCustomer.SingleOrDefaultAsync(m => m.IdfeatureCustomer == id);
            if (featureCustomer == null)
            {
                return NotFound();
            }
            return View(featureCustomer);
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
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(featureCustomer);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FeatureCustomerExists(featureCustomer.IdfeatureCustomer))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(featureCustomer);
        }

        // GET: FeatureCustomers/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var featureCustomer = await _context.FeatureCustomer
                .SingleOrDefaultAsync(m => m.IdfeatureCustomer == id);
            if (featureCustomer == null)
            {
                return NotFound();
            }

            return View(featureCustomer);
        }

        // POST: FeatureCustomers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var featureCustomer = await _context.FeatureCustomer.SingleOrDefaultAsync(m => m.IdfeatureCustomer == id);
            _context.FeatureCustomer.Remove(featureCustomer);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FeatureCustomerExists(int id)
        {
            return _context.FeatureCustomer.Any(e => e.IdfeatureCustomer == id);
        }
    }
}
