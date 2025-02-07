using FribergCarRental.Data.interfaces;
using FribergCarRental.Models;
using FribergCarRental.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages;

namespace FribergCarRental.Controllers
{
    public class RentalController : Controller
    {
        private readonly IRentalService _rentalService;

        public RentalController(IRentalService rentalService)
        {
            this._rentalService = rentalService;
        }

        public IActionResult SelectDates()
        {
            var selectDatesViewModel = new SelectDatesViewModel
            {
                StartDate = DateOnly.FromDateTime(DateTime.Today),
                EndDate = DateOnly.FromDateTime(DateTime.Today),
            };
            return View(selectDatesViewModel);
        }

        public async Task<IActionResult> AvailableCars(SelectDatesViewModel selectDatesVM)
        {
            var cars = await _rentalService.GetAllAvailableCarsAsync(selectDatesVM.StartDate, selectDatesVM.EndDate);

            List<RentalViewModel> rentalVMs = new List<RentalViewModel>();
            foreach (var car in cars)
            {
                rentalVMs.Add(new RentalViewModel
                {                    
                    Car = car,
                    StartDate = selectDatesVM.StartDate,
                    EndDate = selectDatesVM.EndDate,
                });
            }
            ViewData["StartDate"] = selectDatesVM.StartDate;
            ViewData["EndDate"] = selectDatesVM.EndDate;

            return View(rentalVMs);
        }

        [HttpGet]
        public async Task<IActionResult> ConfirmRental(int carId, DateOnly startDate, DateOnly endDate)
        {
            var car = await _rentalService.GetCarByIdAsync(carId);
            if (car == null)
            {
                return RedirectToAction("AvailableCars");
            }

            var rentalVM = new RentalViewModel
            {
                Car = car,
                StartDate = startDate,
                EndDate = endDate,
            };

            var totalPrice = await _rentalService.CalculateTotalPriceAsync(startDate, endDate, carId);
            
            ViewBag.TotalPrice = totalPrice;

            return View(rentalVM);
        }

        public ActionResult RentalSuccess()
        {
            return View();
        }
        // GET: RentalController
        public ActionResult Index()
        {
            return View();
        }

        // GET: RentalController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: RentalController/Create
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult SelectDates(SelectDatesViewModel selectDatesVM)
        {
            var customerId = HttpContext.Session.GetInt32("UserId");
            var role = HttpContext.Session.GetString("UserRole");

            if (customerId == null)
            {
                RedirectToAction("Login", "Account");
            }

            var currentDate = DateOnly.FromDateTime(DateTime.Today);
            if (selectDatesVM.StartDate < currentDate)
            {
                ModelState.AddModelError("", "Kan inte boka tidigare än dagens datum.");
                return View("SelectDates", selectDatesVM);
            }

            if (selectDatesVM.StartDate >= selectDatesVM.EndDate)
            {
                ModelState.AddModelError("", "Startdatum måste vara tidigare än slutdatum.");
                return View("SelectDates", selectDatesVM);
            }            

            return RedirectToAction("AvailableCars", selectDatesVM);
        }

        // POST: RentalController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(RentalViewModel rentalVM)
        {
            try
            {
                var customerId = HttpContext.Session.GetInt32("UserId");

                if (customerId == null)
                {
                    RedirectToAction("Login", "Account");
                }

                bool isCarAvailable = await _rentalService.IsCarAvailableAsync(rentalVM.Car.Id, rentalVM.StartDate, rentalVM.EndDate);
                if (!isCarAvailable)
                {                    
                    TempData["WarningMessage"] = "Denna bil är tyvärr inte tillgänglig";
                    return RedirectToAction("SelectDates");
                }

                var rental = new Rental
                {
                    CarId = rentalVM.Car.Id,
                    CustomerId = customerId.Value,
                    RentalStart = rentalVM.StartDate,
                    RentalEnd = rentalVM.EndDate
                };

                await _rentalService.CreateRentalAsync(rental);

                ViewBag.TotalPrice = await _rentalService.CalculateTotalPriceAsync(rental.RentalStart, rental.RentalEnd, rental.CarId);

                return RedirectToAction("RentalSuccess", rentalVM);
            }
            catch
            {
                return View();
            }
        }
    }
}
