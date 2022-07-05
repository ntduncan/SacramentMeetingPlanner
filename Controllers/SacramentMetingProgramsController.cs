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
    public class SacramentMetingProgramsController : Controller
    {
        private readonly SacramentMeetingPlannerContext _context;

        public SacramentMetingProgramsController(SacramentMeetingPlannerContext context)
        {
            _context = context;
        }

        // GET: SacramentMetingPrograms
        public async Task<IActionResult> Index()
        {
            var sacramentMeetingPlannerContext = _context.SacramentMeetingProgram.Include(s => s.ClosingHymn).Include(s => s.IntermediateHymn).Include(s => s.OpeningHymn).Include(s => s.SacramentHymn);
            return View(await sacramentMeetingPlannerContext.ToListAsync());
        }

        // GET: SacramentMetingPrograms/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.SacramentMeetingProgram == null)
            {
                return NotFound();
            }

            var sacramentMeetingProgram = await _context.SacramentMeetingProgram
                .Include(s => s.ClosingHymn)
                .Include(s => s.IntermediateHymn)
                .Include(s => s.OpeningHymn)
                .Include(s => s.SacramentHymn)
                .FirstOrDefaultAsync(m => m.SacramentMeetingProgramID == id);
            if (sacramentMeetingProgram == null)
            {
                return NotFound();
            }

            return View(sacramentMeetingProgram);
        }

        // GET: SacramentMetingPrograms/Create
        public IActionResult Create()
        {
            ViewData["ClosingHymnID"] = new SelectList(_context.Set<Hymn>(), "HymnID", "HymnID");
            ViewData["IntermediateHymnID"] = new SelectList(_context.Set<Hymn>(), "HymnID", "HymnID");
            ViewData["OpeningHymnID"] = new SelectList(_context.Set<Hymn>(), "HymnID", "HymnID");
            ViewData["SacramentHymnID"] = new SelectList(_context.Set<Hymn>(), "HymnID", "HymnID");
            return View();
        }

        // POST: SacramentMetingPrograms/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("SacramentMeetingProgramID,Date,ConductingLeader,OpeningPrayer,ClosingPrayer,OpeningHymnID,ClosingHymnID,SacramentHymnID,IntermediateHymnID")] SacramentMeetingProgram sacramentMeetingProgram)
        {
            if (ModelState.IsValid)
            {
                _context.Add(sacramentMeetingProgram);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ClosingHymnID"] = new SelectList(_context.Set<Hymn>(), "HymnID", "HymnID", sacramentMeetingProgram.ClosingHymnID);
            ViewData["IntermediateHymnID"] = new SelectList(_context.Set<Hymn>(), "HymnID", "HymnID", sacramentMeetingProgram.IntermediateHymnID);
            ViewData["OpeningHymnID"] = new SelectList(_context.Set<Hymn>(), "HymnID", "HymnID", sacramentMeetingProgram.OpeningHymnID);
            ViewData["SacramentHymnID"] = new SelectList(_context.Set<Hymn>(), "HymnID", "HymnID", sacramentMeetingProgram.SacramentHymnID);
            return View(sacramentMeetingProgram);
        }

        // GET: SacramentMetingPrograms/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.SacramentMeetingProgram == null)
            {
                return NotFound();
            }

            var sacramentMeetingProgram = await _context.SacramentMeetingProgram.FindAsync(id);
            if (sacramentMeetingProgram == null)
            {
                return NotFound();
            }
            ViewData["ClosingHymnID"] = new SelectList(_context.Set<Hymn>(), "HymnID", "HymnID", sacramentMeetingProgram.ClosingHymnID);
            ViewData["IntermediateHymnID"] = new SelectList(_context.Set<Hymn>(), "HymnID", "HymnID", sacramentMeetingProgram.IntermediateHymnID);
            ViewData["OpeningHymnID"] = new SelectList(_context.Set<Hymn>(), "HymnID", "HymnID", sacramentMeetingProgram.OpeningHymnID);
            ViewData["SacramentHymnID"] = new SelectList(_context.Set<Hymn>(), "HymnID", "HymnID", sacramentMeetingProgram.SacramentHymnID);
            return View(sacramentMeetingProgram);
        }

        // POST: SacramentMetingPrograms/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("SacramentMeetingProgramID,Date,ConductingLeader,OpeningPrayer,ClosingPrayer,OpeningHymnID,ClosingHymnID,SacramentHymnID,IntermediateHymnID")] SacramentMeetingProgram sacramentMeetingProgram)
        {
            if (id != sacramentMeetingProgram.SacramentMeetingProgramID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(sacramentMeetingProgram);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SacramentMeetingProgramExists(sacramentMeetingProgram.SacramentMeetingProgramID))
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
            ViewData["ClosingHymnID"] = new SelectList(_context.Set<Hymn>(), "HymnID", "HymnID", sacramentMeetingProgram.ClosingHymnID);
            ViewData["IntermediateHymnID"] = new SelectList(_context.Set<Hymn>(), "HymnID", "HymnID", sacramentMeetingProgram.IntermediateHymnID);
            ViewData["OpeningHymnID"] = new SelectList(_context.Set<Hymn>(), "HymnID", "HymnID", sacramentMeetingProgram.OpeningHymnID);
            ViewData["SacramentHymnID"] = new SelectList(_context.Set<Hymn>(), "HymnID", "HymnID", sacramentMeetingProgram.SacramentHymnID);
            return View(sacramentMeetingProgram);
        }

        // GET: SacramentMetingPrograms/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.SacramentMeetingProgram == null)
            {
                return NotFound();
            }

            var sacramentMeetingProgram = await _context.SacramentMeetingProgram
                .Include(s => s.ClosingHymn)
                .Include(s => s.IntermediateHymn)
                .Include(s => s.OpeningHymn)
                .Include(s => s.SacramentHymn)
                .FirstOrDefaultAsync(m => m.SacramentMeetingProgramID == id);
            if (sacramentMeetingProgram == null)
            {
                return NotFound();
            }

            return View(sacramentMeetingProgram);
        }

        // POST: SacramentMetingPrograms/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.SacramentMeetingProgram == null)
            {
                return Problem("Entity set 'SacramentMeetingPlannerContext.SacramentMeetingProgram'  is null.");
            }
            var sacramentMeetingProgram = await _context.SacramentMeetingProgram.FindAsync(id);
            if (sacramentMeetingProgram != null)
            {
                _context.SacramentMeetingProgram.Remove(sacramentMeetingProgram);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SacramentMeetingProgramExists(int id)
        {
          return (_context.SacramentMeetingProgram?.Any(e => e.SacramentMeetingProgramID == id)).GetValueOrDefault();
        }
    }
}
