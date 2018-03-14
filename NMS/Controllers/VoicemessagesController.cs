using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using NMS.Models;
using NMS.Models.VoiceMessagesViewModels;

namespace NMS.Controllers
{
    public class VoicemessagesController : Controller
    {
        private readonly nmsdbContext _context;

        public VoicemessagesController(nmsdbContext context)
        {
            _context = context;
        }

        // GET: Voicemessages
        public async Task<IActionResult> Index()
        {
            return View(await _context.Voicemessages.ToListAsync());
        }

        // GET: Voicemessages/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var voicemessages = await _context.Voicemessages
                .SingleOrDefaultAsync(m => m.Id == id);
            if (voicemessages == null)
            {
                return NotFound();
            }

            return View(voicemessages);
        }

        // GET: Voicemessages/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Voicemessages/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Msgnum,Dir,Context,Macrocontext,Callerid,Origtime,Duration,Flag,Mailboxuser,Mailboxcontext,MsgId,Recording")] Voicemessages voicemessages)
        {
            if (ModelState.IsValid)
            {
                _context.Add(voicemessages);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(voicemessages);
        }

        // GET: Voicemessages/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var voicemessages = await _context.Voicemessages.SingleOrDefaultAsync(m => m.Id == id);
            if (voicemessages == null)
            {
                return NotFound();
            }
            return View(voicemessages);
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
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(voicemessages);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!VoicemessagesExists(voicemessages.Id))
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
            return View(voicemessages);
        }

        // GET: Voicemessages/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var voicemessages = await _context.Voicemessages
                .SingleOrDefaultAsync(m => m.Id == id);
            if (voicemessages == null)
            {
                return NotFound();
            }

            return View(voicemessages);
        }

        // POST: Voicemessages/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var voicemessages = await _context.Voicemessages.SingleOrDefaultAsync(m => m.Id == id);
            _context.Voicemessages.Remove(voicemessages);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool VoicemessagesExists(int id)
        {
            return _context.Voicemessages.Any(e => e.Id == id);
        }
    }
}
