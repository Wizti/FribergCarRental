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

        public async Task<IActionResult> SelectDates(int carId)
        {
            var car = await _rentalService.GetCarByIdAsync(carId);
            if (car == null)
            {
                return NotFound();
            }

            var rentalViewModel = new RentalViewModel
            {
                CarId = car.Id,
                Description = car.Description,
                Model = car.Model,
                Price = car.Price,
                StartDate = DateOnly.FromDateTime(DateTime.Today),
                EndDate = DateOnly.FromDateTime(DateTime.Today),
            };
            return View(rentalViewModel);
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
        public async Task<IActionResult> ConfirmRental(RentalViewModel rentalVM)
        {
            var customerId = HttpContext.Session.GetInt32("UserId");

            if (customerId == null)
            {
                RedirectToAction("Login", "Account");
            }

            var currentDate = DateOnly.FromDateTime(DateTime.Today);
            if (rentalVM.StartDate < currentDate)
            {
                ModelState.AddModelError("", "Kan inte boka tidigare än dagens datum.");
                return View("SelectDates", rentalVM);
            }

            if (rentalVM.StartDate >= rentalVM.EndDate)
            {
                ModelState.AddModelError("", "Startdatum måste vara tidigare än slutdatum.");
                return View("SelectDates", rentalVM);
            }

            if (!await _rentalService.IsCarAvailableAsync(rentalVM.CarId, rentalVM.StartDate, rentalVM.EndDate))
            {
                ModelState.AddModelError("", "Bilen är tyvärr inte tillgänglig från och till det datumet du valde.");
                return View("SelectDates", rentalVM);
            }

            var rental = new Rental
            {
                CarId = rentalVM.CarId,
                CustomerId = customerId.Value,
                RentalStart = rentalVM.StartDate,
                RentalEnd = rentalVM.EndDate
            };

            await _rentalService.CreateRentalAsync(rental);

            return View("RentalSuccess", rentalVM);

        }

        // POST: RentalController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: RentalController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: RentalController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: RentalController/SoftDelete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: RentalController/SoftDelete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // helper method
        /*private async Task<IActionResult> PopulateSelectDatesView(RentalViewModel rentalVM)
        {
            var car = await _rentalService.GetCarByIdAsync(rentalVM.CarId);

            if (car == null)
            {
                return NotFound();
            }

            rentalVM.Description = car.Description;
            rentalVM.Model = car.Model;
            rentalVM.Price = car.Price;

            return View("SelectDates", rentalVM);
        }*/
    }
}
