using FribergCarRental.Data.interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.CodeDom;

namespace FribergCarRental.Controllers
{
    public class AdminRentalController : AdminCheckController
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
            return View(rentals);
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

        // GET: AdminRentalController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: AdminRentalController/Delete/5
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
