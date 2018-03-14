// <copyright file="ContactsController.cs" company="252afh">
//   Copyright © 252afh 2018. All rights reserved.
// </copyright>

namespace NMS.Controllers
{
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.EntityFrameworkCore;
    using NMS.Models;
    using NMS.Models.ContactViewModels;

    public class ContactsController : Controller
    {
        private readonly nmsdbContext context;

        public ContactsController(nmsdbContext context)
        {
            this.context = context;
        }

        // GET: Contacts
        public async Task<IActionResult> Index()
        {
            return this.View(await this.context.Contact.ToListAsync());
        }

        // GET: Contacts/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return this.NotFound();
            }

            var contact = await this.context.Contact
                .SingleOrDefaultAsync(m => m.Idcontact == id);
            if (contact == null)
            {
                return this.NotFound();
            }

            return this.View(contact);
        }

        // GET: Contacts/Create
        public IActionResult Create()
        {
            return this.View();
        }

        // POST: Contacts/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Idcontact,Name,Description,PhoneNumber,FkCustomer,FkSite")] Contact contact)
        {
            if (this.ModelState.IsValid)
            {
                this.context.Add(contact);
                await this.context.SaveChangesAsync();
                return this.RedirectToAction(nameof(this.Index));
            }

            return this.View(contact);
        }

        // GET: Contacts/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return this.NotFound();
            }

            var contact = await this.context.Contact.SingleOrDefaultAsync(m => m.Idcontact == id);
            if (contact == null)
            {
                return this.NotFound();
            }

            return this.View(contact);
        }

        // POST: Contacts/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Idcontact,Name,Description,PhoneNumber,FkCustomer,FkSite")] Contact contact)
        {
            if (id != contact.Idcontact)
            {
                return this.NotFound();
            }

            if (this.ModelState.IsValid)
            {
                try
                {
                    this.context.Update(contact);
                    await this.context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!this.ContactExists(contact.Idcontact))
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

            return this.View(contact);
        }

        // GET: Contacts/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return this.NotFound();
            }

            var contact = await this.context.Contact
                .SingleOrDefaultAsync(m => m.Idcontact == id);
            if (contact == null)
            {
                return this.NotFound();
            }

            return this.View(contact);
        }

        // POST: Contacts/Delete/5
        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var contact = await this.context.Contact.SingleOrDefaultAsync(m => m.Idcontact == id);
            this.context.Contact.Remove(contact);
            await this.context.SaveChangesAsync();
            return this.RedirectToAction(nameof(this.Index));
        }

        private bool ContactExists(int id)
        {
            return this.context.Contact.Any(e => e.Idcontact == id);
        }
    }
}
