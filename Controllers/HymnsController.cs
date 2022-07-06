using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SacramentMeetingPlanner.Models;

namespace SacramentMeetingPlanner.Controllers
{
    public class HymnsController : Controller
    {
        private readonly SacramentMeetingPlannerContext _context;

        public HymnsController(SacramentMeetingPlannerContext context)
        {
            _context = context;
        }

        // GET: Hymns
        public async Task<IActionResult> Index()
        {
              return _context.Hymn != null ? 
                          View(await _context.Hymn.ToListAsync()) :
                          Problem("Entity set 'SacramentMeetingPlannerContext.Hymn'  is null.");
        }

        // GET: Hymns/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Hymn == null)
            {
                return NotFound();
            }

            var hymn = await _context.Hymn
                .FirstOrDefaultAsync(m => m.HymnID == id);
            if (hymn == null)
            {
                return NotFound();
            }

            return View(hymn);
        }

        // GET: Hymns/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Hymns/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("HymnID,HymnNumber,HymnTitle,HymnType")] Hymn hymn)
        {
            if (ModelState.IsValid)
            {
                _context.Add(hymn);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(hymn);
        }

        // GET: Hymns/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Hymn == null)
            {
                return NotFound();
            }

            var hymn = await _context.Hymn.FindAsync(id);
            if (hymn == null)
            {
                return NotFound();
            }
            return View(hymn);
        }

        // POST: Hymns/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("HymnID,HymnNumber,HymnTitle,HymnType")] Hymn hymn)
        {
            if (id != hymn.HymnID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(hymn);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!HymnExists(hymn.HymnID))
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
            return View(hymn);
        }

        // GET: Hymns/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Hymn == null)
            {
                return NotFound();
            }

            var hymn = await _context.Hymn
                .FirstOrDefaultAsync(m => m.HymnID == id);
            if (hymn == null)
            {
                return NotFound();
            }

            return View(hymn);
        }

        // POST: Hymns/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Hymn == null)
            {
                return Problem("Entity set 'SacramentMeetingPlannerContext.Hymn'  is null.");
            }
            var hymn = await _context.Hymn.FindAsync(id);
            if (hymn != null)
            {
                _context.Hymn.Remove(hymn);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool HymnExists(int id)
        {
          return (_context.Hymn?.Any(e => e.HymnID == id)).GetValueOrDefault();
        }
    }
}
