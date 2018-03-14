using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using NMS.Models;
using NMS.Models.NumberGroupViewModels;

namespace NMS.Controllers
{
    public class NumbergroupsController : Controller
    {
        private readonly nmsdbContext _context;

        public NumbergroupsController(nmsdbContext context)
        {
            _context = context;
        }

        // GET: Numbergroups
        public async Task<IActionResult> Index()
        {
            return View(await _context.Numbergroup.ToListAsync());
        }

        // GET: Numbergroups/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var numbergroup = await _context.Numbergroup
                .SingleOrDefaultAsync(m => m.Idgroup == id);
            if (numbergroup == null)
            {
                return NotFound();
            }

            return View(numbergroup);
        }

        // GET: Numbergroups/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Numbergroups/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Idgroup,Name,Description,FkCustomer")] Numbergroup numbergroup)
        {
            if (ModelState.IsValid)
            {
                _context.Add(numbergroup);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(numbergroup);
        }

        // GET: Numbergroups/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var numbergroup = await _context.Numbergroup.SingleOrDefaultAsync(m => m.Idgroup == id);
            if (numbergroup == null)
            {
                return NotFound();
            }
            return View(numbergroup);
        }

        // POST: Numbergroups/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Idgroup,Name,Description,FkCustomer")] Numbergroup numbergroup)
        {
            if (id != numbergroup.Idgroup)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(numbergroup);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!NumbergroupExists(numbergroup.Idgroup))
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
            return View(numbergroup);
        }

        // GET: Numbergroups/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var numbergroup = await _context.Numbergroup
                .SingleOrDefaultAsync(m => m.Idgroup == id);
            if (numbergroup == null)
            {
                return NotFound();
            }

            return View(numbergroup);
        }

        // POST: Numbergroups/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var numbergroup = await _context.Numbergroup.SingleOrDefaultAsync(m => m.Idgroup == id);
            _context.Numbergroup.Remove(numbergroup);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool NumbergroupExists(int id)
        {
            return _context.Numbergroup.Any(e => e.Idgroup == id);
        }
    }
}
