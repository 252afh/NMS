using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using NMS.Models;
using NMS.Models.UserProfilesViewModels;

namespace NMS.Controllers
{
    public class UserProfilesController : Controller
    {
        private readonly nmsdbContext _context;

        public UserProfilesController(nmsdbContext context)
        {
            _context = context;
        }

        // GET: UserProfiles
        public async Task<IActionResult> Index()
        {
            return View(await _context.UserProfiles.ToListAsync());
        }

        // GET: UserProfiles/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var userProfiles = await _context.UserProfiles
                .SingleOrDefaultAsync(m => m.Iduser == id);
            if (userProfiles == null)
            {
                return NotFound();
            }

            return View(userProfiles);
        }

        // GET: UserProfiles/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: UserProfiles/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Iduser,Idcustomer,Name,LastName,Active")] UserProfiles userProfiles)
        {
            if (ModelState.IsValid)
            {
                _context.Add(userProfiles);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(userProfiles);
        }

        // GET: UserProfiles/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var userProfiles = await _context.UserProfiles.SingleOrDefaultAsync(m => m.Iduser == id);
            if (userProfiles == null)
            {
                return NotFound();
            }
            return View(userProfiles);
        }

        // POST: UserProfiles/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Iduser,Idcustomer,Name,LastName,Active")] UserProfiles userProfiles)
        {
            if (id != userProfiles.Iduser)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(userProfiles);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UserProfilesExists(userProfiles.Iduser))
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
            return View(userProfiles);
        }

        // GET: UserProfiles/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var userProfiles = await _context.UserProfiles
                .SingleOrDefaultAsync(m => m.Iduser == id);
            if (userProfiles == null)
            {
                return NotFound();
            }

            return View(userProfiles);
        }

        // POST: UserProfiles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var userProfiles = await _context.UserProfiles.SingleOrDefaultAsync(m => m.Iduser == id);
            _context.UserProfiles.Remove(userProfiles);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool UserProfilesExists(int id)
        {
            return _context.UserProfiles.Any(e => e.Iduser == id);
        }
    }
}
