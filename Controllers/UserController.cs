using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using CertificateManagement.Dtos;
using CertificateManagement.Service.Interfaces;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;

namespace CertificateManagement.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService;
        }
        public IActionResult GetAll()
        {
            var users = _userService.GetAll();
            return View(users);
        }
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Login(LoginUserRequestModel model)
        {
            var user = await _userService.Login(model);
            if (user.Status != false)
            {
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.NameIdentifier , user.Data.Id.ToString()),
                    new Claim(ClaimTypes.Email, user.Data.EmailAddress),
                    new Claim(ClaimTypes.Name, user.Data.PhoneNumber),
                    new Claim(ClaimTypes.Name, user.Data.Address),

                };

                var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                var principal = new ClaimsPrincipal(identity);
                var properties = new AuthenticationProperties();

                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal, properties);
                TempData["Success"] = "Successfully LogIn";
                if (user.Status == true)
                {
                    if (user.Data.Roles.Select(r => r.Name).Contains("Organization"))
                        return RedirectToAction("OrganizationBoard", "Organization");

                    else if (user.Data.Roles.Select(r => r.Name).Contains("Admin"))
                        return RedirectToAction("AdminBoard", "Admin");
                }
            }
            ViewBag.error = "Invalid Email or password entered";
            return View();
        }

        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }
    }
}