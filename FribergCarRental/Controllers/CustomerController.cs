using FribergCarRental.Data;
using FribergCarRental.Data.interfaces;
using FribergCarRental.Models;
using FribergCarRental.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FribergCarRental.Controllers
{
    public class CustomerController : CustomerCheckBaseController
    {
        private readonly IRentalRepository _rentalRepository;
        private readonly IRentalService _rentalService;

        public CustomerController(IRentalRepository rentalRepository, IRentalService rentalService)
        {
            this._rentalRepository = rentalRepository;
            this._rentalService = rentalService;
        }
        // GET: CustomerController
        public async Task<IActionResult> Index()
        {
            var customerId = HttpContext.Session.GetInt32("UserId");

            var rentals = await _rentalRepository.GetAllCustomerRentalsAsync(customerId);

            foreach (var rental in rentals)
            {
                _rentalService.UpdateRentalStatus(rental);
            }

            var rentalRecords = new List<RentalRecordViewModel>();

            foreach (var rental in rentals)
            {
                var totalPrice = await _rentalService.CalculateTotalPriceAsync(rental.RentalStart, rental.RentalEnd, rental.CarId);

                rentalRecords.Add(new RentalRecordViewModel
                {
                    Rental = rental,
                    TotalPrice = totalPrice
                });
            }          

            return View(rentalRecords);
        }

        // GET: CustomerController/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            var rental = await _rentalRepository.GetFullRentalByIdAsync(id);
            if (rental == null)
            {
                return NotFound();
            }
            return View(rental);
        }

        // GET: CustomerController/Details/5
        public async Task<IActionResult> Details(int id)
        {
            var rental = await _rentalRepository.GetFullRentalByIdAsync(id);
            if (rental == null)
            {
                return NotFound();
            }

            var rentalVM = new RentalRecordViewModel
            {
                Rental = rental,
                TotalPrice = await _rentalService.CalculateTotalPriceAsync(rental.RentalStart, rental.RentalEnd, rental.CarId)
            };
            return View(rentalVM);
        }

        // GET: CustomerController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: CustomerController/Edit/5
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

        // POST: CustomerController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(Rental rental)
        {
            try
            {
                var rentalToDelete = await _rentalRepository.GetByIdAsync(rental.Id);
                await _rentalRepository.DeleteAsync(rentalToDelete);

                TempData["SuccessMessage"] = $"Din bokning med bokningsnummer: {rentalToDelete.Id} har tagits bort!";

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
