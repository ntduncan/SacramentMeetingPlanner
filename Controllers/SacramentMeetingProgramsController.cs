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
                .Include(s => s.Speakers)
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
        public async Task<IActionResult> Create([Bind("Speakers,SacramentMeetingProgram")] SacramentMeetingPlannerViewModel sacramentMeetingProgramViewModel)
        {
            if(sacramentMeetingProgramViewModel.Speakers == null)
            {
                sacramentMeetingProgramViewModel.Speakers = new List<Speaker>();
            }

            if (sacramentMeetingProgramViewModel.SacramentMeetingProgram != null && sacramentMeetingProgramViewModel.Speakers != null)
            {
                _context.SacramentMeetingProgram.Add(sacramentMeetingProgramViewModel.SacramentMeetingProgram);
                await _context.SaveChangesAsync();

                foreach (var speaker in sacramentMeetingProgramViewModel.Speakers)
                {
                    speaker.SacramentMeetingProgramID = sacramentMeetingProgramViewModel.SacramentMeetingProgram.SacramentMeetingProgramID;
                    _context.Speaker.Add(speaker);

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
                .Include(s => s.Speakers)//.ThenInclude(s => s.Speaker)
                .AsNoTracking()
                .FirstOrDefaultAsync(m => m.SacramentMeetingProgramID == id);

                
                List<Speaker> speakers = await _context.Speaker.Where(s => s.SacramentMeetingProgramID == id).ToListAsync();

            if (sacramentMeetingProgram == null)
            {
                return NotFound();
            }

            ViewData["ClosingHymnID"] = new SelectList(_context.Set<Hymn>(), "HymnID", "DisplayHymn", sacramentMeetingProgram.ClosingHymnID);
            ViewData["IntermediateHymnID"] = new SelectList(_context.Set<Hymn>(), "HymnID", "DisplayHymn", sacramentMeetingProgram.IntermediateHymnID);
            ViewData["OpeningHymnID"] = new SelectList(_context.Set<Hymn>(), "HymnID", "DisplayHymn", sacramentMeetingProgram.OpeningHymnID);
            ViewData["SacramentHymnID"] = new SelectList(_context.Set<Hymn>(), "HymnID", "DisplayHymn", sacramentMeetingProgram.SacramentHymnID);
            
            return View(new SacramentMeetingPlannerViewModel()
            {
                SacramentMeetingProgram = sacramentMeetingProgram,
                Speakers = speakers
            });
        }

        // POST: SacramentMeetingPrograms/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Speakers,SacramentMeetingProgram")] SacramentMeetingPlannerViewModel sacramentMeetingProgramViewModel)
        {
            if (id != sacramentMeetingProgramViewModel.SacramentMeetingProgram.SacramentMeetingProgramID)
            {
                return NotFound();
            }


            if(sacramentMeetingProgramViewModel.SacramentMeetingProgram.OpeningHymnID > 0 && sacramentMeetingProgramViewModel.SacramentMeetingProgram.ClosingHymnID > 0 && sacramentMeetingProgramViewModel.SacramentMeetingProgram.SacramentHymnID > 0)
            {
                sacramentMeetingProgramViewModel.SacramentMeetingProgram.OpeningHymn = await _context.Hymn.FindAsync(sacramentMeetingProgramViewModel.SacramentMeetingProgram.OpeningHymnID);
                sacramentMeetingProgramViewModel.SacramentMeetingProgram.ClosingHymn = await _context.Hymn.FindAsync(sacramentMeetingProgramViewModel.SacramentMeetingProgram.ClosingHymnID);
                sacramentMeetingProgramViewModel.SacramentMeetingProgram.SacramentHymn = await _context.Hymn.FindAsync(sacramentMeetingProgramViewModel.SacramentMeetingProgram.SacramentHymnID);
                if(sacramentMeetingProgramViewModel.SacramentMeetingProgram.IntermediateHymnID != null) 
                {
                    sacramentMeetingProgramViewModel.SacramentMeetingProgram.IntermediateHymn = await _context.Hymn.FindAsync(sacramentMeetingProgramViewModel.SacramentMeetingProgram.IntermediateHymnID);
                }

            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(sacramentMeetingProgramViewModel.SacramentMeetingProgram);
                    await _context.SaveChangesAsync();
                    int SacramentMeetingProgramID = sacramentMeetingProgramViewModel.SacramentMeetingProgram.SacramentMeetingProgramID;

                    //Remove previous speakers associated with program
                    var prevSpeakers = _context.Speaker.Where(m => m.SacramentMeetingProgramID == SacramentMeetingProgramID);
                    if (prevSpeakers.Any())
                    {
                        foreach (Speaker prevSpeaker in prevSpeakers)
                        {
                            _context.Speaker.Remove(prevSpeaker);
                        }
                        await _context.SaveChangesAsync();
                    }

                    //Add new ones from page to speakers
                    foreach (var speaker in sacramentMeetingProgramViewModel.Speakers)
                    {
                        speaker.SacramentMeetingProgramID = SacramentMeetingProgramID;
                        _context.Speaker.Add(speaker);;
                    }
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SacramentMeetingProgramExists(sacramentMeetingProgramViewModel.SacramentMeetingProgram.SacramentMeetingProgramID))
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

            // return RedirectToAction(nameof(Index));
            return View(sacramentMeetingProgramViewModel);
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
            Console.WriteLine(SacramentMeetingProgramExists(id));
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
