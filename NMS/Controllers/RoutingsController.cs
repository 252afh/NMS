using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using NMS.Models;
using NMS.Models.RoutingViewModels;

namespace NMS.Controllers
{
    public class RoutingsController : Controller
    {
        private readonly nmsdbContext _context;

        public RoutingsController(nmsdbContext context)
        {
            _context = context;
        }

        // GET: Routings
        public async Task<IActionResult> Index()
        {
            return View(await _context.Routing.ToListAsync());
        }

        // GET: Routings/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var routing = await _context.Routing
                .SingleOrDefaultAsync(m => m.Idrouting == id);
            if (routing == null)
            {
                return NotFound();
            }

            return View(routing);
        }

        // GET: Routings/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Routings/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Idrouting,Priority,RingingTime,FkContact,FkSite,Active,FkRoutingGroup,HuntBusy,FkAnnouncement,FkIvr,FkMailbox,VoicemailMain")] Routing routing)
        {
            if (ModelState.IsValid)
            {
                _context.Add(routing);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(routing);
        }

        // GET: Routings/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var routing = await _context.Routing.SingleOrDefaultAsync(m => m.Idrouting == id);
            if (routing == null)
            {
                return NotFound();
            }
            return View(routing);
        }

        // POST: Routings/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Idrouting,Priority,RingingTime,FkContact,FkSite,Active,FkRoutingGroup,HuntBusy,FkAnnouncement,FkIvr,FkMailbox,VoicemailMain")] Routing routing)
        {
            if (id != routing.Idrouting)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(routing);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RoutingExists(routing.Idrouting))
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
            return View(routing);
        }

        // GET: Routings/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var routing = await _context.Routing
                .SingleOrDefaultAsync(m => m.Idrouting == id);
            if (routing == null)
            {
                return NotFound();
            }

            return View(routing);
        }

        // POST: Routings/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var routing = await _context.Routing.SingleOrDefaultAsync(m => m.Idrouting == id);
            _context.Routing.Remove(routing);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RoutingExists(int id)
        {
            return _context.Routing.Any(e => e.Idrouting == id);
        }
    }
}
