﻿using FribergCarRental.Data.Enums;
using FribergCarRental.Data.interfaces;
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

        public IActionResult AccessDenied()
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
        public ActionResult Login(string? returnUrl = null)
        {
            ViewData["ReturnUrl"] = returnUrl;
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Customer customer)
        {
            if (!ModelState.IsValid)
            {
                return View(customer);
            }

            if (await _accountService.UserExistsAsync(customer.Email, customer.UserName))
            {
                ModelState.AddModelError("", "Email eller Användarnamn är upptaget");
                return View(customer);
            }

            try
            {
                customer.Role = Role.Customer;
                await _accountService.AddAsync(customer);

                User user = await _accountService.GetUserByUsernameAsync(customer.UserName);
                HttpContext.Session.SetInt32("UserId", user.Id);
                HttpContext.Session.SetString("UserName", user.UserName);
                HttpContext.Session.SetString("UserRole", user.Role.Value.ToString());

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
        public async Task<IActionResult> Login(LoginViewModel loginVM, string? returnUrl = null)
        {
            if (!ModelState.IsValid)
            {
                return View(loginVM);
            }

            bool isEmail = loginVM.Login.Contains("@");

            User user = await _accountService.GetUserByEmailOrUsernameAsync(loginVM.Login, isEmail);

            if (user == null || loginVM.Password != user.Password || user.Role == Role.Admin)
            {
                ModelState.AddModelError("", "Ogiltiga inloggningsuppgifter.");
                return View(loginVM);
            }

            HttpContext.Session.SetInt32("UserId", user.Id);
            HttpContext.Session.SetString("UserName", user.UserName);
            HttpContext.Session.SetString("UserRole", user.Role.ToString());

            /*var selectedCarId = HttpContext.Session.GetInt32("SelectedCarId");
            if (selectedCarId.HasValue)
            {
                HttpContext.Session.Remove("SelectedCarId");
                return RedirectToAction("SelectDates", "Rental", new { carId = selectedCarId.Value });
            }*/
            if (!string.IsNullOrEmpty(returnUrl) && Url.IsLocalUrl(returnUrl))
            {
                return Redirect(returnUrl);
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

            User user = await _accountService.GetUserByEmailAsync(forgotPasswordVM.Email);

            if (user == null)
            {
                ModelState.AddModelError("", "Invalid login credentials.");
                return View(forgotPasswordVM);
            }

            ViewBag.ShowPassword = $"Ditt lösen: {user.Password}";
            return View();
        }

    }
}
