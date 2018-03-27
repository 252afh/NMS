// <copyright file="VoicemessagesController.cs" company="252afh">
//   Copyright © 252afh 2018. All rights reserved.
// </copyright>

namespace NMS.Controllers
{
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.EntityFrameworkCore;
    using NMS.Models;
    using NMS.Models.VoiceMessagesViewModels;

    public class VoicemessagesController : Controller
    {
        private readonly NmsdbContext context;

        public VoicemessagesController(NmsdbContext context)
        {
            this.context = context;
        }

        // GET: Voicemessages
        public async Task<IActionResult> Index()
        {
            return this.View(await this.context.Voicemessages.ToListAsync());
        }

        // GET: Voicemessages/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return this.NotFound();
            }

            var voicemessages = await this.context.Voicemessages
                .SingleOrDefaultAsync(m => m.Id == id);
            if (voicemessages == null)
            {
                return this.NotFound();
            }

            return this.View(voicemessages);
        }

        // GET: Voicemessages/Create
        public IActionResult Create()
        {
            return this.View();
        }

        // POST: Voicemessages/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Msgnum,Dir,Context,Macrocontext,Callerid,Origtime,Duration,Flag,Mailboxuser,Mailboxcontext,MsgId,Recording")] Voicemessages voicemessages)
        {
            if (this.ModelState.IsValid)
            {
                this.context.Add(voicemessages);
                await this.context.SaveChangesAsync();
                return this.RedirectToAction(nameof(this.Index));
            }

            return this.View(voicemessages);
        }

        // GET: Voicemessages/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return this.NotFound();
            }

            var voicemessages = await this.context.Voicemessages.SingleOrDefaultAsync(m => m.Id == id);
            if (voicemessages == null)
            {
                return this.NotFound();
            }

            return this.View(voicemessages);
        }

        // POST: Voicemessages/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Msgnum,Dir,Context,Macrocontext,Callerid,Origtime,Duration,Flag,Mailboxuser,Mailboxcontext,MsgId,Recording")] Voicemessages voicemessages)
        {
            if (id != voicemessages.Id)
            {
                return this.NotFound();
            }

            if (this.ModelState.IsValid)
            {
                try
                {
                    this.context.Update(voicemessages);
                    await this.context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!this.VoicemessagesExists(voicemessages.Id))
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

            return this.View(voicemessages);
        }

        // GET: Voicemessages/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return this.NotFound();
            }

            var voicemessages = await this.context.Voicemessages
                .SingleOrDefaultAsync(m => m.Id == id);
            if (voicemessages == null)
            {
                return this.NotFound();
            }

            return this.View(voicemessages);
        }

        // POST: Voicemessages/Delete/5
        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var voicemessages = await this.context.Voicemessages.SingleOrDefaultAsync(m => m.Id == id);
            this.context.Voicemessages.Remove(voicemessages);
            await this.context.SaveChangesAsync();
            return this.RedirectToAction(nameof(this.Index));
        }

        private bool VoicemessagesExists(int id)
        {
            return this.context.Voicemessages.Any(e => e.Id == id);
        }
    }
}
