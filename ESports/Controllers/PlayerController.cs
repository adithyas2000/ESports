using ESports.Data;
using ESports.Models;
using Microsoft.AspNetCore.Mvc;

namespace ESports.Controllers
{
    public class PlayerController : Controller
    {
        private readonly AppDbContext _db;
        public PlayerController(AppDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            var playerList = _db.TrophyRegistrations.ToList().DistinctBy(a => a.PlayerNIC).ToList();


            if (playerList != null)
            {
                return View(playerList);

            }
            return RedirectToAction("Index", "Trophy");
        }

        public IActionResult Profile(string nic)
        {
            var player = _db.TrophyRegistrations.Where(a => a.PlayerNIC == nic).ToList();
            List<Trophy> appliedTrophies = new List<Trophy>();

            foreach (var item in player)
            {
                var trophy = _db.Trophies.Find(item.TrophyID);
                if (trophy != null)
                {
                    appliedTrophies.Add(trophy);
                }
            }

            ProfileViewModel profiles = new ProfileViewModel();
            profiles.registrations = player;
            profiles.trophies = appliedTrophies;

            return View(profiles);
        }
    }
}
