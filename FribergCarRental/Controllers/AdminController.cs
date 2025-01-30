using FribergCarRental.Data.Enums;
using FribergCarRental.Data.interfaces;
using FribergCarRental.Models;
using FribergCarRental.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FribergCarRental.Controllers
{
    public class AdminController : Controller
    {
        private readonly IAccountService _accountService;

        public AdminController(IAccountService accountService)
        {
            this._accountService = accountService;
        }
        // GET: AdminController
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult AdminDashboard()
        {
            return View();
        }       

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel loginVM)
        {
            if (!ModelState.IsValid)
            {
                return View("Index");
            }

            bool isEmail = loginVM.Login.Contains("@");

            User user = await _accountService.GetUserByEmailOrUsernameAsync(loginVM.Login, isEmail);

            if (user == null || loginVM.Password != user.Password || user.Role != Role.Admin)
            {
                ModelState.AddModelError("", "Ogiltiga inloggningsuppgifter.");
                return View("Index");
            }

            HttpContext.Session.Clear();
            HttpContext.Session.SetInt32("UserId", user.Id);
            HttpContext.Session.SetString("UserName", user.UserName);
            HttpContext.Session.SetString("UserRole", user.Role.ToString());

            return View("AdminDashboard");
        }
    }
}
