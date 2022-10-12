using ESports.Data;
using ESports.Models;
using Microsoft.AspNetCore.Mvc;

namespace ESports.Controllers
{
    public class RegistrationController : Controller
    {
        private readonly AppDbContext _db;
        public RegistrationController(AppDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Enroll(string tid)
        {
            EnrollViewModel enrollModel = new EnrollViewModel();

            TrophyRegistration trophyregistration = new TrophyRegistration();
            Trophy trophy = new Trophy();

            trophyregistration.TrophyID = int.Parse(tid);

            int trophyid = int.Parse(tid);
            trophy.Id = trophyid;
            var getTrophy = _db.Trophies.Find(trophyid);
            if (getTrophy != null)
            {
                trophy.Name = getTrophy.Name;
            }
            else
            {
                trophy.Name = "N/A";
            }

            enrollModel.TrophyRegistration = trophyregistration;
            enrollModel.Trophy = trophy;

            return View(enrollModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Enroll(EnrollViewModel enrollData)
        {
            var recordExists = _db.TrophyRegistrations.Find(enrollData.TrophyRegistration.TrophyID, enrollData.TrophyRegistration.PlayerNIC);
            if (recordExists == null)
            {
                _db.TrophyRegistrations.Add(enrollData.TrophyRegistration);
            }
            else
            {
                return RedirectToAction("Index", "Trophy");
            }
            //enrollData.TrophyRegistration.Player = enrollData.Player;
            
            _db.TrophyRegistrations.Add(enrollData.TrophyRegistration);
            _db.SaveChanges();
            return RedirectToAction("Index","Trophy");
        }
    }
}
