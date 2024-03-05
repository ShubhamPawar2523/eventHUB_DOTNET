using Microsoft.AspNetCore.Mvc;


    using global::WebApplication1.Data;
    using global::WebApplication1.Models;
    using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using WebApplication2.Models;


namespace WebApplication1.Controllers

{
    // [Authorize(Roles = "User")]
    public class UserController : Controller
    {
        private MyDbContext _db;
        private IWebHostEnvironment _webHostEnvironment;

        private readonly UserManager<ApplicationUser> _userManager;
        public UserController(MyDbContext db, UserManager<ApplicationUser> userManager, IWebHostEnvironment webHostEnvironment)
        {
            _db = db;
            _userManager = userManager;
            _webHostEnvironment = webHostEnvironment;
        }

        public IActionResult Home()
        {
            return View();
        }


        public async Task<IActionResult> IndexUserAsync()
        {
            var booking = _db.Booking;
            return View(booking);
        }

        public IActionResult Bookings()
        {
            return View();
        }

        public IActionResult Create()
        {
            return View();
        }
        [HttpGet]
        public IActionResult Details(int id)
        {
            Booking booking = _db.Booking.Find(id);
            return View(booking);
        }

    }
}

