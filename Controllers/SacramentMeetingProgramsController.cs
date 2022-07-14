using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SacramentMeetingPlanner.Models;
using SacramentMeetingPlanner.Models.ViewModels;

namespace SacramentMeetingPlanner.Controllers
{
    public class SacramentMeetingProgramsController : Controller
    {
        private readonly SacramentMeetingPlannerContext _context;

        public SacramentMeetingProgramsController(SacramentMeetingPlannerContext context)
        {
            _context = context;
        }

        // GET: SacramentMeetingPrograms
        public async Task<IActionResult> Index()
        {
            var sacramentMeetingPlannerContext = _context.SacramentMeetingProgram.Include(s => s.ClosingHymn).Include(s => s.IntermediateHymn).Include(s => s.OpeningHymn).Include(s => s.SacramentHymn);
            return View(await sacramentMeetingPlannerContext.ToListAsync());
        }

        // GET: SacramentMeetingPrograms/Details/5
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

        // GET: SacramentMeetingPrograms/Create
        public IActionResult Create()
        {
            ViewData["ClosingHymnID"] = new SelectList(_context.Set<Hymn>(), "HymnID", "DisplayHymn");
            ViewData["IntermediateHymnID"] = new SelectList(_context.Set<Hymn>(), "HymnID", "DisplayHymn");
            ViewData["OpeningHymnID"] = new SelectList(_context.Set<Hymn>(), "HymnID", "DisplayHymn");
            ViewData["SacramentHymnID"] = new SelectList(_context.Set<Hymn>(), "HymnID", "DisplayHymn");
            return View(new SacramentMeetingPlannerViewModel());
        }

        // POST: SacramentMeetingPrograms/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("speakers,sacramentMeetingProgram")] SacramentMeetingPlannerViewModel sacramentMeetingProgramViewModel)
        {

            if (ModelState.IsValid)
            {
                _context.SacramentMeetingProgram.Add(sacramentMeetingProgramViewModel.SacramentMeetingProgram);
                await _context.SaveChangesAsync();

                foreach (var speaker in sacramentMeetingProgramViewModel.Speakers)
                {
                    speaker.SacramentMeetingProgramID = sacramentMeetingProgramViewModel.SacramentMeetingProgram.SacramentMeetingProgramID;
                    _context.Speaker.Add(sacramentMeetingProgramViewModel.Speakers[0]);

                }
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ClosingHymnID"] = new SelectList(_context.Set<Hymn>(), "HymnID", "HymnID", sacramentMeetingProgramViewModel.SacramentMeetingProgram.ClosingHymnID);
            ViewData["IntermediateHymnID"] = new SelectList(_context.Set<Hymn>(), "HymnID", "HymnID", sacramentMeetingProgramViewModel.SacramentMeetingProgram.IntermediateHymnID);
            ViewData["OpeningHymnID"] = new SelectList(_context.Set<Hymn>(), "HymnID", "HymnID", sacramentMeetingProgramViewModel.SacramentMeetingProgram.OpeningHymnID);
            ViewData["SacramentHymnID"] = new SelectList(_context.Set<Hymn>(), "HymnID", "HymnID", sacramentMeetingProgramViewModel.SacramentMeetingProgram.SacramentHymnID);
            
            return View(sacramentMeetingProgramViewModel);
        }

        // GET: SacramentMeetingPrograms/Edit/5
        public async Task<IActionResult> Edit(int? id)
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
                .Include(s => s.Speakers)
                //.ThenInclude(s => s.Speaker)
                .AsNoTracking()
                .FirstOrDefaultAsync(m => m.SacramentMeetingProgramID == id);

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

        // POST: SacramentMeetingPrograms/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("speakers,sacramentMeetingProgram")] SacramentMeetingPlannerViewModel sacramentMeetingProgramViewModel)
        {
            var sacramentMeetingProgram = sacramentMeetingProgramViewModel.SacramentMeetingProgram;

            if (id != sacramentMeetingProgram.SacramentMeetingProgramID)
            {
                return NotFound();
            }

            if (sacramentMeetingProgram == null)
            {
                return NotFound();
            }

            if(sacramentMeetingProgramViewModel.Speakers != null)
            {
                foreach (var speaker in sacramentMeetingProgramViewModel.Speakers)
                {
                    speaker.SacramentMeetingProgramID = sacramentMeetingProgramViewModel.SacramentMeetingProgram.SacramentMeetingProgramID;
                    _context.Speaker.Add(sacramentMeetingProgramViewModel.Speakers[0]);
                }
            }

            if(sacramentMeetingProgram.OpeningHymnID != null && sacramentMeetingProgram.ClosingHymnID != null && sacramentMeetingProgram.SacramentHymnID != null)
            {
                sacramentMeetingProgram.OpeningHymn = await _context.Hymn.FindAsync(sacramentMeetingProgram.OpeningHymnID);
                sacramentMeetingProgram.ClosingHymn = await _context.Hymn.FindAsync(sacramentMeetingProgram.ClosingHymnID);
                sacramentMeetingProgram.SacramentHymn = await _context.Hymn.FindAsync(sacramentMeetingProgram.SacramentHymnID);
                if(sacramentMeetingProgram.IntermediateHymnID != null) sacramentMeetingProgram.IntermediateHymn = await _context.Hymn.FindAsync(sacramentMeetingProgram.IntermediateHymnID);

            }

            // if (ModelState.IsValid)
            // {
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
            // }

            ViewData["ClosingHymnID"] = new SelectList(_context.Set<Hymn>(), "HymnID", "HymnID", sacramentMeetingProgram.ClosingHymnID);
            ViewData["IntermediateHymnID"] = new SelectList(_context.Set<Hymn>(), "HymnID", "HymnID", sacramentMeetingProgram.IntermediateHymnID);
            ViewData["OpeningHymnID"] = new SelectList(_context.Set<Hymn>(), "HymnID", "HymnID", sacramentMeetingProgram.OpeningHymnID);
            ViewData["SacramentHymnID"] = new SelectList(_context.Set<Hymn>(), "HymnID", "HymnID", sacramentMeetingProgram.SacramentHymnID);
            return View(sacramentMeetingProgram);
        }

        // GET: SacramentMeetingPrograms/Delete/5
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

        // POST: SacramentMeetingPrograms/Delete/5
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
