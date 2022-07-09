using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using SacramentMeetingPlanner.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace SacramentMeetingPlanner.Controllers;

public class HomeController : Controller
{
    private readonly SacramentMeetingPlannerContext _context;
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger, SacramentMeetingPlannerContext context)
    {
        _logger = logger;
        _context = context;
    }

    public async Task<IActionResult> Index()
    {
        var sacramentMeetingPlannerContext =  _context.SacramentMeetingProgram.Include(s => s.ClosingHymn).Include(s => s.IntermediateHymn).Include(s => s.OpeningHymn).Include(s => s.SacramentHymn);
        
        ViewData["Programs"] = sacramentMeetingPlannerContext.ToListAsync();
        return View(await sacramentMeetingPlannerContext.ToListAsync());
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
