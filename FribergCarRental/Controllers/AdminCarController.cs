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
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: AdminCarController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: AdminCarController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(CreateCarViewModel createCarVM)
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
                    _carRepository.Add(car);
                    return Content("Fungerar");
                }
                return View();
                
            }
            catch
            {
                return View();
            }
        }

        // GET: AdminCarController/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            var car = await _carRepository.GetByIdAsync(id);
            if(car == null)
            {
                return NotFound();
            }
            return View(car);
        }

        // POST: AdminCarController/Edit/5
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

        // GET: AdminCarController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
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
