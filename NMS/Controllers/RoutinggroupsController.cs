using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using NMS.Models;
using NMS.Models.RoutingGroupViewModels;

namespace NMS.Controllers
{
    public class RoutinggroupsController : Controller
    {
        private readonly nmsdbContext _context;

        public RoutinggroupsController(nmsdbContext context)
        {
            _context = context;
        }

        // GET: Routinggroups
        public async Task<IActionResult> Index()
        {
            return View(await _context.Routinggroup.ToListAsync());
        }

        // GET: Routinggroups/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var routinggroup = await _context.Routinggroup
                .SingleOrDefaultAsync(m => m.IdroutingGroup == id);
            if (routinggroup == null)
            {
                return NotFound();
            }

            return View(routinggroup);
        }

        // GET: Routinggroups/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Routinggroups/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdroutingGroup,Name,Description,Active,IsUserGenerated,FkCustomer,Forking")] Routinggroup routinggroup)
        {
            if (ModelState.IsValid)
            {
                _context.Add(routinggroup);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(routinggroup);
        }

        // GET: Routinggroups/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var routinggroup = await _context.Routinggroup.SingleOrDefaultAsync(m => m.IdroutingGroup == id);
            if (routinggroup == null)
            {
                return NotFound();
            }
            return View(routinggroup);
        }

        // POST: Routinggroups/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdroutingGroup,Name,Description,Active,IsUserGenerated,FkCustomer,Forking")] Routinggroup routinggroup)
        {
            if (id != routinggroup.IdroutingGroup)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(routinggroup);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RoutinggroupExists(routinggroup.IdroutingGroup))
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
            return View(routinggroup);
        }

        // GET: Routinggroups/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var routinggroup = await _context.Routinggroup
                .SingleOrDefaultAsync(m => m.IdroutingGroup == id);
            if (routinggroup == null)
            {
                return NotFound();
            }

            return View(routinggroup);
        }

        // POST: Routinggroups/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var routinggroup = await _context.Routinggroup.SingleOrDefaultAsync(m => m.IdroutingGroup == id);
            _context.Routinggroup.Remove(routinggroup);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RoutinggroupExists(int id)
        {
            return _context.Routinggroup.Any(e => e.IdroutingGroup == id);
        }
    }
}
