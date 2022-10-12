using ESports.Data;
using ESports.Models;
using Microsoft.AspNetCore.Mvc;

namespace ESports.Controllers
{
    public class TrophyController : Controller
    {

        private readonly AppDbContext _db;
        public TrophyController(AppDbContext db)
        {
            _db = db;
        }

        // this will display list of all Tropies
        public IActionResult Index()
        {
            IEnumerable<Trophy> objCategoryList = _db.Trophies;
            return View(objCategoryList);
        }

        // to direct to create a new Trophy page
        public IActionResult Create()
        {
            return View();
        }

        // POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Trophy obj)
        {
            if (ModelState.IsValid)
            {
                _db.Trophies.Add(obj);
                _db.SaveChanges();

                return RedirectToAction("Index");
            }
            return View(obj);
        }

        // GET
        public IActionResult Edit(int? id)
        {
            return View();
        }

        public IActionResult Details(int tid)
        {
            var trophy = _db.Trophies.Find(tid);
            if (trophy != null)
            {
                var playerList = _db.TrophyRegistrations.Where(a => a.TrophyID == trophy.Id).ToList();
                TrophyDetailsViewModel trophyDetails = new TrophyDetailsViewModel();
                trophyDetails.trophy = trophy;
                trophyDetails.registrations = playerList;



                return View(trophyDetails);
            }
            else
            {
                return RedirectToAction("Index", "Trophy");
            }
        }
    }
}
