using ESports.Data;
using ESports.Models;
using Microsoft.AspNetCore.Mvc;

namespace ESports.Controllers
{
    public class ReportController : Controller
    {
        private readonly AppDbContext _db;

        public ReportController(AppDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            ReportViewModel reportData = new ReportViewModel();
            reportData.TeamList = _db.Teams.ToList();
            reportData.TrophyList = _db.Trophies.ToList();
            reportData.PlayerList = _db.TrophyRegistrations.ToList().DistinctBy(a => a.PlayerNIC).ToList();
            return View(reportData);
        }
    }
}
