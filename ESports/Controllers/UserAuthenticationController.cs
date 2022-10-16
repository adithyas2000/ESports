using ESports.Data;
using ESports.Models;
using identityRoleBased.Models;
using identityRoleBased.Models.DTO;
using identityRoleBased.Repositories.Abstract;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace identityRoleBased.Controllers
{
    public class UserAuthenticationController : Controller
    {
        private readonly IUserAuthenticationService _service;
        private readonly AppDbContext _db;

        public UserAuthenticationController(IUserAuthenticationService _service, AppDbContext db)
        {
            this._service = _service;
            this._db = db;
        }



        public IActionResult Registration()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Registration(RegistrationModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            model.Role = "user";
            var result = await _service.RegistrationAsync(model);

            if (result.StatusCode == 0)
            {
                TempData["msg"] = result.Message;
                return View(model);
            }
            var t = new Team
            {
                Id = result.UserId,
                Name = model.Name,
            };

            _db.Teams.Add(t);
            _db.SaveChanges();

            return RedirectToAction(nameof(Login));
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var result = await _service.LoginAsync(model);

            if (result.StatusCode == 1)
            {
                var userid = result.UserId;
                return RedirectToAction("Index", "Home");
            }
            else
            {

                TempData["msg"] = result.Message;
                return RedirectToAction(nameof(Login));
            }
        }

        [Authorize]
        public async Task<IActionResult> Logout()
        {
            await _service.LogoutAsync();
            return RedirectToAction("Index", "Home");
        }

        //run this to create admin
        public async Task<IActionResult> Reg()
        {
            var model = new RegistrationModel
            {
                Name = "admin",
                Email = "admin@gmail.com",
                Password = "qwerty277J*",
                ConfirmPassword = "qwerty277J*",
                UserName = "admin",
            };
            model.Role = "admin";
            var result = await _service.RegistrationAsync(model);

            TempData["msg"] = result.Message;
            return Ok(result);
        }
    }
}