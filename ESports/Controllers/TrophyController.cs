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
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var trophyFromDb = _db.Trophies.Find(id);

            if (trophyFromDb == null)
            {
                return NotFound();
            }

            return View(trophyFromDb);
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


        // POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Trophy obj)
        {
            if (ModelState.IsValid)
            {
                _db.Trophies.Update(obj);
                _db.SaveChanges();

                return RedirectToAction("Index");
            }
            return View(obj);
        }

        // GET
        public IActionResult Close(int? id)
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

            return View(trophyFromDb);
        }

        // POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Close(int id)
        {
            var trophyFromDb = _db.Trophies.Find(id);
            if (trophyFromDb == null)
            {
                return NotFound();
            }
        
                trophyFromDb.isClosed = true;
                _db.SaveChanges();

                return RedirectToAction("Index");
           
           
        }

        // GET
        public IActionResult Update(string? id, int? tid)
        {
          IEnumerable<TrophyRegistration> objCategoryList = _db.TrophyRegistrations;
            if (id == null || tid == 0)
            {
                return NotFound();
            }
            var trophyFromDb = _db.TrophyRegistrations.FirstOrDefault(a => a.TrophyID == tid && a.PlayerNIC == id);

            if (trophyFromDb == null)
            {
                return NotFound();
            }

            return View(trophyFromDb);
        }

        // POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult UpdatePOST(TrophyRegistration updatedTrophy)
        {
            //var idN = id;
             var trophyFromDb = _db.TrophyRegistrations.FirstOrDefault(a => a.TrophyID == updatedTrophy.TrophyID && a.PlayerNIC == updatedTrophy.PlayerNIC);
               //var trophyFromDb = _db.TrophyRegistrations.FirstOrDefault(a =>  a.PlayerNIC ==id);
               if (trophyFromDb == null)
               {
                   return NotFound();
               }

               trophyFromDb.BaseFee= updatedTrophy.BaseFee;
               _db.SaveChanges();
            
            return RedirectToAction("Details");


        }

    }
}
