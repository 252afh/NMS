// <copyright file="BarringsController.cs" company="252afh">
//   Copyright © 252afh 2018. All rights reserved.
// </copyright>

namespace NMS.Controllers
{
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.EntityFrameworkCore;
    using Models;
    using Models.BarringViewModels;

    /// <summary>
    /// A controller for <see cref="Barring"/>
    /// </summary>
    public class BarringsController : Controller
    {
        private readonly nmsdbContext context;

        /// <summary>
        /// Initialises a new instance of the <see cref="BarringsController"/> class
        /// </summary>
        /// <param name="context">Database context</param>
        public BarringsController(nmsdbContext context)
        {
            this.context = context;
        }

        /// <summary>
        /// Main page for a <see cref="BarringsController"/>
        /// </summary>
        /// <returns>A list of all <see cref="Barring"/> objects</returns>
        // GET: Barrings
        public async Task<IActionResult> Index()
        {
            return this.View(await this.context.Barring.ToListAsync());
        }

        /// <summary>
        /// Page that displays the details of a <see cref="Barring"/>
        /// </summary>
        /// <param name="id">Id of the <see cref="Barring"/> to display details of</param>
        /// <returns>View containing the <see cref="Barring"/></returns>
        // GET: Barrings/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return this.NotFound();
            }

            var barring = await this.context.Barring
                .SingleOrDefaultAsync(m => m.Idbarring == id);
            if (barring == null)
            {
                return this.NotFound();
            }

            return this.View(barring);
        }

        /// <summary>
        /// A page to create a <see cref="Barring"/> on
        /// </summary>
        /// <returns>Blank create <see cref="Barring"/> page</returns>
        // GET: Barrings/Create
        public IActionResult Create()
        {
            return this.View();
        }

        /// <summary>
        /// Page to create a <see cref="Barring"/> using a <see cref="Barring"/> object
        /// </summary>
        /// <param name="barring"><see cref="Barring"/> to be created</param>
        /// <returns>A view containing the <see cref="Barring"/> to be created</returns>
        // POST: Barrings/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Idbarring,Code,NormalisedCode,Description,Status,FkCustomer")] Barring barring)
        {
            if (this.ModelState.IsValid)
            {
                this.context.Add(barring);
                await this.context.SaveChangesAsync();
                return this.RedirectToAction(nameof(this.Index));
            }

            return this.View(barring);
        }

        /// <summary>
        /// A page to edit a <see cref="Barring"/> on
        /// </summary>
        /// <param name="id">Id of the <see cref="Barring"/> to edit</param>
        /// <returns>A page containing the <see cref="Barring"/> edited</returns>
        // GET: Barrings/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return this.NotFound();
            }

            var barring = await this.context.Barring.SingleOrDefaultAsync(m => m.Idbarring == id);
            if (barring == null)
            {
                return this.NotFound();
            }

            return this.View(barring);
        }

        /// <summary>
        /// A page to edit a <see cref="Barring"/> on using an id and a <see cref="Barring"/> object
        /// </summary>
        /// <param name="id">Id of the <see cref="Barring"/> to edit</param>
        /// <param name="barring"><see cref="Barring"/> object to edit</param>
        /// <returns>a page containing the <see cref="Barring"/> edited</returns>
        // POST: Barrings/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Idbarring,Code,NormalisedCode,Description,Status,FkCustomer")] Barring barring)
        {
            if (id != barring.Idbarring)
            {
                return this.NotFound();
            }

            if (this.ModelState.IsValid)
            {
                try
                {
                    this.context.Update(barring);
                    await this.context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!this.BarringExists(barring.Idbarring))
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

            return this.View(barring);
        }

        /// <summary>
        /// A page to delete a <see cref="Barring"/>
        /// </summary>
        /// <param name="id">Id of a <see cref="Barring"/> to delete</param>
        /// <returns>a page containing the <see cref="Barring"/> deleted</returns>
        // GET: Barrings/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return this.NotFound();
            }

            var barring = await this.context.Barring
                .SingleOrDefaultAsync(m => m.Idbarring == id);
            if (barring == null)
            {
                return this.NotFound();
            }

            return this.View(barring);
        }

        /// <summary>
        /// A page to show confirmation of a deletion of a <see cref="Barring"/> record
        /// </summary>
        /// <param name="id">Id of the <see cref="Barring"/> record deleted</param>
        /// <returns>A redirect to the standard <see cref="Barring"/> page</returns>
        // POST: Barrings/Delete/5
        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var barring = await this.context.Barring.SingleOrDefaultAsync(m => m.Idbarring == id);
            this.context.Barring.Remove(barring);
            await this.context.SaveChangesAsync();
            return this.RedirectToAction(nameof(this.Index));
        }

        /// <summary>
        /// Whether the <see cref="Barring"/> exists
        /// </summary>
        /// <param name="id">Id of the <see cref="Barring"/> to check</param>
        /// <returns>Whether the <see cref="Barring"/> exists</returns>
        private bool BarringExists(int id)
        {
            return this.context.Barring.Any(e => e.Idbarring == id);
        }
    }
}
