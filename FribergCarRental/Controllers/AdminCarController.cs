using FribergCarRental.Data;
using FribergCarRental.Data.interfaces;
using FribergCarRental.Models;
using FribergCarRental.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FribergCarRental.Controllers
{
    public class AdminCarController : AdminCheckBaseController
    {
        private readonly ICarRepository _carRepository;
        private readonly IRentalRepository _rentalRepository;

        public AdminCarController(ICarRepository carRepository, IRentalRepository rentalRepository)
        {
            this._carRepository = carRepository;
            this._rentalRepository = rentalRepository;
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

        // GET: AdminCarController/SoftDelete/5
        public async Task<IActionResult> SoftDelete(int id)
        {
            var car = await _carRepository.GetByIdAsync(id);
            if(car == null)
            {
                return NotFound();
            }
            return View(car);
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
        public async Task<IActionResult> Edit(Car carModel, string? NewImageUrl)
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

                    var imageToRemove = new List<Image>();

                    for (int i = 0; i < car.Images.Count; i++)
                    {
                        var updatedUrl = carModel.Images[i].ImageUrl;

                        if(string.IsNullOrEmpty(updatedUrl))
                        {
                            imageToRemove.Add(car.Images[i]);
                        }
                        else
                        {
                            car.Images[i].ImageUrl = updatedUrl;
                        }
                    }

                    foreach (var image in imageToRemove)
                    {
                        await _carRepository.RemoveImageAsync(image.Id);
                    }

                    if (!string.IsNullOrEmpty(NewImageUrl))
                    {
                        car.Images.Add(new Image { ImageUrl = NewImageUrl });
                    }

                    await _carRepository.UpdateAsync(car);
                }
                return RedirectToAction("Index");
            }
            catch
            {
                return View(carModel);
            }
            
        }

        // POST: AdminCarController/SoftDelete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> SoftDelete(Car car)
        {
            try
            {                
                var carToDisable = await _carRepository.GetByIdAsync(car.Id);
                if (carToDisable != null)
                {
                    await _carRepository.DisableAsync(carToDisable);
                    return RedirectToAction("Index");
                }
                return NotFound();
            }
            catch
            {
                return View();
            }
        }
    }
}
