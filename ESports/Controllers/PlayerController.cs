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
            var playerList = _db.TrophyRegistrations.Where(a=>a.CurrentTeam=="NULL").ToList();
            if (playerList != null)
            {
                return View(playerList);

            }
            return RedirectToAction("Index","Trophy");
        }

        public IActionResult Profile(string nic)
        {
            var player = _db.TrophyRegistrations.Where(a => a.PlayerNIC == nic).ToList();
            return View(player[0]);
        }
    }
}
