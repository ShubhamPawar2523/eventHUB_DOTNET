
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.DTOs;
using Microsoft.AspNetCore.Authorization;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AdminController : Controller
    {
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly UserManager<ApplicationUser> _userManager;

        public AdminController(RoleManager<IdentityRole> roleManager, UserManager<ApplicationUser> userManager)
        {
            _roleManager = roleManager;
            _userManager = userManager;

        }
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public IActionResult GetUsers()
        {
            var users = _userManager.Users;
            return View(users);
        }
        [HttpGet]
        public IActionResult GetAllRoles()
        {
            var roles = _roleManager.Roles;
            return View(roles);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpGet]
        public async Task<IActionResult> GetUserDet(string id)
        {
            var us = await _userManager.FindByIdAsync(id);
            return View(us);
        }
        [HttpPost]
        public async Task<IActionResult> AddRoletoUser(string id, string roleid)
        {

            var us = await _userManager.FindByIdAsync(id);

            var role = await _roleManager.FindByIdAsync(roleid);
            await _userManager.AddToRoleAsync(us, role.Name);
            return RedirectToAction("Index");
        }
        [HttpPost]
        public async Task<IActionResult> Create(RoleStore roleStore)
        {
            var ifExist = await _roleManager.RoleExistsAsync(roleStore.RoleName);
            if (!ifExist)
            {
                await _roleManager.CreateAsync(new IdentityRole(roleStore.RoleName));
                return RedirectToAction("Index");
            }
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> DeleteUser(string id)
        {

            Console.WriteLine($"Deleting user with ID: {id}");

            var user = await _userManager.FindByIdAsync(id);

            if (user != null)
            {
                var result = await _userManager.DeleteAsync(user);

                if (result.Succeeded)
                {
                    return RedirectToAction("GetUsers");
                }
                else
                {
                    // Handle errors, if any
                    ModelState.AddModelError("", "Failed to delete user.");
                }
            }
            else
            {
                // Handle case where the user with the specified id was not found
                ModelState.AddModelError("", "User not found.");
            }

            return View("GetUsers", _userManager.Users);
        }
    

}
}




