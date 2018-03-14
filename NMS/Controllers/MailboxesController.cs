using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using NMS.Models;
using NMS.Models.MailboxViewModels;

namespace NMS.Controllers
{
    public class MailboxesController : Controller
    {
        private readonly nmsdbContext _context;

        public MailboxesController(nmsdbContext context)
        {
            _context = context;
        }

        // GET: Mailboxes
        public async Task<IActionResult> Index()
        {
            return View(await _context.Mailbox.ToListAsync());
        }

        // GET: Mailboxes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mailbox = await _context.Mailbox
                .SingleOrDefaultAsync(m => m.Idmailbox == id);
            if (mailbox == null)
            {
                return NotFound();
            }

            return View(mailbox);
        }

        // GET: Mailboxes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Mailboxes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Idmailbox,Pin,Name,Email,SendEmail,DeleteOpt,Attachment,Audiomessage,Audioname,Audiosize,FkNumber,FkCustomer,Fax")] Mailbox mailbox)
        {
            if (ModelState.IsValid)
            {
                _context.Add(mailbox);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(mailbox);
        }

        // GET: Mailboxes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mailbox = await _context.Mailbox.SingleOrDefaultAsync(m => m.Idmailbox == id);
            if (mailbox == null)
            {
                return NotFound();
            }
            return View(mailbox);
        }

        // POST: Mailboxes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Idmailbox,Pin,Name,Email,SendEmail,DeleteOpt,Attachment,Audiomessage,Audioname,Audiosize,FkNumber,FkCustomer,Fax")] Mailbox mailbox)
        {
            if (id != mailbox.Idmailbox)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(mailbox);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MailboxExists(mailbox.Idmailbox))
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
            return View(mailbox);
        }

        // GET: Mailboxes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mailbox = await _context.Mailbox
                .SingleOrDefaultAsync(m => m.Idmailbox == id);
            if (mailbox == null)
            {
                return NotFound();
            }

            return View(mailbox);
        }

        // POST: Mailboxes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var mailbox = await _context.Mailbox.SingleOrDefaultAsync(m => m.Idmailbox == id);
            _context.Mailbox.Remove(mailbox);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MailboxExists(int id)
        {
            return _context.Mailbox.Any(e => e.Idmailbox == id);
        }
    }
}
