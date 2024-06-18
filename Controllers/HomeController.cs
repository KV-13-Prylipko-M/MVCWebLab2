using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MVCWebLab2.Models;
using System.Diagnostics;

namespace MVCWebLab2.Controllers {
    public class HomeController : Controller {
        public static bool IsAuthorized { get; set; } = false;
        public static User User { get; set; }
        private static LabContext context = new LabContext();
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger) {
            _logger = logger;
        }

        public IActionResult Index() {
            if(!IsAuthorized) {
                return View("Login");
            }
            return View("Index");
        }

        public IActionResult About() {
            return View("About");
        }

        public IActionResult App() {
            return View("App");
        }

        public IActionResult Register() {
            return View("Register");
        }
        public async Task<IActionResult> OnRegister(string name, string email, DateTime birthday, string gender, string password) {
            User user = new User() {
                Name = name,
                Email = email,
                Birthday = birthday,
                Gender = gender,
                Password = password
            };
            await context.Users.AddAsync(user);
            await context.SaveChangesAsync();
            return View("Login");
        }

        public IActionResult Login() {
            return View("Login");
        }

        public async Task<IActionResult> OnLogin(string email, string password) {
            User? user = await context.Users.SingleOrDefaultAsync(o => o.Email == email && o.Password == password);
            if(user == null) {
                return View("Index");
            }
            IsAuthorized = true;
            User = user;
            return RedirectToAction("Index");
        }

        public IActionResult Profile() {
            return View("Profile");
        }

        public IActionResult Privacy() {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error() {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
