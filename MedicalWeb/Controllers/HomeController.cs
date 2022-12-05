using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace MedicalWeb.Controllers
{
    public class HomeController : Controller
    {
        [Authorize(Roles = "admin, user")]
        public IActionResult Index ()
        {
            //string role = User.FindFirst(x => x.Type == ClaimsIdentity.DefaultRoleClaimType).Value;
            //return Content($"ваша роль: {role}");
            return View();
        }

        public IActionResult Forbidden()
        {
            return View("Index");
        }
    }
}
