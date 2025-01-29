using FribergCarRental.Data;
using FribergCarRental.Data.Enums;
using FribergCarRental.Data.interfaces;
using FribergCarRental.Models;
using FribergCarRental.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FribergCarRental.Controllers
{
    public class AdminAccountController : AdminCheckBaseController
    {
        private readonly IUserRepository _userRepository;
        private readonly IAccountService _accountService;

        public AdminAccountController(IUserRepository userRepository, IAccountService accountService)
        {
            this._userRepository = userRepository;
            this._accountService = accountService;
        }
        // GET: AdminCustomerController
        public async Task<IActionResult> Index()
        {
            var users = await _userRepository.GetAllAsync();
            return View(users);
        }

        // GET: AdminCustomerController/Details/5
        public async Task<IActionResult> Details(int id)
        {
            var customer = await _userRepository.GetCustomerByIdAsync(id);
            return View(customer);
        }

        // GET: AdminCustomerController/Create
        public ActionResult Create()
        {
            return View();
        }

        // GET: AdminCustomerController/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            var customer = await _userRepository.GetCustomerByIdAsync(id);

            if (customer == null)
            {
                return NotFound();
            }
            if (customer.Address == null)
            {
                return NotFound("Hittade inte address");
            }

            var editCustomerViewModel = new EditCustomerViewModel
            {
                Id = customer.Id,
                FirstName = customer.FirstName,
                LastName = customer.LastName,
                Phone = customer.Phone,
                Street = customer.Address.Street,
                City = customer.Address.City,
                Postalcode = customer.Address.Postalcode,
                UserName = customer.UserName,
                Password = customer.Password
            };
            return View(editCustomerViewModel);
        }

        // GET: AdminCustomerController/SoftDelete/5
        public async Task<IActionResult> Delete(int id)
        {
            var customer = await _userRepository.GetCustomerByIdAsync(id);

            var deleteCustomerVM = new DeleteCustomerViewModel()
            {
                FirstName = customer.FirstName,
                LastName = customer.LastName,
                Phone = customer.Phone,
                Email = customer.Email,
                UserId = customer.Id,

            };
            return View(deleteCustomerVM);
        }

        // POST: AdminCustomerController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Customer customer)
        {
            if (!ModelState.IsValid)
            {
                return View(customer);
            }

            if (await _accountService.UserExistsAsync(customer.Email, customer.UserName))
            {
                ModelState.AddModelError("", "Email eller Användarnamn är upptaget");
                return View(customer);
            }

            try
            {
                customer.Role = Role.Customer;
                await _userRepository.AddAsync(customer);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // POST: AdminCustomerController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(EditCustomerViewModel customerVM)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var customer = await _userRepository.GetCustomerByIdAsync(customerVM.Id);
                    if (customer == null)
                    {
                        return NotFound();
                    }

                    customer.FirstName = customerVM.FirstName;
                    customer.LastName = customerVM.LastName;
                    customer.Phone = customerVM.Phone;
                    customer.Address.Street = customerVM.Street;
                    customer.Address.Postalcode = customerVM.Postalcode;
                    customer.Address.City = customerVM.City;
                    customer.UserName = customerVM.UserName;
                    if (customerVM.Password != null)
                    {
                        customer.Password = customerVM.Password;
                    }
                    //customer.Password = customer.Password;

                    await _userRepository.UpdateUserAsync(customer);
                }
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View(customerVM);
            }
        }

        // POST: AdminCustomerController/SoftDelete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(DeleteCustomerViewModel customerVM)
        {
            try
            {
                var userToDelete = await _userRepository.GetAllRentalsByCustomerAsync(customerVM.UserId);
                if (userToDelete == null)
                {
                    return NotFound();
                }

                foreach(var rental in userToDelete.Rentals)
                {
                    rental.CustomerId = null;
                }

                await _userRepository.DeleteUserAsync(userToDelete);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
