// <copyright file="MailboxesController.cs" company="252afh">
//   Copyright © 252afh 2018. All rights reserved.
// </copyright>

namespace NMS.Controllers
{
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.EntityFrameworkCore;
    using NMS.Models;
    using NMS.Models.MailboxViewModels;

    public class MailboxesController : Controller
    {
        private readonly nmsdbContext context;

        public MailboxesController(nmsdbContext context)
        {
            this.context = context;
        }

        // GET: Mailboxes
        public async Task<IActionResult> Index()
        {
            return this.View(await this.context.Mailbox.ToListAsync());
        }

        // GET: Mailboxes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return this.NotFound();
            }

            var mailbox = await this.context.Mailbox
                .SingleOrDefaultAsync(m => m.Idmailbox == id);
            if (mailbox == null)
            {
                return this.NotFound();
            }

            return this.View(mailbox);
        }

        // GET: Mailboxes/Create
        public IActionResult Create()
        {
            return this.View();
        }

        // POST: Mailboxes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Idmailbox,Pin,Name,Email,SendEmail,DeleteOpt,Attachment,Audiomessage,Audioname,Audiosize,FkNumber,FkCustomer,Fax")] Mailbox mailbox)
        {
            if (this.ModelState.IsValid)
            {
                this.context.Add(mailbox);
                await this.context.SaveChangesAsync();
                return this.RedirectToAction(nameof(this.Index));
            }

            return this.View(mailbox);
        }

        // GET: Mailboxes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return this.NotFound();
            }

            var mailbox = await this.context.Mailbox.SingleOrDefaultAsync(m => m.Idmailbox == id);
            if (mailbox == null)
            {
                return this.NotFound();
            }

            return this.View(mailbox);
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
                return this.NotFound();
            }

            if (this.ModelState.IsValid)
            {
                try
                {
                    this.context.Update(mailbox);
                    await this.context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!this.MailboxExists(mailbox.Idmailbox))
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

            return this.View(mailbox);
        }

        // GET: Mailboxes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return this.NotFound();
            }

            var mailbox = await this.context.Mailbox
                .SingleOrDefaultAsync(m => m.Idmailbox == id);
            if (mailbox == null)
            {
                return this.NotFound();
            }

            return this.View(mailbox);
        }

        // POST: Mailboxes/Delete/5
        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var mailbox = await this.context.Mailbox.SingleOrDefaultAsync(m => m.Idmailbox == id);
            this.context.Mailbox.Remove(mailbox);
            await this.context.SaveChangesAsync();
            return this.RedirectToAction(nameof(this.Index));
        }

        private bool MailboxExists(int id)
        {
            return this.context.Mailbox.Any(e => e.Idmailbox == id);
        }
    }
}
