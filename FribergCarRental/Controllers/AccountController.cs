using FribergCarRental.Data;
using FribergCarRental.Models;
using FribergCarRental.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages;

namespace FribergCarRental.Controllers
{
    public class AccountController : Controller
    {
        private readonly IAccount _loginRepository;

        public AccountController(IAccount loginRepository)
        {
            this._loginRepository = loginRepository;
        }

        public ActionResult Create()
        {
            return View();
        }

        public ActionResult ForgotPassword()
        {
            return View();
        }

        public ActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Index", "Home");
        }

        public ActionResult Success()
        {
            ViewBag.UserName = HttpContext.Session.GetString("UserName");
            return View();
        }

        // GET: AccountController/Details/5
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(CreateViewModel createVM)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _loginRepository.AddAsync(createVM);
                    return RedirectToAction("Success", "Account");
                }
            }
            catch
            {

                return View();
            }
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel loginVM)
        {
            if (!ModelState.IsValid)
            {
                return View(loginVM);
            }

            bool isEmail = loginVM.Login.Contains("@");

            User user = isEmail
                ? await _loginRepository.GetUserByEmailAsync(loginVM.Login)
                : await _loginRepository.GetUserByUsernameAsync(loginVM.Login);

            if (user == null || loginVM.Password != user.Password)
            {
                ModelState.AddModelError("", "Invalid login credentials.");
                return View(loginVM);
            }

            HttpContext.Session.SetInt32("UserId", user.Id);
            HttpContext.Session.SetString("UserName", user.UserName);


            // Set up authentication (add cookies/session management here)
            return RedirectToAction("Success", "Account");
        }
        [HttpPost]
        public async Task<IActionResult> ForgotPassword(ForgotPasswordViewModel forgotPasswordVM)
        {
            if (!ModelState.IsValid)
            {
            }

            bool isEmail = forgotPasswordVM.User.Contains("@");

            User user = isEmail
                ? await _loginRepository.GetUserByEmailAsync(forgotPasswordVM.User)
                : await _loginRepository.GetUserByUsernameAsync(forgotPasswordVM.User);

            if (user == null)
            {
                ModelState.AddModelError("", "Invalid login credentials.");
                return View(forgotPasswordVM);
            }

            ViewBag.ShowPassword = user.Password;
            return RedirectToAction("ForgotPassword", "Account");
        }

    }
}
