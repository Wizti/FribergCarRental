using FribergCarRental.Data.interfaces;
using FribergCarRental.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.CodeDom;

namespace FribergCarRental.Controllers
{
    public class AdminRentalController : AdminCheckBaseController
    {
        private readonly IRentalService _rentalService;

        public AdminRentalController(IRentalService rentalService)
        {
            this._rentalService = rentalService;
        }
        // GET: AdminRentalController
        public async Task<IActionResult> Index()
        {
            var rentals = await _rentalService.GetAllRentalAsync();

            var rentalRecords = await Task.WhenAll(rentals.Select(async r => new RentalRecordViewModel
            {
                Rental = r,
                TotalPrice = await _rentalService.CalculateTotalPriceAsync(r.RentalStart, r.RentalEnd, r.CarId)
            }));

            return View(rentalRecords);
        }

        // GET: AdminRentalController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: AdminRentalController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: AdminRentalController/Create
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

        // GET: AdminRentalController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: AdminRentalController/Edit/5
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

        // GET: AdminRentalController/SoftDelete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: AdminRentalController/SoftDelete/5
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
