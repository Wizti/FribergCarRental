using FribergCarRental.Data.interfaces;
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
            if (HttpContext.Session.GetString("UserId") == null)
            {
                HttpContext.Session.SetInt32("SelectedCarId", carId);
                return RedirectToAction("Login", "Account");
            }

            return RedirectToAction("SelectDates", "Rental", new { carId });
        }

        // GET: CarController/Details/5
        public async Task<IActionResult> Details(int id)
        {
            var car = await _carRepository.GetFullByIdAsync(id);

            return View(car);
        }

        // GET: CarController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CarController/Create
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

        // GET: CarController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: CarController/Edit/5
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

        // GET: CarController/SoftDelete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: CarController/SoftDelete/5
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
