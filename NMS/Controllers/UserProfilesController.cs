// <copyright file="UserProfilesController.cs" company="252afh">
//   Copyright © 252afh 2018. All rights reserved.
// </copyright>

namespace NMS.Controllers
{
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.EntityFrameworkCore;
    using NMS.Models;
    using NMS.Models.UserProfilesViewModels;

    public class UserProfilesController : Controller
    {
        private readonly NmsdbContext context;

        public UserProfilesController(NmsdbContext context)
        {
            this.context = context;
        }

        // GET: UserProfiles
        public async Task<IActionResult> Index()
        {
            return this.View(await this.context.UserProfiles.ToListAsync());
        }

        // GET: UserProfiles/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return this.NotFound();
            }

            var userProfiles = await this.context.UserProfiles
                .SingleOrDefaultAsync(m => m.Iduser == id);
            if (userProfiles == null)
            {
                return this.NotFound();
            }

            return this.View(userProfiles);
        }

        // GET: UserProfiles/Create
        public IActionResult Create()
        {
            return this.View();
        }

        // POST: UserProfiles/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Iduser,Idcustomer,Name,LastName,Active")] UserProfiles userProfiles)
        {
            if (this.ModelState.IsValid)
            {
                this.context.Add(userProfiles);
                await this.context.SaveChangesAsync();
                return this.RedirectToAction(nameof(this.Index));
            }

            return this.View(userProfiles);
        }

        // GET: UserProfiles/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return this.NotFound();
            }

            var userProfiles = await this.context.UserProfiles.SingleOrDefaultAsync(m => m.Iduser == id);
            if (userProfiles == null)
            {
                return this.NotFound();
            }

            return this.View(userProfiles);
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
                return this.NotFound();
            }

            if (this.ModelState.IsValid)
            {
                try
                {
                    this.context.Update(userProfiles);
                    await this.context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!this.UserProfilesExists(userProfiles.Iduser))
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

            return this.View(userProfiles);
        }

        // GET: UserProfiles/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return this.NotFound();
            }

            var userProfiles = await this.context.UserProfiles
                .SingleOrDefaultAsync(m => m.Iduser == id);
            if (userProfiles == null)
            {
                return this.NotFound();
            }

            return this.View(userProfiles);
        }

        // POST: UserProfiles/Delete/5
        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var userProfiles = await this.context.UserProfiles.SingleOrDefaultAsync(m => m.Iduser == id);
            this.context.UserProfiles.Remove(userProfiles);
            await this.context.SaveChangesAsync();
            return this.RedirectToAction(nameof(this.Index));
        }

        private bool UserProfilesExists(int id)
        {
            return this.context.UserProfiles.Any(e => e.Iduser == id);
        }
    }
}
