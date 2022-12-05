using Medical.data.EF;
using Medical.data.EF.Models;
using MedicalWeb.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using MedicalWeb.Extensions;

namespace MedicalWeb.Controllers
{
    public class UserController : Controller
    {
        private EfUnitOfWork _unitOfWork;

        public UserController(EfUnitOfWork context)
        {
            _unitOfWork = context;
            DatabaseInitialize();
        }

        private void DatabaseInitialize()
        {
            if (!_unitOfWork.Roles.Any())
            {
                string adminRoleName = "admin";
                string userRoleName = "user";

                string adminLogin = "Admin";
                string adminPassword = "qwe";

                string userLogin = "User";
                string userPassword = "qwe";

                RoleDbModel adminRole = new RoleDbModel { Name = adminRoleName };
                RoleDbModel userRole = new RoleDbModel { Name = userRoleName };

                _unitOfWork.Roles.Add(userRole);
                _unitOfWork.Roles.Add(adminRole);

                _unitOfWork.Users.Add(new UserDbModel { Login = adminLogin, Password = adminPassword, Role = adminRole });
                _unitOfWork.Users.Add(new UserDbModel { Login = userLogin, Password = userPassword, Role = userRole });

                _unitOfWork.SaveChanges();
            }
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(UserLoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                UserDbModel user = await _unitOfWork
                    .Users
                    .Include(u => u.Role)
                    .FirstOrDefaultAsync(u => u.Login == model.Login && u.Password == model.Password);

                if (user != null)
                {
                    await Authenticate(user);

                    return RedirectToAction("Index", "Home");
                }
                ModelState.AddModelError("", "Некорректные логин и(или) пароль");
            }
            return View(model);
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(UserRegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                UserDbModel user = await _unitOfWork.Users.FirstOrDefaultAsync(u => u.Login == model.Login);
                if (user == null)
                {
                    user = new UserDbModel { Login = model.Login, Password = model.Password };
                    RoleDbModel userRole = await _unitOfWork.Roles.FirstOrDefaultAsync(r => r.Name == "user");
                    if (userRole != null)
                        user.Role = userRole;

                    _unitOfWork.Users.Add(user);
                    await _unitOfWork.SaveChangesAsync();

                    await Authenticate(user);

                    return RedirectToAction("Index", "Home");
                }
                else ModelState.AddModelError("", "Некорректные логин и(или) пароль");
            }
            return View(model);
        }

        private async Task Authenticate(UserDbModel user)
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimsIdentity.DefaultNameClaimType, user.Login),
                new Claim(ClaimsIdentity.DefaultRoleClaimType, user.Role?.Name)

            };

            ClaimsIdentity id = new ClaimsIdentity(claims, "ApplicationCookie", ClaimsIdentity.DefaultNameClaimType, ClaimsIdentity.DefaultRoleClaimType);

            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(id));
            
        }

        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Login", "User");
        }

        public IActionResult Details(long id)
        {
            var user = _unitOfWork.Users.Include(u => u.Role).FirstOrDefault(x => x.Id == id);
            return View(user.ToViewModel());
        }

        public IActionResult List()
        {
            var users = _unitOfWork
                .Users
                .Include(i => i.Role)
                .OrderByDescending(o => o.Id)
                .Take(10)
                .Select(x => x.ToViewModel())
                .ToList();

            return View(users);
        }

        [HttpGet]
        public IActionResult Edit(long id)
        {
            var user = _unitOfWork.Users.Include(x => x.Role).FirstOrDefault(x => x.Id == id);
            return View(user.ToViewModel());
        }
        [HttpPost]
        public IActionResult Edit(UserViewModel updEmployee)
        {
            var employee = _unitOfWork.Users.Select(x => x.Role).FirstOrDefault(x => x.Id == updEmployee.Id);
            
            _unitOfWork.Entry(employee).CurrentValues.SetValues(updEmployee.ToDbModel());
            _unitOfWork.SaveChanges();
            return RedirectToAction("List","User");
        }

        public IActionResult Create()
        {

            return View(new UserViewModel());
        }
        [HttpPost]
        public IActionResult Create(UserViewModel model)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.Users.Add(model.ToDbModel());
                _unitOfWork.SaveChanges();
                return RedirectToAction("List", "User");
            }
                return View();
        }
    }
}
