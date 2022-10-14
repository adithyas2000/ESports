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

        public UserAuthenticationController(IUserAuthenticationService _service)
        {
            this._service = _service;
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

            TempData["msg"] = result.Message;
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