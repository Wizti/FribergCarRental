using FribergCarRental.Data.interfaces;
using FribergCarRental.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FribergCarRental.Controllers
{
    public class CarController : Controller
    {
        private readonly ICarRepository _carRepository;

        public CarController(ICarRepository carRepository)
        {
            this._carRepository = carRepository;
        }
        // GET: CarController
        public async Task<IActionResult> Index()
        {
            var cars = await _carRepository.GetAllAsync();
            if (cars != null)
            {
                return View(cars);
            }
            return View();
        }

        public IActionResult RentCar(int carId)
        {
            if (HttpContext.Session.GetString("UserId") == null || HttpContext.Session.GetString("UserRole") == "Admin")
            {
                TempData["SuccessMessage"] = $"Logga in eller skapa konto för att boka en bil!";

                var returnUrl = Url.Action("SelectDates", "Rental");
                return RedirectToAction("Login", "Account", new { returnUrl });
            }

            return RedirectToAction("SelectDates", "Rental");
        }

        // GET: CarController/Details/5
        public async Task<IActionResult> Details(int id, DateOnly startDate, DateOnly endDate)
        {
            var car = await _carRepository.GetFullByIdAsync(id);
            ViewData["StartDate"] = startDate;
            ViewData["EndDate"] = endDate;

            return View(car);
        }
    }
}
