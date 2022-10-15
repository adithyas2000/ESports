using ESports.Data;
using ESports.Models;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace ESports.Controllers
{
    public class TeamController : Controller
    {
        private readonly AppDbContext _db;

        public TeamController(AppDbContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            var userid = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var teams = _db.TrophyTeams.Where(a => a.TeamId == userid).ToList();

            var listOfTrophies = new List<Trophy>();

            foreach(var team in teams)
            {
                var trophyData = _db.Trophies.First(a => a.Id == team.TrophyID);
                listOfTrophies.Add(trophyData);
            }

            TrophyTeamTrophyListViewModel addTrophyTeam = new TrophyTeamTrophyListViewModel();
            addTrophyTeam.trophy = listOfTrophies;
            addTrophyTeam.trophyTeam = teams;

            return View(addTrophyTeam);
        }

        
    }
}
