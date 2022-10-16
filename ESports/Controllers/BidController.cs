using ESports.Data;
using ESports.Models;
using identityRoleBased.Models.Domain;
using Microsoft.AspNetCore.Mvc;

namespace ESports.Controllers
{
    public class BidController : Controller
    {
        private readonly AppDbContext _db;
        private readonly DatabaseContext _userdb;

        public BidController(AppDbContext db, DatabaseContext userdb)
        {
            _db = db;
            _userdb = userdb;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(TrophyDetailsViewModel details)
        {
            var teamold = _db.Teams.FirstOrDefault(a => a.Name == details.team);
            var team = _userdb.Users.FirstOrDefault(a => a.UserName == details.team);
            if (team != null)
            {
                var dbTeam = _db.TrophyTeams.FirstOrDefault(a => a.TeamId == team.Id);
                var spent = 0;
                var max = 0;
                if (dbTeam != null) { spent = dbTeam.SpentAmount; max = dbTeam.MaxPrice; }
                if (spent < max)
                {
                    var teamId = team.Id;
                    PlayersBid bidRecord = new PlayersBid();
                    bidRecord.TeamId = teamId;
                    bidRecord.BidAmount = details.bidValue;
                    bidRecord.TrophyID = details.trophyId;
                    //bidRecord.PlayerId = int.Parse(details.registrations[0].PlayerNIC);
                    bidRecord.PlayerId = int.Parse(details.playerNIC);
                    spent += dbTeam.SpentAmount;
                    if (dbTeam != null) { dbTeam.SpentAmount = spent; _db.TrophyTeams.Add(dbTeam); }
                    
                    _db.PlayersBids.Add(bidRecord);
                    try { 
                        _db.SaveChanges();
                    }catch(Exception e)
                    {
                        return StatusCode(400, e.ToString());
                    }


                }


                return RedirectToAction("Index", "Trophy");
            }
            else
            {
                return Content(details.team);
            }

        }
    }
}
