using FribergCarRental.Data;
using FribergCarRental.Models;
using FribergCarRental.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages;

namespace FribergCarRental.Controllers
{
    public class LoginController : Controller
    {
        private readonly ILogin _loginRepository;

        public LoginController(ILogin loginRepository)
        {
            this._loginRepository = loginRepository;
        }
        // GET: LoginController
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Create()
        {
            return View();
        }

        public ActionResult Success()
        {
            return View();
        }

        // GET: LoginController/Details/5
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(LoginViewModel loginVM)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _loginRepository.AddAsync(loginVM);
                    return RedirectToAction("Success", "Login");
                }
            }
            catch
            {

                return View();
            }
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            if (string.IsNullOrWhiteSpace(model.Login))
            {
                ModelState.AddModelError("Login", "Login field is required.");
                return View(model);
            }
            // Determine whether the input is an email or username
            bool isEmail = model.Login.Contains("@");

            User user;

            if (isEmail)
            {
                // Find user by email
                user = await _loginRepository.GetUserByEmailAsync(model.Login);
            }
            else
            {
                // Find user by username
                user = await _loginRepository.GetUserByUsernameAsync(model.Login);
            }

            if (user == null || !(model.User.PassWord == user.PassWord))

            {
                ModelState.AddModelError("", "Invalid login credentials.");
                return View();
            }

            // Set up authentication (add cookies/session management here)
            return RedirectToAction("Index", "Login");

        }
    }
}
