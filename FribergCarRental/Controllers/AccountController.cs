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
        private readonly IAccountService _accountService;

        public AccountController(IAccountService accountService)
        {
            this._accountService = accountService;
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
        public async Task<IActionResult> Create(CreateViewModel createVM)
        {
            if (!ModelState.IsValid)
            {
                return View(createVM);
            }

            if (await _accountService.CustomerExistsAsync(createVM.Customer.Email, createVM.Customer.UserName))
            {
                ModelState.AddModelError("", "Email eller Användarnamn är upptaget");
                return View(createVM);
            }

            try
            {
                await _accountService.AddAsync(createVM);
                User user = await _accountService.GetUserByUsernameAsync(createVM.Customer.UserName);

                HttpContext.Session.SetInt32("UserId", user.CustomerId);
                HttpContext.Session.SetString("UserName", createVM.Customer.UserName);

                var selectedCarId = HttpContext.Session.GetInt32("SelectedCarId");
                if (selectedCarId.HasValue)
                {
                    HttpContext.Session.Remove("SelectedCarId");
                    return RedirectToAction("SelectDates", "Rental", new { carId = selectedCarId.Value });
                }
                else
                {                    
                    return RedirectToAction("Success", "Account");
                }
            }
            catch
            {
                return View();
            }
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel loginVM)
        {
            if (!ModelState.IsValid)
            {
                return View(loginVM);
            }

            bool isEmail = loginVM.Login.Contains("@");

            Customer customer = isEmail
                ? await _accountService.GetCustomerByEmailAsync(loginVM.Login)
                : await _accountService.GetCustomerByUsernameAsync(loginVM.Login);
            User user = await _accountService.GetUserByUsernameAsync(customer.UserName);

            if (user == null || loginVM.Password != user.Password)
            {
                ModelState.AddModelError("", "Invalid login credentials.");
                return View(loginVM);
            }

            HttpContext.Session.SetInt32("UserId", user.CustomerId);
            HttpContext.Session.SetString("UserName", customer.UserName);

            var selectedCarId = HttpContext.Session.GetInt32("SelectedCarId");
            if (selectedCarId.HasValue)
            {
                HttpContext.Session.Remove("SelectedCarId");
                return RedirectToAction("SelectDates", "Rental", new { carId = selectedCarId.Value });
            }

            return RedirectToAction("Success", "Account");
        }

        [HttpPost]
        public async Task<IActionResult> ForgotPassword(ForgotPasswordViewModel forgotPasswordVM)
        {
            if (!ModelState.IsValid)
            {
                return View(forgotPasswordVM);
            }

            Customer customer = await _accountService.GetCustomerByEmailAsync(forgotPasswordVM.Email);

            if (customer == null)
            {
                ModelState.AddModelError("", "Invalid login credentials.");
                return View(forgotPasswordVM);
            }

            User user = await _accountService.GetUserByUsernameAsync(customer.UserName);

            ViewBag.ShowPassword = $"Ditt lösen: {user.Password}";
            return View();
        }

    }
}
