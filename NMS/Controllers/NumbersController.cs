using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using NMS.Models;

namespace NMS.Controllers
{
    [Authorize]
    public class NumbersController : Controller
    {
        private readonly NMSDBContext _context;

        public NumbersController(NMSDBContext context)
        {
            _context = context;
        }

        // GET: Numbers
        public async Task<IActionResult> Index()
        {
            var customerList = _context.Number.ToListAsync();
            var numberList = _context.Customer.ToListAsync();
            dynamic model = new ExpandoObject();
            model.Numbers = customerList();
            return View(await _context.Number.ToListAsync());
        }

        // GET: Numbers/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var number = await _context.Number
                .SingleOrDefaultAsync(m => m.Id == id);
            if (number == null)
            {
                return NotFound();
            }

            return View(number);
        }

        // GET: Numbers/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Numbers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Number1,Description,FkCustomer,FkGroup,ActiveDate,CustomerDescription,CeaseDate")] Number number)
        {
            if (ModelState.IsValid)
            {
                _context.Add(number);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(number);
        }

        // GET: Numbers/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var number = await _context.Number.SingleOrDefaultAsync(m => m.Id == id);
            if (number == null)
            {
                return NotFound();
            }
            return View(number);
        }

        // POST: Numbers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Number1,Description,FkCustomer,FkGroup,ActiveDate,CustomerDescription,CeaseDate")] Number number)
        {
            if (id != number.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(number);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!NumberExists(number.Id))
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
            return View(number);
        }

        // GET: Numbers/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var number = await _context.Number
                .SingleOrDefaultAsync(m => m.Id == id);
            if (number == null)
            {
                return NotFound();
            }

            return View(number);
        }

        // POST: Numbers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var number = await _context.Number.SingleOrDefaultAsync(m => m.Id == id);
            _context.Number.Remove(number);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool NumberExists(int id)
        {
            return _context.Number.Any(e => e.Id == id);
        }
    }
}
