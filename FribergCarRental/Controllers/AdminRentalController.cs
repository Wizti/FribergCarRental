using FribergCarRental.Data;
using FribergCarRental.Data.interfaces;
using FribergCarRental.Models;
using FribergCarRental.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.CodeDom;

namespace FribergCarRental.Controllers
{
    public class AdminRentalController : AdminCheckBaseController
    {
        private readonly IRentalService _rentalService;
        private readonly IRentalRepository _rentalRepository;

        public AdminRentalController(IRentalService rentalService, IRentalRepository rentalRepository)
        {
            this._rentalService = rentalService;
            this._rentalRepository = rentalRepository;
        }
        // GET: AdminRentalController
        public async Task<IActionResult> Index()
        {
            var rentals = await _rentalService.GetAllRentalAsync();

            foreach (var rental in rentals)
            {
                _rentalService.UpdateRentalStatus(rental);
            }

            var rentalRecords = await Task.WhenAll(rentals.Select(async r => new RentalRecordViewModel
            {
                Rental = r,
                TotalPrice = await _rentalService.CalculateTotalPriceAsync(r.RentalStart, r.RentalEnd, r.CarId)
            }));

            return View(rentalRecords);
        }

        // GET: AdminRentalController/Details/5
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

        // GET: AdminRentalController/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            var rental = await _rentalRepository.GetByIdAsync(id);
            if (rental == null)
            {
                return NotFound();
            }
            return View(rental);
        }        

        // POST: AdminRentalController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(Rental rental)
        {
            try
            {
                var rentalToDelete = await _rentalRepository.GetByIdAsync(rental.Id);
                if (rentalToDelete != null)
                {
                    await _rentalRepository.DeleteAsync(rentalToDelete);
                    TempData["SuccessMessage"] = $"Ordernummer: {rentalToDelete.Id} är borttagen!";

                    return RedirectToAction(nameof(Index));
                }
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
