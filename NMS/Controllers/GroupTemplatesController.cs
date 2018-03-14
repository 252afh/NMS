using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using NMS.Models;
using NMS.Models.GroupTemplateViewModels;

namespace NMS.Controllers
{
    public class GroupTemplatesController : Controller
    {
        private readonly nmsdbContext _context;

        public GroupTemplatesController(nmsdbContext context)
        {
            _context = context;
        }

        // GET: GroupTemplates
        public async Task<IActionResult> Index()
        {
            return View(await _context.GroupTemplate.ToListAsync());
        }

        // GET: GroupTemplates/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var groupTemplate = await _context.GroupTemplate
                .SingleOrDefaultAsync(m => m.IdgroupTemplate == id);
            if (groupTemplate == null)
            {
                return NotFound();
            }

            return View(groupTemplate);
        }

        // GET: GroupTemplates/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: GroupTemplates/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdgroupTemplate,FkGroup,FkTemplate,Priority,Active,FkRoutingGroup")] GroupTemplate groupTemplate)
        {
            if (ModelState.IsValid)
            {
                _context.Add(groupTemplate);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(groupTemplate);
        }

        // GET: GroupTemplates/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var groupTemplate = await _context.GroupTemplate.SingleOrDefaultAsync(m => m.IdgroupTemplate == id);
            if (groupTemplate == null)
            {
                return NotFound();
            }
            return View(groupTemplate);
        }

        // POST: GroupTemplates/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdgroupTemplate,FkGroup,FkTemplate,Priority,Active,FkRoutingGroup")] GroupTemplate groupTemplate)
        {
            if (id != groupTemplate.IdgroupTemplate)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(groupTemplate);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!GroupTemplateExists(groupTemplate.IdgroupTemplate))
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
            return View(groupTemplate);
        }

        // GET: GroupTemplates/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var groupTemplate = await _context.GroupTemplate
                .SingleOrDefaultAsync(m => m.IdgroupTemplate == id);
            if (groupTemplate == null)
            {
                return NotFound();
            }

            return View(groupTemplate);
        }

        // POST: GroupTemplates/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var groupTemplate = await _context.GroupTemplate.SingleOrDefaultAsync(m => m.IdgroupTemplate == id);
            _context.GroupTemplate.Remove(groupTemplate);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool GroupTemplateExists(int id)
        {
            return _context.GroupTemplate.Any(e => e.IdgroupTemplate == id);
        }
    }
}
