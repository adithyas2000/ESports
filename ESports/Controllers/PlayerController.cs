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
            return View();
        }
        public IActionResult Enroll()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Enroll(Player player,TrophyRegistration trophy)
        {
            _db.Players.Add(player);
            _db.TrophyRegistrations.Add(trophy);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
