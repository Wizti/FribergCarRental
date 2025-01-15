using FribergCarRental.Data;
using FribergCarRental.Models;
using FribergCarRental.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages;

namespace FribergCarRental.Controllers
{
    public class RentalController : Controller
    {
        private readonly IRental _rentalRepository;

        public RentalController(IRental rentalRepository)
        {
            this._rentalRepository = rentalRepository;
        }

        public async Task<IActionResult> SelectDates(int carId)
        {
            var car = await _rentalRepository.GetByIdAsync(carId);
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
                StartDate = DateOnly.MaxValue,
                EndDate = DateOnly.MinValue,
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

            var car = await _rentalRepository.GetByIdAsync(rentalVM.CarId);
            if (car == null)
            {
                return NotFound("Car not found.");
            }
            
            var rental = new Rental
            {
                CarId = car.Id,
                CustomerId = customerId.Value,
                RentalStart = rentalVM.StartDate,
                RentalEnd = rentalVM.EndDate
            };

            await _rentalRepository.AddAsync(rental);

            return RedirectToAction("RentalSuccess", "Rental");

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

        // GET: RentalController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: RentalController/Delete/5
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
    }
}
