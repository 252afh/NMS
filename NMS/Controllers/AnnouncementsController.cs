// <copyright file="AnnouncementsController.cs" company="252afh">
//   Copyright © 252afh 2018. All rights reserved.
// </copyright>

namespace NMS.Controllers
{
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.EntityFrameworkCore;
    using Models;
    using Models.AnnouncementViewModels;

    /// <summary>
    /// A controller for <see cref="Announcement"/>s
    /// </summary>
    public class AnnouncementsController : Controller
    {
        private readonly NmsdbContext context;

        /// <summary>
        /// Initialises a new instance of the <see cref="AnnouncementsController"/> class
        /// </summary>
        /// <param name="context">Datatbase context</param>
        public AnnouncementsController(NmsdbContext context)
        {
            this.context = context;
        }

        /// <summary>
        /// Controller for the index of announcements
        /// </summary>
        /// <returns>The view of announcements</returns>
        // GET: Announcements
        public async Task<IActionResult> Index()
        {
            return this.View(await this.context.Announcement.ToListAsync());
        }

        /// <summary>
        /// Controller for the details page for <see cref="Announcement"/>
        /// </summary>
        /// <param name="id">Id of the <see cref="Announcement"/></param>
        /// <returns>The view for <see cref="Announcement"/></returns>
        // GET: Announcements/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return this.NotFound();
            }

            var announcement = await this.context.Announcement
                .SingleOrDefaultAsync(m => m.Idannouncement == id);
            if (announcement == null)
            {
                return this.NotFound();
            }

            return this.View(announcement);
        }

        /// <summary>
        /// The page for creating an <see cref="Announcement"/>
        /// </summary>
        /// <returns>The page for creating <see cref="Announcement"/>s</returns>
        // GET: Announcements/Create
        public IActionResult Create()
        {
            return this.View();
        }

        /// <summary>
        /// Page for creating an <see cref="Announcement"/> with an <see cref="Announcement"/> object
        /// </summary>
        /// <param name="announcement"><see cref="Announcement"/> to be created</param>
        /// <returns>The page with an <see cref="Announcement"/> to be created</returns>
        // POST: Announcements/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Idannouncement,Name,Description,Audiomessage,Audioname,Audiosize,Repeattimes,FkCustomer,FkContact,InProgress")] Announcement announcement)
        {
            if (this.ModelState.IsValid)
            {
                this.context.Add(announcement);
                await this.context.SaveChangesAsync();
                return this.RedirectToAction(nameof(this.Index));
            }

            return this.View(announcement);
        }

        /// <summary>
        /// The page for editing an <see cref="Announcement"/> with an id
        /// </summary>
        /// <param name="id">Id of the <see cref="Announcement"/> to edit</param>
        /// <returns>A view of the <see cref="Announcement"/> updated</returns>
        // GET: Announcements/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return this.NotFound();
            }

            var announcement = await this.context.Announcement.SingleOrDefaultAsync(m => m.Idannouncement == id);
            if (announcement == null)
            {
                return this.NotFound();
            }

            return this.View(announcement);
        }

        /// <summary>
        /// The page to edit an <see cref="Announcement"/> with an id and an <see cref="Announcement"/>
        /// </summary>
        /// <param name="id">Id of the <see cref="Announcement"/> to edit</param>
        /// <param name="announcement"><see cref="Announcement"/> object to be edited</param>
        /// <returns>A view of the <see cref="Announcement"/> edited</returns>
        // POST: Announcements/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Idannouncement,Name,Description,Audiomessage,Audioname,Audiosize,Repeattimes,FkCustomer,FkContact,InProgress")] Announcement announcement)
        {
            if (id != announcement.Idannouncement)
            {
                return this.NotFound();
            }

            if (this.ModelState.IsValid)
            {
                try
                {
                    this.context.Update(announcement);
                    await this.context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!this.AnnouncementExists(announcement.Idannouncement))
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

            return this.View(announcement);
        }

        /// <summary>
        /// Page to delete <see cref="Announcement"/>s on
        /// </summary>
        /// <param name="id">Id of the <see cref="Announcement"/> to delete</param>
        /// <returns>A view of the deleted <see cref="Announcement"/></returns>
        // GET: Announcements/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return this.NotFound();
            }

            var announcement = await this.context.Announcement
                .SingleOrDefaultAsync(m => m.Idannouncement == id);
            if (announcement == null)
            {
                return this.NotFound();
            }

            return this.View(announcement);
        }

        /// <summary>
        /// Page to confirm a deletion of a <see cref="Announcement"/>
        /// </summary>
        /// <param name="id">Id of the <see cref="Announcement"/> that has been deleted</param>
        /// <returns>A redirect to the default <see cref="Announcement"/> page</returns>
        // POST: Announcements/Delete/5
        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var announcement = await this.context.Announcement.SingleOrDefaultAsync(m => m.Idannouncement == id);
            this.context.Announcement.Remove(announcement);
            await this.context.SaveChangesAsync();
            return this.RedirectToAction(nameof(this.Index));
        }

        /// <summary>
        /// Checks whether the <see cref="Announcement"/> exists
        /// </summary>
        /// <param name="id">Id of the <see cref="Announcement"/> to check</param>
        /// <returns>Whether the <see cref="Announcement"/> exists</returns>
        private bool AnnouncementExists(int id)
        {
            return this.context.Announcement.Any(e => e.Idannouncement == id);
        }
    }
}
