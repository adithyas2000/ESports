using ESports.Data;
using ESports.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Security.Claims;

namespace ESports.Controllers
{
    public class TrophyTeamController : Controller
    {
        private readonly AppDbContext _db;
   

        public TrophyTeamController(AppDbContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            var userid = User.FindFirstValue(ClaimTypes.NameIdentifier);

            return View();
        }
        public IActionResult Add(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var trophyFromDb = _db.Trophies.Find(id);
            
           

            if (trophyFromDb == null)
            {
              
                return NotFound();
            }
            List<SelectListItem> teamsList = new List<SelectListItem>();

            var teamsFromDb = _db.Teams;
            teamsList.Add(new SelectListItem
            {
                Text = "Select The Team",
                Value = ""
            });

            foreach(var team in teamsFromDb)
            {
                teamsList.Add(new SelectListItem
                {
                    Text = team.Name,
                    Value = team.Id
                });
            }
            ViewBag.Teams = teamsList;

            AddTrophyTeamViewModel addTrophyTeam = new AddTrophyTeamViewModel();
            addTrophyTeam.trophy = trophyFromDb;
            addTrophyTeam.teams = teamsList;

            return View(addTrophyTeam);
        }

        // POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Add(AddTrophyTeamViewModel obj)
        {
            var dobj = obj;
            if (ModelState.IsValid)
            {
                var team = new TrophyTeam()
                {
                    TeamId = obj.trophyTeam.TeamId,
                    TrophyID = obj.trophy.Id,
                    MaxPrice = obj.trophyTeam.MaxPrice,

                };
              
                _db.TrophyTeams.Add(team);
                _db.SaveChanges();

                return RedirectToAction("Index", "Trophy");

            }
               
            return View();
        }
    }
}
