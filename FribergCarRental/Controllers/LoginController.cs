using FribergCarRental.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FribergCarRental.Controllers
{
    public class LoginController : Controller
    {
        private readonly ILogin _loginRepository;

        public LoginController(ILogin loginRepository)
        {
            this._loginRepository = loginRepository;
        }
        // GET: LoginController
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Create()
        { 
            return View(); 
        }

        // GET: LoginController/Details/5
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(string username, string password)
        {
            return View();
        }
    }
}
