using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using NMS.Models;
using NMS.Models.NumberTemplateViewModels;

namespace NMS.Controllers
{
    public class NumberTemplatesController : Controller
    {
        private readonly nmsdbContext _context;

        public NumberTemplatesController(nmsdbContext context)
        {
            _context = context;
        }

        // GET: NumberTemplates
        public async Task<IActionResult> Index()
        {
            return View(await _context.NumberTemplate.ToListAsync());
        }

        // GET: NumberTemplates/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var numberTemplate = await _context.NumberTemplate
                .SingleOrDefaultAsync(m => m.IdnumberTemplate == id);
            if (numberTemplate == null)
            {
                return NotFound();
            }

            return View(numberTemplate);
        }

        // GET: NumberTemplates/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: NumberTemplates/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdnumberTemplate,FkNumber,FkTemplate,Priority,Active,FkRoutingGroup")] NumberTemplate numberTemplate)
        {
            if (ModelState.IsValid)
            {
                _context.Add(numberTemplate);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(numberTemplate);
        }

        // GET: NumberTemplates/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var numberTemplate = await _context.NumberTemplate.SingleOrDefaultAsync(m => m.IdnumberTemplate == id);
            if (numberTemplate == null)
            {
                return NotFound();
            }
            return View(numberTemplate);
        }

        // POST: NumberTemplates/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdnumberTemplate,FkNumber,FkTemplate,Priority,Active,FkRoutingGroup")] NumberTemplate numberTemplate)
        {
            if (id != numberTemplate.IdnumberTemplate)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(numberTemplate);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!NumberTemplateExists(numberTemplate.IdnumberTemplate))
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
            return View(numberTemplate);
        }

        // GET: NumberTemplates/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var numberTemplate = await _context.NumberTemplate
                .SingleOrDefaultAsync(m => m.IdnumberTemplate == id);
            if (numberTemplate == null)
            {
                return NotFound();
            }

            return View(numberTemplate);
        }

        // POST: NumberTemplates/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var numberTemplate = await _context.NumberTemplate.SingleOrDefaultAsync(m => m.IdnumberTemplate == id);
            _context.NumberTemplate.Remove(numberTemplate);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool NumberTemplateExists(int id)
        {
            return _context.NumberTemplate.Any(e => e.IdnumberTemplate == id);
        }
    }
}
