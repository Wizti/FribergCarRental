using FribergCarRental.Data.interfaces;
using FribergCarRental.Models;
using FribergCarRental.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FribergCarRental.Controllers
{
    public class AdminCarController : AdminCheckController
    {
        private readonly ICarRepository _carRepository;

        public AdminCarController(ICarRepository carRepository)
        {
            this._carRepository = carRepository;
        }
        // GET: AdminCarController
        public async Task<IActionResult> Index()
        {
            var cars = await _carRepository.GetAllAsync();
            return View(cars);
        }

        // GET: AdminCarController/Details/5
        public async Task<IActionResult> Details(int id)
        {
            var car = await _carRepository.GetByIdAsync(id);
            return View(car);
        }

        // GET: AdminCarController/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            var car = await _carRepository.GetFullByIdAsync(id);
            if (car == null)
            {
                return NotFound();
            }
            return View(car);
        }

        // GET: AdminCarController/Create
        public IActionResult Create()
        {
            return View();
        }

        // GET: AdminCarController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: AdminCarController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CreateCarViewModel createCarVM)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var car = new Car
                    {
                        Model = createCarVM.Model,
                        Year = createCarVM.Year,
                        Price = createCarVM.Price,
                        Description = createCarVM.Description,
                        IsActive = createCarVM.IsActive,

                        Images = new List<Image>()
                        {
                            new Image { ImageUrl = createCarVM.ImageUrl }
                        }
                    };
                    await _carRepository.AddAsync(car);
                    return Content("Fungerar");
                }
                return View();

            }
            catch
            {
                return View();
            }
        }

        // POST: AdminCarController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Car carModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var car = await _carRepository.GetFullByIdAsync(carModel.Id);
                    if (car == null)
                    {
                        return NotFound();
                    }

                    car.Model = carModel.Model;
                    car.Year = carModel.Year;
                    car.Price = carModel.Price;
                    car.Description = carModel.Description;
                    car.IsActive = carModel.IsActive;

                    for (int i = 0; i < car.Images.Count; i++)
                    {
                        car.Images[i].ImageUrl = carModel.Images[i].ImageUrl;
                    }

                    _carRepository.UpdateAsync(car);
                }
                return RedirectToAction("Index");
            }
            catch
            {
                return View(carModel);
            }
            
        }

        // POST: AdminCarController/Delete/5
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
